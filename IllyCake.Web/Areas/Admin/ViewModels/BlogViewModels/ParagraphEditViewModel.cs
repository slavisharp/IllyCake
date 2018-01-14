namespace IllyCake.Web.Areas.Admin.ViewModels.BlogViewModels
{
    using IllyCake.Common.Managers;
    using IllyCake.Data.Models;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class ParagraphEditViewModel : IUpdateParagraph
    {
        public ParagraphEditViewModel()
        {
        }

        public ParagraphEditViewModel(Paragraph entity)
        {
            this.Id = entity.Id;
            this.Position = entity.Position;
            this.CssClassList = entity.CssClassList;
            this.EmbedVideoHtml = entity.EmbedVideoHtml;
            this.SpecialContentPosition = entity.SpecialContentPosition;
            this.Text = entity.Text;
            this.ThumbImage = entity.Image != null ? new ImageViewModel()
            {
                Id = entity.Image.Id,
                Name = entity.Image.Name,
                Path = entity.Image.Path
            } : null;
            this.Type = entity.Type;
            this.ThumbImageId = entity.ImageId;
            this.BlogId = entity.BlogPostId;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Tекст")]
        public string Text { get; set; }

        [MaxLength(100)]
        [DisplayName("CSS класове")]
        public string CssClassList { get; set; }

        public ImageViewModel ThumbImage { get; set; }

        [MaxLength(1000)]
        [DisplayName("YouTube видео")]
        public string EmbedVideoHtml { get; set; }

        [Required]
        [DisplayName("Вид секция")]
        public ParagraphType Type { get; set; }

        [Required]
        [DisplayName("Позиция на изображение/видео")]
        public SpecialContentPosition SpecialContentPosition { get; set; }

        [Required]
        public int Position { get; set; }

        public string BlogId { get; set; }

        [DisplayName("Изображение")]
        public int? ThumbImageId { get; set; }

        public static Expression<Func<Paragraph, ParagraphEditViewModel>> ExpressionFromParagraph
        {
            get
            {
                return p => new ParagraphEditViewModel()
                {
                    CssClassList = p.CssClassList,
                    EmbedVideoHtml = p.EmbedVideoHtml,
                    Id = p.Id,
                    Position = p.Position,
                    SpecialContentPosition = p.SpecialContentPosition,
                    Text = p.Text,
                    ThumbImage = p.Image != null ? new ImageViewModel()
                    {
                        Id = p.Image.Id,
                        Name = p.Image.Name,
                        Path = p.Image.Path
                    } : null,
                    Type = p.Type,
                    ThumbImageId = p.ImageId,
                    BlogId = p.BlogPostId
                };
            }
        }
    }
}
