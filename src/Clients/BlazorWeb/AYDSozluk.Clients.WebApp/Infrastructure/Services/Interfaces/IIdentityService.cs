using AYDSozluk.Common.Models.RequestModels;

namespace AYDSozluk.Clients.WebApp.Infrastructure.Services.Interfaces
{
    public interface IIdentityService
    {
        bool IsLoggedIn { get; }

        string GetUserToken();

        string GetUserName();

        Guid GetUserId();

        Task<bool> Login(LoginUserRequest command);

        void Logout();
    }
}
