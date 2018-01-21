namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using System.Linq;

    public class HomePageManager : IHomePageManager
    {
        private IRepository<Product> productsRepository;
        private IRepository<BlogPost> blogsRepository;

        public HomePageManager(IRepository<Product> productsRepo, IRepository<BlogPost> blogsRepo)
        {
            this.productsRepository = productsRepo;
            this.blogsRepository = blogsRepo;
        }

        public IQueryable<BlogPost> HomePageBlogsQuery()
        {
            return this.blogsRepository.All().Where(p => !p.IsDeleted && p.LastState == BlogPostStates.Published && p.ShowOnHomePage);
        }

        public IQueryable<Product> HomePageProductsQuery()
        {
            return this.productsRepository.All().Where(p => !p.IsDeleted && p.ShowOnHomePage);
        }
    }
}
