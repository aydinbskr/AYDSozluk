using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Models.Page
{
    public class PagedResponse<T> where T : class
    {
        public PagedResponse() : this(new List<T>(), new Page())
        {

        }

        public PagedResponse(IList<T> results, Page pageInfo)
        {
            Results = results;
            PageInfo = pageInfo;
        }

        public IList<T> Results { get; set; }

        public Page PageInfo { get; set; }
    }
}
