namespace IllyCake.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderAuditTrail : AuditEntity, IKeyEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
