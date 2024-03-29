﻿using AYDSozluk.Common.Infrastructure.Extensions;
using AYDSozluk.Common.Models.Page;
using AYDSozluk.Common.Models.ResponseModels;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.Entry.Queries
{
    public class GetUserEntriesQueryHandler : IRequestHandler<GetUserEntriesQuery, PagedResponse<GetUserEntriesDetailResponse>>
    {
        private readonly IEntryRepository entryRepository;

        public GetUserEntriesQueryHandler(IEntryRepository entryRepository)
        {
            this.entryRepository = entryRepository;
        }

        public async Task<PagedResponse<GetUserEntriesDetailResponse>> Handle(GetUserEntriesQuery request, CancellationToken cancellationToken)
        {
            var query = entryRepository.AsQueryable();

            if (request.UserId != null && request.UserId.HasValue && request.UserId != Guid.Empty)
            {
                query = query.Where(i => i.CreatedById == request.UserId);
            }
            else if (!string.IsNullOrEmpty(request.UserName))
            {
                query = query.Where(i => i.CreatedBy.UserName == request.UserName);
            }
            else
                return null;

            query = query.Include(i => i.EntryFavorites)
                         .Include(i => i.CreatedBy);

            var list = query.Select(i => new GetUserEntriesDetailResponse()
            {
                Id = i.Id,
                Subject = i.Subject,
                Content = i.Content,
                IsFavorited = false,
                FavoritedCount = i.EntryFavorites.Count,
                CreatedDate = i.CreateDate,
                CreatedByUserName = i.CreatedBy.UserName
            });

            var entries = await list.GetPaged(request.Page, request.PageSize);

            return entries;
        }
    }
}
