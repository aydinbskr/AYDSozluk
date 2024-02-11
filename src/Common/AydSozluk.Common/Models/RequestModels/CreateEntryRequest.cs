using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Models.RequestModels
{
    public class CreateEntryRequest : IRequest<Guid>
    {
        public string Subject { get; set; }

        public string Content { get; set; }

        public Guid? CreatedById { get; set; }

        public CreateEntryRequest()
        {

        }

        public CreateEntryRequest(string subject, string content, Guid? createdById)
        {
            Subject = subject;
            Content = content;
            CreatedById = createdById;
        }
    }
}
