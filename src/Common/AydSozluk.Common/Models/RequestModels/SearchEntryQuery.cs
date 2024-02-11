using AYDSozluk.Common.Models.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Models.RequestModels
{
    public class SearchEntryQuery : IRequest<List<SearchEntryResponse>>
    {
        public string SearchText { get; set; }

        public SearchEntryQuery()
        {

        }

        public SearchEntryQuery(string searchText)
        {
            SearchText = searchText;
        }
    }
}
