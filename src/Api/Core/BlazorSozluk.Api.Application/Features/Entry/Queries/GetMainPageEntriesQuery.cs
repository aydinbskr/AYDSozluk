﻿using AYDSozluk.Common.Models.Page;
using AYDSozluk.Common.Models.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.Entry.Queries
{
    public class GetMainPageEntriesQuery : BasePagedQuery, IRequest<PagedResponse<GetEntryDetailResponse>>
    {
        public GetMainPageEntriesQuery(Guid? userId, int page, int pageSize) : base(page, pageSize)
        {
            UserId = userId;
        }

        public Guid? UserId { get; set; }
    }
}
