using AYDSozluk.Common.Models.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Models.RequestModels
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public LoginUserRequest(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }

        public LoginUserRequest()
        {

        }
    }
}
