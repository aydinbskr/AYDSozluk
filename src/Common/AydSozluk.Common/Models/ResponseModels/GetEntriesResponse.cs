using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Models.ResponseModels
{
    public class GetEntriesResponse
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }

        public int CommentCount { get; set; }

    }
}
