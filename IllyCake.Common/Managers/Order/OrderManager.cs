namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;

    public class OrderManager : IOrderManager
    {
        private IRepository<Order> repository;

        public OrderManager(IRepository<Order> repo)
        {
            this.repository = repo;
        }
    }
}
