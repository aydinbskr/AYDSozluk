using AutoMapper;
using AYDSozluk.Api.Domain.Models;
using AYDSozluk.Common.Models.RequestModels;
using AYDSozluk.Common.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserResponse>()
                .ReverseMap();

            CreateMap<CreateUserRequest, User>();

            CreateMap<UpdateUserRequest, User>();

            CreateMap<UserDetailResponse, User>()
                .ReverseMap();

            CreateMap<CreateEntryRequest, Entry>()
                .ReverseMap();

            CreateMap<Entry, GetEntriesResponse>()
                .ForMember(x => x.CommentCount, y => y.MapFrom(z => z.EntryComments.Count));


            CreateMap<CreateEntryCommentRequest, EntryComment>()
                .ReverseMap();


        }
    }
}
