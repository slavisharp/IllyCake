namespace IllyCake.Web.Services
{
    using IllyCake.Common.Services;
    using System.Threading.Tasks;

    public class EmailService : IEmailService
    {
        private IEmailSender emailSender;
        private IViewRenderService renderService;

        public EmailService(IEmailSender emailSender, IViewRenderService renderService)
        {
            this.emailSender = emailSender;
            this.renderService = renderService;
        }
        
        public async Task SendActionResultEmailAsync(string email, string subject, string viewName, object model)
        {
            var body = await this.renderService.RenderToStringAsync(viewName, model);
            await this.emailSender.SendEmailAsync(email, subject, body);
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            await this.emailSender.SendEmailAsync(email, subject, message);
        }

        public async Task SendEmailConfirmationAsync(string email, string link)
        {
            await this.emailSender.SendEmailConfirmationAsync(email, link);
        }
    }
}
