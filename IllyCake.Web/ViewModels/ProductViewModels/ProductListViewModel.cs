namespace IllyCake.Web.ViewModels.ProductViewModels
{
    using IllyCake.Data.Models;

    public class ProductListViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string Title { get; set; }

        public ProductType Type { get; set; }

        public string Alias { get; set; }

        public string SKUCode { get; set; }

        public decimal Price { get; set; }

        public ImageFileViewModel Image { get; set; }


    }
}
