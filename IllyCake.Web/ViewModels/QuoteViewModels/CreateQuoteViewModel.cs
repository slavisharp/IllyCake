namespace IllyCake.Web.ViewModels.QuoteViewModels
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;

    public class CreateQuoteViewModel
    {
        public string Description { get; set; }

        public IEnumerable<int> Images { get; set; }
    }
}
