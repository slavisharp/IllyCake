namespace IllyCake.Web.ViewModels.BlogPostViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class BlogPostViewModel : BlogPostListViewModel
    {
        public string MetaDescription { get; set; }

        public string MetaKeywords { get; set; }
        
        public DateTime Published { get; set; }

        public string PublisherName { get; set; }

        public IList<ParagraphViewModel> Paragraphs { get; set; }

        public static Expression<Func<BlogPost, BlogPostViewModel>> ExpressionDetailsFromBlogPost
        {
            get
            {
                return x => new BlogPostViewModel()
                {
                    Id = x.Id,
                    Alias = x.Alias,
                    EmbededVideo = x.EmbedetVideo,
                    ShortDescription = x.ShortDescription,
                    Subtitle = x.Subtitle,
                    Title = x.Title,
                    PublisherName = x.User.FirstName + " " + x.User.LastName,
                    Image = x.ThumbImage != null ? new ImageFileViewModel()
                    {
                        Id = x.ThumbImage.Id,
                        Name = x.ThumbImage.Name,
                        RelativePath = x.ThumbImage.Path
                    } : null,
                    MetaDescription = x.MetaDescription,
                    MetaKeywords = x.MetaKeyWords,
                    Published = x.BlogPostStates.Where(s => s.State == BlogPostStates.Published).FirstOrDefault().DateSet,
                    Paragraphs = x.Paragraphs.OrderBy(p => p.Position).Select(p => new ParagraphViewModel
                    {
                        CssClassList = p.CssClassList,
                        EmbededVideo = p.EmbedVideoHtml,
                        Id = p.Id,
                        LayoutType = p.Type,
                        SpecialContentPosition = p.SpecialContentPosition,
                        Text = p.Text,
                        Image = p.Image != null ? new ImageFileViewModel()
                        {
                            Id = p.Image.Id,
                            Name = p.Image.Name,
                            RelativePath = p.Image.Path
                        } : null
                    }).ToList()
                };
            }
        }
    }
}
