namespace IllyCake.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Quote : DeletableEntity, IAuditInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        [Required]
        public string Description { get; set; }

        public string PrivateNotes { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public decimal? Price { get; set; }
        
        public QuoteStatus Status { get; set; }

        public DateTime? DateCompleted { get; set; }

        [InverseProperty("Quote")]
        public virtual ICollection<QuoteImage> Images { get; set; }

        [InverseProperty("Quote")]
        public virtual ICollection<QuoteAuditTrail> AuditTrails { get; set; }
    }

    public enum QuoteStatus
    {
        Quoted = 1,
        Accepted = 2,
        Finished = 3,
        Shipped = 4,
        Payed = 5
    }
}
