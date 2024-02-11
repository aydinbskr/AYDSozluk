using AYDSozluk.Clients.WebApp.Infrastructure.Services.Interfaces;
using AYDSozluk.Common.Infrastructure.Exceptions;
using AYDSozluk.Common.Infrastructure.Results;
using AYDSozluk.Common.Models.RequestModels;
using AYDSozluk.Common.Models.ResponseModels;
using System.Net.Http.Json;
using System.Text.Json;

namespace AYDSozluk.Clients.WebApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;

        public UserService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<UserDetailResponse> GetUserDetail(Guid? id)
        {
            var userDetail = await client.GetFromJsonAsync<UserDetailResponse>($"/api/user/{id}");

            return userDetail;
        }

        public async Task<UserDetailResponse> GetUserDetail(string userName)
        {
            var userDetail = await client.GetFromJsonAsync<UserDetailResponse>($"/api/user/username/{userName}");

            return userDetail;
        }

        public async Task<bool> UpdateUser(UserDetailResponse user)
        {
            var res = await client.PostAsJsonAsync($"/api/user/update", user);

            return res.IsSuccessStatusCode;
        }

        public async Task<bool> ChangeUserPassword(string oldPassword, string newPassword)
        {
            var command = new ChangeUserPasswordRequest(null, oldPassword, newPassword);
            var httpResponse = await client.PostAsJsonAsync($"/api/User/ChangePassword", command);

            if (httpResponse != null && !httpResponse.IsSuccessStatusCode)
            {
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseStr = await httpResponse.Content.ReadAsStringAsync();
                    var validation = JsonSerializer.Deserialize<ValidationResponseModel>(responseStr, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    responseStr = validation.FlattenErrors;
                    throw new DatabaseValidationException(responseStr);
                }

                return false;
            }

            return httpResponse.IsSuccessStatusCode;
        }
    }
}
