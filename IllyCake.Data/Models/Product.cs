﻿namespace IllyCake.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product : DeletableEntity, IAuditInfo, IKeyEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(2), MaxLength(200)]
        public string Alias { get; set; }

        [Required]
        [MinLength(2), MaxLength(10)]
        public string SKUCode { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [MaxLength(160)]
        public string MetaDescription { get; set; }

        [MaxLength(200)]
        public string MetaKeyWords { get; set; }

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

        [Required]
        public int ThumbImageId { get; set; }
        public virtual ImageFile ThumbImage { get; set; }
                
        [InverseProperty("Product")]
        public virtual ICollection<ProductImage> Images { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        
        [InverseProperty("Product")]
        public virtual ICollection<ProductDiscountCoupon> DiscountCoupons { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<ProductVersion> ProductVersions { get; set; }
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
