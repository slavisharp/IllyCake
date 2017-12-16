namespace IllyCake.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address : DeletableEntity, IAuditInfo, IKeyEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(100)]
        public string Region { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(500)]
        public string Line1 { get; set; }

        [MaxLength(500)]
        public string Line2 { get; set; }

        [Required]
        [MaxLength(200)]
        public string ContactName { get; set; }

        [Required]
        [Phone]
        [MaxLength(50)]
        public string Phonenumber { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public DateTime? LastUsedInOrder { get; set; }
        
        public virtual ICollection<ApplicationUserAddress> Users { get; set; }

        [InverseProperty("Address")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
