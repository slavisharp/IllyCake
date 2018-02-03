namespace IllyCake.Web.Areas.Admin.ViewModels.HomeViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class EmailViewModel
    {
        [Required]
        public string RecieverEmail { get; set; }

        [Required]
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
