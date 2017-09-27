namespace IllyCake.Web.Services
{
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using IllyCake.Common.Services;

    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email", $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
