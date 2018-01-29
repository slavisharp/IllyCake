namespace IllyCake.Web.ViewModels.BlogPostViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Linq.Expressions;

    public class BlogPostListViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Alias { get; set; }

        public string Subtitle { get; set; }

        public string ShortDescription { get; set; }

        public string EmbededVideo { get; set; }

        public ImageFileViewModel Image { get; set; }
        
        // Runtime
        public string PositionClass { get; set; }

        public static Expression<Func<BlogPost, BlogPostListViewModel>> ExpressionFromBlogPost
        {
            get
            {
                return x => new BlogPostListViewModel()
                {
                    Id = x.Id,
                    Alias = x.Alias,
                    EmbededVideo = x.EmbedetVideo,
                    ShortDescription = x.ShortDescription,
                    Subtitle = x.Subtitle,
                    Title = x.Title,
                    Image = x.ThumbImage != null ? new ImageFileViewModel()
                    {
                        Id = x.ThumbImage.Id,
                        Name = x.ThumbImage.Name,
                        RelativePath = x.ThumbImage.Path
                    } : null
                };
            }
        }
    }
}
