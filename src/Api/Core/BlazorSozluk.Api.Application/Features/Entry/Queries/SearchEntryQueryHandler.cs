using AYDSozluk.Common.Models.RequestModels;
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
    public class SearchEntryQueryHandler : IRequestHandler<SearchEntryQuery, List<SearchEntryResponse>>
    {
        private readonly IEntryRepository entryRepository;

        public SearchEntryQueryHandler(IEntryRepository entryRepository)
        {
            this.entryRepository = entryRepository;
        }

        public async Task<List<SearchEntryResponse>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
        {
            // TODO validation, request.SearchText length should be checked

            var result = entryRepository
                .Get(i => EF.Functions.Like(i.Subject, $"{request.SearchText}%"))
                .Select(i => new SearchEntryResponse()
                {
                    Id = i.Id,
                    Subject = i.Subject,
                });

            return await result.ToListAsync(cancellationToken);
        }
    }
}
