using AutoMapper;
using AYDSozluk.Common;
using AYDSozluk.Common.Events.User;
using AYDSozluk.Common.Infrastructure;
using AYDSozluk.Common.Infrastructure.Exceptions;
using AYDSozluk.Common.Models.RequestModels;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.User.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var existsUser = await userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

            if (existsUser is not null)
                throw new DatabaseValidationException("User already exists!");

            var dbUser = mapper.Map<AYDSozluk.Api.Domain.Models.User>(request);

            var rows = await userRepository.AddAsync(dbUser);

            // Email Changed/Created
            if (rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAddress
                };

                QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName,
                                                   exchangeType: SozlukConstants.DefaultExchangeType,
                                                   queueName: SozlukConstants.UserEmailChangedQueueName,
                                                   obj: @event);
            }

            return dbUser.Id;
        }
    }
}
