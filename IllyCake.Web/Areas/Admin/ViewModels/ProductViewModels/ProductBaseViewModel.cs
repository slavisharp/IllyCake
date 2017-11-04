namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Data.Models;
    using System;

    public class ProductBaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductType Type { get; set; }

        public string Category { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int OrderedCount { get; set; }
    }
}
