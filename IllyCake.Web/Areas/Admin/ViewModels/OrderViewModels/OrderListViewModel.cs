namespace IllyCake.Web.Areas.Admin.ViewModels.OrderViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Linq.Expressions;

    public class OrderListViewModel
    {
        public string Id { get; set; }

        public string Number { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public OrderStatus Status { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public decimal TotalOrderPrice { get; set; }

        public static Expression<Func<Order, OrderListViewModel>> ExpressionFromOrder
        {
            get
            {
                return x => new OrderListViewModel()
                {
                    Created = x.Created,
                    Modified = x.Modified,
                    Id = x.Id,
                    Number = x.Number,
                    Status = x.Status,
                    TotalOrderPrice = x.TotalOrderPrice,
                    UserEmail = x.User.Email,
                    UserName = x.User.FirstName + " " + x.User.LastName
                };
            }
        }
    }
}
