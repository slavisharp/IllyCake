namespace IllyCake.Web.ViewModels.ShoppingCartViewModels
{
    using IllyCake.Data.Models;
    using System;
    using System.Linq.Expressions;

    public class ShoppingCartLineItem 
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int OrderItemId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal FinalPrice { get; set; }

        public decimal Subtotal { get; set; }

        public static Expression<Func<OrderItem, ShoppingCartLineItem>> ExpressionFromOrderItem
        {
            get
            {
                return x => new ShoppingCartLineItem()
                {
                    OrderItemId = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Subtotal = x.Subtotal,
                    FinalPrice = x.FinalPrice,
                };
            }
        }
    }
}
