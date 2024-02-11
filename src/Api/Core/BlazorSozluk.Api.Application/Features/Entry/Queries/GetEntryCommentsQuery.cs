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
    public class GetEntryCommentsQuery : BasePagedQuery, IRequest<PagedResponse<GetEntryCommentsResponse>>
    {
        public GetEntryCommentsQuery(Guid entryId, Guid? userId, int page, int pageSize) : base(page, pageSize)
        {
            EntryId = entryId;
            UserId = userId;
        }


        public Guid EntryId { get; set; }

        public Guid? UserId { get; set; }
    }
}
