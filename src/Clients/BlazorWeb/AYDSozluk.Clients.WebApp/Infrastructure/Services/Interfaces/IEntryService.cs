using AYDSozluk.Common.Models.Page;
using AYDSozluk.Common.Models.RequestModels;
using AYDSozluk.Common.Models.ResponseModels;

namespace AYDSozluk.Clients.WebApp.Infrastructure.Services.Interfaces
{
    public interface IEntryService
    {
        Task<List<GetEntriesResponse>> GetEntires();

        Task<GetEntryDetailResponse> GetEntryDetail(Guid entryId);

        Task<PagedResponse<GetEntryDetailResponse>> GetMainPageEntries(int page, int pageSize);

        Task<PagedResponse<GetEntryDetailResponse>> GetProfilePageEntries(int page, int pageSize, string userName = null);

        Task<PagedResponse<GetEntryCommentsResponse>> GetEntryComments(Guid entryId, int page, int pageSize);


        Task<Guid> CreateEntry(CreateEntryRequest command);

        Task<Guid> CreateEntryComment(CreateEntryCommentRequest command);

        Task<List<SearchEntryResponse>> SearchBySubject(string searchText);

    }
}
