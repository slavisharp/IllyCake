namespace IllyCake.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationUser : IdentityUser, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
