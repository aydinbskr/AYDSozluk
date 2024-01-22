using AutoMapper;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest, Guid>
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.GetByIdAsync(request.Id);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found!");

            var dbEmailAddress = dbUser.EmailAddress;
            var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress) != 0;

            mapper.Map(request, dbUser);

            var rows = await userRepository.UpdateAsync(dbUser);

            if (emailChanged && rows > 0)
            {
                //var @event = new UserEmailChangedEvent()
                //{
                //    OldEmailAddress = null,
                //    NewEmailAddress = dbUser.EmailAddress
                //};

                //QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName,
                //                                   exchangeType: SozlukConstants.DefaultExchangeType,
                //                                   queueName: SozlukConstants.UserEmailChangedQueueName,
                //                                   obj: @event);

                dbUser.EmailConfirmed = false;
                await userRepository.UpdateAsync(dbUser);
            }

            return dbUser.Id;
        }
    }
}
