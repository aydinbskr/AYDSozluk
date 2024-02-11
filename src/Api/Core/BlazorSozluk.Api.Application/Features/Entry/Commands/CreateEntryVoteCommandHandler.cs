using AYDSozluk.Common.Events.Entry;
using AYDSozluk.Common.Infrastructure;
using AYDSozluk.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AYDSozluk.Common.Models.RequestModels;

namespace BlazorSozluk.Api.Application.Features.Entry.Commands
{
    public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteRequest, bool>
    {
        public async Task<bool> Handle(CreateEntryVoteRequest request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.VoteExchangeName,
                exchangeType: SozlukConstants.DefaultExchangeType,
                queueName: SozlukConstants.CreateEntryVoteQueueName,
                obj: new CreateEntryVoteEvent()
                {
                    EntryId = request.EntryId,
                    CreatedBy = request.CreatedBy,
                    VoteType = request.VoteType
                });

            return await Task.FromResult(true);
        }
    }
}
