namespace IllyCake.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCart : IKeyEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string SessionKey { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
        
        public virtual ICollection<OrderItem> CartItems { get; set; }
    }
}
