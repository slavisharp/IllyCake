namespace IllyCake.Common.Services
{
    using IllyCake.Common.Settings;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    public class EmailSender : IEmailSender
    {
        private EmailSettings settings;
        private IConfiguration configuration;

        public EmailSender(AppSettings settings, IConfiguration config)
        {
            this.settings = settings.EmailSettings;
            this.configuration = config;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MailMessage mailMessage = CongfigureEmail(email, subject, message);
            using (SmtpClient smtp = new SmtpClient(this.settings.PrimaryDomain, this.settings.PrimaryPort))
            {
                var pass = this.configuration["EmailPass"];
                smtp.Credentials = new NetworkCredential(this.settings.UsernameEmail, this.configuration["EmailPass"]);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mailMessage);
            }
        }

        public async Task SendEmailConfirmationAsync(string email, string link)
        {
            await SendEmailAsync(email, "Confirm your email", $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }

        private MailMessage CongfigureEmail(string email, string subject, string message)
        {
            var msg = new MailMessage(this.settings.From, email);
            msg.IsBodyHtml = true;
            msg.Body = message;
            msg.Subject = subject;
            foreach (string cc in this.settings.CCList)
            {
                msg.CC.Add(cc);
            }

            return msg;
        }
    }
}
