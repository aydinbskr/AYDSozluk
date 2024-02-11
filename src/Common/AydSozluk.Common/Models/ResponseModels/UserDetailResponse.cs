﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Common.Models.ResponseModels
{
    public class UserDetailResponse
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public bool EmailConfirmed { get; set; }
    }
}
