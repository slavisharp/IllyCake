namespace IllyCake.Web.Areas.Admin.ViewModels.BlogViewModels
{
    using IllyCake.Common.Managers;
    using IllyCake.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class BlogPostEditViewModel : BlogPostCreateViewModel, IUpdateBlogPost
    {
        [Required]
        public string Id { get; set; }

        [DisplayName("Статус")]
        public BlogPostStates LastState { get; set; }

        [DisplayName("Създател")]
        public string CreatorName { get; set; }

        [DisplayName("Създател")]
        public string Email { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        [Required]
        [DisplayName("На начален екран")]
        public bool ShowOnHomePage { get; set; }

        [Required]
        public BlogPostStates State { get; set; }

        [MaxLength(160)]
        [DisplayName("Мета описание")]
        public string MetaDescription { get; set; }

        [MaxLength(200)]
        [DisplayName("Мета ключови думи")]
        public string MetaKeyWords { get; set; }

        public IEnumerable<ParagraphEditViewModel> Paragraphs { get; set; }

        public static Expression<Func<BlogPost, BlogPostEditViewModel>> ExpressionFromBlogPost
        {
            get
            {
                return x => new BlogPostEditViewModel()
                {
                    Created = x.Created,
                    Modified = x.Modified,
                    Id = x.Id,
                    CreatorName = x.User.FirstName + " " + x.User.LastName,
                    Email = x.User.Email,
                    Alias = x.Alias,
                    EmbededVideo = x.EmbedetVideo,
                    LastState = x.LastState,
                    ShortDescription = x.ShortDescription,
                    Subtitle = x.Subtitle,
                    ThumbImageId = x.ThumbImageId,
                    Title = x.Title,
                    ImageUrl = x.ThumbImage.Path,
                    CreatorId = x.UserId,
                    ShowOnHomePage = x.ShowOnHomePage,
                    Paragraphs = x.Paragraphs.Select(p => new ParagraphEditViewModel()
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
                    }).OrderBy(p => p.Position)
                };
            }
        }
    }
}
