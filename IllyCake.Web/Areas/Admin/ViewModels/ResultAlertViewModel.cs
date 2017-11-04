namespace IllyCake.Web.Areas.Admin.ViewModels
{
    using System.Collections.Generic;

    public class ResultAlertViewModel
    {
        public ResultAlertViewModel(string success, string error, IEnumerable<string> errors = null)
        {
            this.Error = error;
            this.Errors = errors;
            this.Success = success;
        }

        public string Error { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public string Success { get; set; }
    }
}
