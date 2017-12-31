namespace IllyCake.Common.Managers
{
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
                Subtitle = model.Subtitle
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

        public Task<BlogPost> UpdateBlogPost(IUpdateBlogPost model)
        {
            throw new NotImplementedException();
        }

        public Task<Paragraph> UpdateParagraph(IUpdateParagraph model)
        {
            throw new NotImplementedException();
        }
    }
}
