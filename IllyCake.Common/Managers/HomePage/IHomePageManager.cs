namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IHomePageManager
    {
        IRepository<HomePage> Repository { get; }

        IQueryable<HomePage> Search(IHomePageSearchModel search);

        Task<IQueryable<HomePage>> SearchAsync(IHomePageSearchModel search);

        HomePage Create(IHomePageCreateModel input);

        Task<HomePage> CreateAsync(IHomePageCreateModel input);

        HomePage Update(IHomePageUpdateModel input);

        Task<HomePage> UpdateAsync(IHomePageUpdateModel input);

        bool Delete(int id);

        Task<bool> DeleteAsync(int id);
    }
}
