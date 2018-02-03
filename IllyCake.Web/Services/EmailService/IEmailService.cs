namespace IllyCake.Web.Services
{
    using System.Threading.Tasks;

    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailConfirmationAsync(string email, string link);

        Task SendActionResultEmailAsync(string email, string subject, string view, object model);
    }
}
