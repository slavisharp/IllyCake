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

        public Task<Paragraph> CreateParagraph(ICreateParagraph model)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost> DeleteBlogPost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Paragraph> DeleteParagraph(int id)
        {
            throw new NotImplementedException();
        }

        public Task MoveParagraph(int id, int delta)
        {
            throw new NotImplementedException();
        }

        public async Task<BlogPost> UpdateBlogPost(IUpdateBlogPost model)
        {
            var post = await this.GetById(model.Id);
            if (post == null)
            {
                throw new EntityNotFoundException("");
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

        public Task<Paragraph> UpdateParagraph(IUpdateParagraph model)
        {
            throw new NotImplementedException();
        }
    }
}
