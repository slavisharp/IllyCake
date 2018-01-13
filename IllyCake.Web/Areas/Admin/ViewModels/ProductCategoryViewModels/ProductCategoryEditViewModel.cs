namespace IllyCake.Web.Areas.Admin.ViewModels.ProductCategoryViewModels
{
    using IllyCake.Common.Managers;
    using System.ComponentModel.DataAnnotations;

    public class ProductCategoryEditViewModel : ProductCategoryCreateViewModel, IEditPorductCategoryModel
    {
        [Required]
        public int Id { get; set; }
    }
}
