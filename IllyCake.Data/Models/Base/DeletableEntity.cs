namespace IllyCake.Data.Models
{
    using System;

    public class DeletableEntity : IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
