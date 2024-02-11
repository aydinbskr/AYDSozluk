using AutoMapper;
using AYDSozluk.Common.Models.RequestModels;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.EntryComment.Commands
{
    public class CreateEntryCommentCommandHandler : IRequestHandler<CreateEntryCommentRequest, Guid>
    {
        private readonly IEntryCommentRepository entryCommentRepository;
        private readonly IMapper mapper;

        public CreateEntryCommentCommandHandler(IEntryCommentRepository entryCommentRepository, IMapper mapper)
        {
            this.entryCommentRepository = entryCommentRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEntryCommentRequest request, CancellationToken cancellationToken)
        {
            var dbEntryComment = mapper.Map<AYDSozluk.Api.Domain.Models.EntryComment>(request);

            await entryCommentRepository.AddAsync(dbEntryComment);

            return dbEntryComment.Id;
        }
    }
}
