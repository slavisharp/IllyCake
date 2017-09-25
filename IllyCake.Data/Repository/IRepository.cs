namespace IllyCake.Data.Repository
{
    using System.Linq;

    public interface IRepository<T>
        where T: class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}
