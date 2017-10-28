namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using System;
    using System.Threading.Tasks;
    using System.Linq;

    public class HomePageManager : IHomePageManager
    {
        private IRepository<HomePage> repository;

        public HomePageManager(IRepository<HomePage> repo)
        {
            this.repository = repo;
        }

        public IRepository<HomePage> Repository => this.repository;

        public HomePage Create(IHomePageCreateModel input)
        {
            throw new NotImplementedException();
        }

        public Task<HomePage> CreateAsync(IHomePageCreateModel input)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<HomePage> Search(IHomePageSearchModel search)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<HomePage>> SearchAsync(IHomePageSearchModel search)
        {
            throw new NotImplementedException();
        }

        public HomePage Update(IHomePageUpdateModel input)
        {
            throw new NotImplementedException();
        }

        public Task<HomePage> UpdateAsync(IHomePageUpdateModel input)
        {
            throw new NotImplementedException();
        }
    }
}
