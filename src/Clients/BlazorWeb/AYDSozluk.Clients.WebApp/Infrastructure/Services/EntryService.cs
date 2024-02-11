using AYDSozluk.Clients.WebApp.Infrastructure.Services.Interfaces;
using AYDSozluk.Common.Models.Page;
using AYDSozluk.Common.Models.RequestModels;
using AYDSozluk.Common.Models.ResponseModels;
using System.Net.Http.Json;

namespace AYDSozluk.Clients.WebApp.Infrastructure.Services
{
    public class EntryService : IEntryService
    {
        private readonly HttpClient client;

        public EntryService(HttpClient client)
        {
            this.client = client;
        }


        public async Task<List<GetEntriesResponse>> GetEntires()
        {
            var result = await client.GetFromJsonAsync<List<GetEntriesResponse>>("/api/entry?todaysEnties=false&count=30");

            return result;
        }

        public async Task<GetEntryDetailResponse> GetEntryDetail(Guid entryId)
        {
            var result = await client.GetFromJsonAsync<GetEntryDetailResponse>($"/api/entry/{entryId}");

            return result;
        }

        public async Task<PagedResponse<GetEntryDetailResponse>> GetMainPageEntries(int page, int pageSize)
        {
            var result = await client.GetFromJsonAsync<PagedResponse<GetEntryDetailResponse>>($"/api/entry/mainpageentries?page={page}&pageSize={pageSize}");

            return result;
        }

        public async Task<PagedResponse<GetEntryDetailResponse>> GetProfilePageEntries(int page, int pageSize, string userName = null)
        {
            var result = await client.GetFromJsonAsync<PagedResponse<GetEntryDetailResponse>>($"/api/entry/UserEntries?userName={userName}&page={page}&pageSize={pageSize}");

            return result;
        }

        public async Task<PagedResponse<GetEntryCommentsResponse>> GetEntryComments(Guid entryId, int page, int pageSize)
        {
            var result = await client.GetFromJsonAsync<PagedResponse<GetEntryCommentsResponse>>($"/api/entry/comments/{entryId}?page={page}&pageSize={pageSize}");

            return result;
        }


        public async Task<Guid> CreateEntry(CreateEntryRequest command)
        {
            var res = await client.PostAsJsonAsync("/api/Entry/CreateEntry", command);

            if (!res.IsSuccessStatusCode)
                return Guid.Empty;

            var guidStr = await res.Content.ReadAsStringAsync();

            return new Guid(guidStr.Trim('"'));
        }

        public async Task<Guid> CreateEntryComment(CreateEntryCommentRequest command)
        {
            var res = await client.PostAsJsonAsync("/api/Entry/CreateEntryComment", command);

            if (!res.IsSuccessStatusCode)
                return Guid.Empty;

            var guidStr = await res.Content.ReadAsStringAsync();

            return new Guid(guidStr.Trim('"'));
        }

        public async Task<List<SearchEntryResponse>> SearchBySubject(string searchText)
        {
            var result = await client.GetFromJsonAsync<List<SearchEntryResponse>>($"/api/entry/Search?searchText={searchText}");

            return result;
        }
    }
}
