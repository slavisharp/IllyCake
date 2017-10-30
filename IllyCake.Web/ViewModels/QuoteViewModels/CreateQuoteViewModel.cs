namespace IllyCake.Web.ViewModels.QuoteViewModels
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateQuoteViewModel
    {
        public string UserId { get; set; }

        [Required]
        public string Description { get; set; }

        public IEnumerable<int> Images { get; set; }
    }
}
