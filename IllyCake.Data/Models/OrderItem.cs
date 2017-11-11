namespace IllyCake.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrderItem : IAuditInfo, IKeyEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int? ShoppingCartId { get; set; }
        public virtual ShoppingCart GetShoppingCart { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

        [MinLength(2), MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal FinalPrice { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}
