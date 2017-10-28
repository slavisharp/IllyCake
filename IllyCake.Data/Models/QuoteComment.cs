namespace IllyCake.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class QuoteComment : DeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string QuiteId { get; set; }
        public Quote Quote { get; set; }
        
        [Required]
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
