using AutoMapper;
using AYDSozluk.Common.Models.ResponseModels;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.User.Queries
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public GetUserDetailQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<UserDetailResponse> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            AYDSozluk.Api.Domain.Models.User dbUser = null;

            if (request.UserId != Guid.Empty)
                dbUser = await userRepository.GetByIdAsync(request.UserId);
            else if (!string.IsNullOrEmpty(request.UserName))
                dbUser = await userRepository.GetSingleAsync(i => i.UserName == request.UserName);

            // TODO if both are empty, throw new exception

            return mapper.Map<UserDetailResponse>(dbUser);
        }
    }
}
