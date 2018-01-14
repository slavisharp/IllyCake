namespace IllyCake.Common.Managers
{
    using IllyCake.Common.Exeptions;
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class BlogPostManager : IBlogPostManager
    {
        private IRepository<BlogPost> blogsRepository;
        private IRepository<Paragraph> paragraphsRepository;
        private IRepository<BlogPostState> blogStatesRepository;

        public BlogPostManager(IRepository<BlogPost> blogsRepo, IRepository<Paragraph> paragraphsRepo, IRepository<BlogPostState> blogStatesRepo)
        {
            this.blogsRepository = blogsRepo;
            this.paragraphsRepository = paragraphsRepo;
            this.blogStatesRepository = blogStatesRepo;
        }

        public IQueryable<BlogPost> GetAll()
        {
            return this.blogsRepository.All().Where(p => p.IsDeleted == false);
        }

        public async Task<BlogPost> GetById(string id)
        {
            return await this.blogsRepository.GetByIdAsync(id);
        }

        public IQueryable<BlogPost> GetQueryById(string id)
        {
            return this.blogsRepository.All().Where(p => p.Id == id);
        }

        public async Task<BlogPost> CreateBlogPost(ICreateBlogPost model)
        {
            BlogPost post = new BlogPost()
            {
                Alias = model.Alias,
                EmbedetVideo = model.EmbededVideo,
                ShortDescription = model.ShortDescription,
                ThumbImageId = model.ThumbImageId,
                ShowOnHomePage = false,
                LastState = BlogPostStates.Draft,
                UserId = model.CreatorId,
                ViewCount = 0,
                Subtitle = model.Subtitle,
                Title = model.Title
            };

            BlogPostState state = new BlogPostState()
            {
                BlogPost = post,
                DateSet = DateTime.Now,
                State = BlogPostStates.Draft
            };

            await this.blogsRepository.AddAsync(post);
            await this.blogsRepository.SaveAsync();

            await this.blogStatesRepository.AddAsync(state);
            await this.blogStatesRepository.SaveAsync();
            return post;
        }

        public async Task<BlogPost> UpdateBlogPost(IUpdateBlogPost model)
        {
            var post = await this.GetById(model.Id);
            if (post == null)
            {
                throw new EntityNotFoundException("Публикацията не е намерена!");
            }

            post.Alias = model.Alias;
            post.EmbedetVideo = model.EmbededVideo;
            post.MetaDescription = model.MetaDescription;
            post.MetaKeyWords = model.MetaKeyWords;
            post.ShortDescription = model.ShortDescription;
            post.ShowOnHomePage = model.ShowOnHomePage;
            post.Subtitle = model.Subtitle;
            post.ThumbImageId = model.ThumbImageId;
            post.Title = model.Title;
            if (post.LastState != model.State)
            {
                post.LastState = model.State;
                var state = new BlogPostState()
                {
                    BlogPost = post,
                    DateSet = DateTime.Now,
                    State = model.State
                };

                await this.blogStatesRepository.AddAsync(state);
            }

            await this.blogsRepository.SaveAsync();
            return post;
        }

        public async Task<BlogPost> DeleteBlogPost(string id)
        {
            var post = await this.GetById(id);
            if (post == null)
            {
                throw new EntityNotFoundException("Публикацията не е намерена!");
            }

            this.blogsRepository.Delete(post);
            await this.blogsRepository.SaveAsync();
            return post;
        }

        public async Task<Paragraph> GetParagraphById(int id)
        {
            return await this.paragraphsRepository.GetByIdAsync(id);
        }

        public IQueryable<Paragraph> GetParagraphsForBlog(string blogId)
        {
            return this.paragraphsRepository.All().Where(p => p.BlogPostId == blogId);
        }

        public async Task<Paragraph> CreateParagraph(ICreateParagraph model)
        {
            var post = await this.GetById(model.BlogId);
            if (post == null)
            {
                throw new EntityNotFoundException("Публикацията не е намерена!");
            }

            int position = this.paragraphsRepository.All().Where(p => p.BlogPostId == model.BlogId).Count() + 1;
            var paragraph = new Paragraph()
            {
                BlogPost = post,
                BlogPostId = model.BlogId,
                CssClassList = model.CssClassList,
                EmbedVideoHtml = model.EmbedVideoHtml,
                Position = position,
                SpecialContentPosition = model.SpecialContentPosition,
                Type = model.Type,
                Text = model.Text
            };

            await this.paragraphsRepository.AddAsync(paragraph);
            await this.paragraphsRepository.SaveAsync();
            return paragraph;
        }

        public Task MoveParagraph(int id, int delta)
        {
            throw new NotImplementedException();
        }

        public async Task<Paragraph> UpdateParagraph(IUpdateParagraph model)
        {
            var paragraph = await this.paragraphsRepository.GetByIdAsync(model.Id);
            if (paragraph == null)
            {
                throw new EntityNotFoundException("Секцията не е намерена!");
            }

            paragraph.CssClassList = model.CssClassList;
            paragraph.EmbedVideoHtml = model.EmbedVideoHtml;
            paragraph.ImageId = model.ThumbImageId;
            paragraph.SpecialContentPosition = model.SpecialContentPosition;
            paragraph.Text = model.Text;
            paragraph.Type = model.Type;

            await this.paragraphsRepository.SaveAsync();
            return paragraph;
        }

        public async Task<Paragraph> DeleteParagraph(int id)
        {
            var paragaph = await this.GetParagraphById(id);
            if (paragaph == null)
            {
                throw new EntityNotFoundException("Секцията не е намерена!");
            }

            var paragraphsToLower = this.paragraphsRepository.All().Where(p => p.BlogPostId == paragaph.BlogPostId && p.Position > paragaph.Position).ToList();
            foreach (var item in paragraphsToLower)
            {
                item.Position--;
            }

            this.paragraphsRepository.Delete(paragaph);
            await this.paragraphsRepository.SaveAsync();
            return paragaph;
        }

        public async Task<Paragraph> CreateBlankParagraph(string blogId)
        {
            var post = await this.GetById(blogId);
            if (post == null)
            {
                throw new EntityNotFoundException("Публикацията не е намерена!");
            }

            int position = this.paragraphsRepository.All().Where(p => p.BlogPostId == blogId).Count() + 1;
            var paragraph = new Paragraph()
            {
                BlogPost = post,
                BlogPostId = blogId,
                CssClassList = null,
                EmbedVideoHtml = null,
                Position = position,
                SpecialContentPosition = SpecialContentPosition.Left,
                Type = ParagraphType.TextOnly,
                Text = $"Секция {position}"
            };

            await this.paragraphsRepository.AddAsync(paragraph);
            await this.paragraphsRepository.SaveAsync();
            return paragraph;
        }
    }
}
