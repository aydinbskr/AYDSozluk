﻿using AYDSozluk.Api.Domain.Models;
using AYDSozluk.Api.Infrastructure.Persistence.Context;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Api.Infrastructure.Persistence.Repositories
{
    public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
    {
        public EmailConfirmationRepository(AYDSozlukContext dbContext) : base(dbContext)
        {
        }
    }
}
