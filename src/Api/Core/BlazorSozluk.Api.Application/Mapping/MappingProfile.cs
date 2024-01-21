using AutoMapper;
using AYDSozluk.Api.Domain.Models;
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

            //CreateMap<CreateUserCommand, User>();

            //CreateMap<UpdateUserCommand, User>();

            //CreateMap<UserDetailViewModel, User>()
            //    .ReverseMap();

            //CreateMap<CreateEntryCommand, Entry>()
            //    .ReverseMap();

            //CreateMap<Entry, GetEntriesViewModel>()
            //    .ForMember(x => x.CommentCount, y => y.MapFrom(z => z.EntryComments.Count));


            //CreateMap<CreateEntryCommentCommand, EntryComment>()
            //    .ReverseMap();


        }
    }
}
