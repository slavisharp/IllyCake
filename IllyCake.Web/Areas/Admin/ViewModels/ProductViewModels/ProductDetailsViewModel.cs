namespace IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductDetailsViewModel : ProductBaseViewModel, IEditPorductModel
    {
        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        public int CategoryId { get; set; }
        
        public int ThumbImageId { get; set; }

        public ImageViewModel ThumbImage { get; set; }
        
        public IEnumerable<ImageViewModel> GalleryImages { get; set; }

        public IEnumerable<ProductVersionViewModel> ProductVersions { get; set; }
        
        [DisplayName("Oписание")]
        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        public string Description { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [DisplayName("Мета описание")]
        [MaxLength(160, ErrorMessage = "Полето не трябва да е по-дълго от 160 символа")]
        public string MetaDescripton { get; set; }

        [DisplayName("Мета ключови думи")]
        [MaxLength(200, ErrorMessage = "Полето не трябва да е по-дълго от 200 символа")]
        public string MetaKeyWords { get; set; }

        public static Expression<Func<Product, ProductDetailsViewModel>> ExpressionFromProduct
        {
            get
            {
                return x => new ProductDetailsViewModel()
                {
                    CategoryName = x.Category.Name,
                    CategoryId = x.CategoryId,
                    Created = x.Created,
                    Modified = x.Modified,
                    Alias = x.Alias,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    ShowOnHomePage = x.ShowOnHomePage,
                    Type = x.Type,
                    Description = x.Description,
                    MetaDescripton = x.MetaDescription,
                    MetaKeyWords = x.MetaKeyWords,
                    SKUCode = x.SKUCode,
                    OrderedCount = x.OrderItems.Where(i => i.OrderId != null).Sum(i => i.Quantity),
                    ThumbImage = new ImageViewModel() { Id = x.ThumbImageId, Name = x.ThumbImage.Name, Path = x.ThumbImage.Path },
                    GalleryImages = x.Images.Select(i => new ImageViewModel()
                    {
                        Id = i.ImageId,
                        Name = i.Image.Name,
                        Path = i.Image.Path
                    }), //.Select(ImageViewModel.FuncFromProductImage),
                    ProductVersions = x.ProductVersions.Where(pv => !pv.IsDeleted).Select(pv => new ProductVersionViewModel()
                    {
                        Id = pv.Id,
                        Name = pv.Name,
                        Price = pv.Price
                    }), //.Select(ProductVersionViewModel.FuncFromProductVersion),
                };
            }
        }
    }
}
