namespace IllyCake.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductCategory : DeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
