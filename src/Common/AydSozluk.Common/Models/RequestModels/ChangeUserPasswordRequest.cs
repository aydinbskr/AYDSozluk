using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Models.RequestModels
{
    public class ChangeUserPasswordRequest : IRequest<bool>
    {
        public Guid? UserId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public ChangeUserPasswordRequest(Guid? userId, string oldPassword, string newPassword)
        {
            UserId = userId;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }
    }
}
