using AYDSozluk.Common.Models.Page;
using AYDSozluk.Common.Models.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.Entry.Queries
{
    public class GetUserEntriesQuery : BasePagedQuery, IRequest<PagedResponse<GetUserEntriesDetailResponse>>
    {
        public Guid? UserId { get; set; }

        public string UserName { get; set; }

        public GetUserEntriesQuery(Guid? userId, string userName = null, int page = 1, int pageSize = 10) : base(page, pageSize)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}
