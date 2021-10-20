﻿using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace EVCharging
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Environment.GetEnvironmentVariable("APIKey"));
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("erichb@microsoft.com"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
