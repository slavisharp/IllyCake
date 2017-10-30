namespace IllyCake.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product : DeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public ProductType Type { get; set; }

        [Required]
        public bool ShowOnHomePage { get; set; } 

        [Required]
        public DateTime Created { get; set; }
        
        public DateTime? Modified { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
                
        [InverseProperty("Product")]
        public virtual ICollection<ProductImage> Images { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

    public enum ProductType
    {
        [DisplayName("Торта")]
        Cake = 1,

        [DisplayName("Мъфин")]
        Muffin = 2,

        [DisplayName("Опаковка")]
        Package = 3
    }
}
