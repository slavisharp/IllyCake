namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IHomePageManager
    {
        IRepository<HomePage> Repository { get; }

        IQueryable<HomePage> Search(ISearchModel search);

        Task<IQueryable<HomePage>> SearchAsync(ISearchModel search);

        HomePage Create(ICreateModel input);

        Task<HomePage> CreateAsync(ICreateModel input);

        HomePage Update(IUpdateModel input);

        Task<HomePage> UpdateAsync(IUpdateModel input);

        bool Delete(int id);

        Task<bool> DeleteAsync(int id);
    }
}
