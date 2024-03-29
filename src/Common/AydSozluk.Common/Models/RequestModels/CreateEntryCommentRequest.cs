﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Models.RequestModels
{
    public class CreateEntryCommentRequest : IRequest<Guid>
    {
        public Guid? EntryId { get; set; }

        public string Content { get; set; }

        public Guid? CreatedById { get; set; }

        public CreateEntryCommentRequest()
        {

        }

        public CreateEntryCommentRequest(Guid entryId, string content, Guid createdById)
        {
            EntryId = entryId;
            Content = content;
            CreatedById = createdById;
        }
    }
}
