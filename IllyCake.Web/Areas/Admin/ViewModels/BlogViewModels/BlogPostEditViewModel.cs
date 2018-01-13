namespace IllyCake.Web.Areas.Admin.ViewModels.BlogViewModels
{
    using IllyCake.Common.Managers;
    using IllyCake.Data.Models;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
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
        public bool ShowOnHomePage { get; set; }

        [Required]
        public BlogPostStates State { get; set; }

        [MaxLength(160)]
        public string MetaDescription { get; set; }

        [MaxLength(200)]
        public string MetaKeyWords { get; set; }

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
                    CreatorId = x.UserId
                };
            }
        }
    }
}
