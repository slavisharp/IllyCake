namespace IllyCake.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cake : DeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }
        
        public string Description { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        public DateTime? Modified { get; set; }

        [InverseProperty("Cake")]
        public virtual ICollection<CakeImage> Images { get; set; }
    }
}
