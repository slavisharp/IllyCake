﻿namespace IllyCake.Common.Services
{
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailConfirmationAsync(string email, string link);
    }
}
