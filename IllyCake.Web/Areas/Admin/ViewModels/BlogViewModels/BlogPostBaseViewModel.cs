namespace IllyCake.Web.Areas.Admin.ViewModels.BlogViewModels
{
    using IllyCake.Common.Settings;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class BlogPostBaseViewModel
    {
        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [MaxLength(100)]
        [DisplayName("Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [MaxLength(150)]
        [DisplayName("Подзаглавие")]
        public string Subtitle { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [MaxLength(1000)]
        [DisplayName("Кратко описание")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = StaticStringValues.REQUIRED_FIELD)]
        [MaxLength(100)]
        [DisplayName("URL псевдоним")]
        public string Alias { get; set; }

        [DisplayName("YouTube Видео")]
        public string EmbededVideo { get; set; }

        [DisplayName("Главно Изображение")]
        public int? ThumbImageId { get; set; }
    }
}
