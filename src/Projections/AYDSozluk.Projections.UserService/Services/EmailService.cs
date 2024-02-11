﻿using AYDSozluk.Common.Events.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYDSozluk.Projections.UserService.Services
{
    public class EmailService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<EmailService> logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        public string GenerateConfirmationLink(Guid confirmationId)
        {
            var baseUrl = configuration["ConfirmationLinkBase"] + confirmationId;
            return baseUrl;
        }
        
        public Task SendEmail(string to, string content)
        {
            logger.LogInformation($"Email sent to {to} with content of {content}");
            return Task.CompletedTask;
        }
    }
}
