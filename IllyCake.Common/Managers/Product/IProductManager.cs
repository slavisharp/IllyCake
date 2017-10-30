namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Linq;

    public interface IProductManager
    {
        IQueryable<Product> GetAll();
    }
}
