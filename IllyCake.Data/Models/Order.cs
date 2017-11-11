namespace IllyCake.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order : DeletableEntity, IAuditInfo, IKeyEntity<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public string PrivateNotes { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public decimal TotalItemsPrice { get; set; }

        [Required]
        public decimal ShippingPrice { get; set; }

        [Required]
        public decimal TotalOrderPrice { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public DateTime? DateCompleted { get; set; }
        
        public int? DiscountCouponId { get; set; }
        public virtual DiscountCoupon DiscountCoupon { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<OrderAuditTrail> AuditTrails { get; set; }
    }

    public enum OrderStatus
    {
        [DisplayName("Чакаща")]
        Pending = 1,

        [DisplayName("Приета")]
        Accepted = 2,

        [DisplayName("Изпратена")]
        Shipped = 3,

        [DisplayName("Платена")]
        Paid = 4,

        [DisplayName("Отказана")]
        Cancelled = 5
    }
}
