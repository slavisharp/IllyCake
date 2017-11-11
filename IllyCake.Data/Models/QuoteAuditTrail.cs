namespace IllyCake.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class QuoteAuditTrail : AuditEntity, IKeyEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string QuoteId { get; set; }
        public virtual Quote Quote { get; set; }
    }
}
