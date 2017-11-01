namespace IllyCake.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DiscountCoupon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
        
        [Required]
        public int DiscountPercentage { get; set; }

        [InverseProperty("DiscountCoupon")]
        public ICollection<Order> Orders { get; set; }

        [InverseProperty("DiscountCoupon")]
        public ICollection<ProductDiscountCoupon> Products { get; set; }
    }
}
