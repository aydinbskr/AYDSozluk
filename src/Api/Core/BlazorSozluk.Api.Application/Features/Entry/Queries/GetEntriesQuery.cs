using AYDSozluk.Common.Models.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.Entry.Queries
{
    public class GetEntriesQuery : IRequest<List<GetEntriesResponse>>
    {
        public bool TodaysEntries { get; set; }

        public int Count { get; set; } = 100;
    }
}
