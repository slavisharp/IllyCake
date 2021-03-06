﻿namespace IllyCake.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser : IdentityUser, IDeletableEntity, IKeyEntity<string>
    {
        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
        
        public virtual ICollection<Quote> Quotes { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public virtual ICollection<ApplicationUserAddress> Addresses { get; set; }
    }
}
