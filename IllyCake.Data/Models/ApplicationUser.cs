namespace IllyCake.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser, IDeletableEntity
    {
        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
        
        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
