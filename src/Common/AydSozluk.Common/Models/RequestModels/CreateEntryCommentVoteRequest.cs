using AYDSozluk.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Models.RequestModels
{
    public class CreateEntryCommentVoteRequest : IRequest<bool>
    {
        public Guid EntryCommentId { get; set; }

        public VoteType VoteType { get; set; }

        public Guid CreatedBy { get; set; }

        public CreateEntryCommentVoteRequest()
        {

        }

        public CreateEntryCommentVoteRequest(Guid entryCommentId, VoteType voteType, Guid createdBy)
        {
            EntryCommentId = entryCommentId;
            VoteType = voteType;
            CreatedBy = createdBy;
        }
    }
}
