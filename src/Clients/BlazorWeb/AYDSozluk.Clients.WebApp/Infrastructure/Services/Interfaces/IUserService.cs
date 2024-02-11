using AYDSozluk.Common.Models.ResponseModels;

namespace AYDSozluk.Clients.WebApp.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailResponse> GetUserDetail(Guid? id);
        Task<UserDetailResponse> GetUserDetail(string userName);

        Task<bool> UpdateUser(UserDetailResponse user);

        Task<bool> ChangeUserPassword(string oldPassword, string newPassword);
    }
}
