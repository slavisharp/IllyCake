namespace IllyCake.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    // NOT IN USER FOR NOW
    public class HomePage : IAuditInfo, IKeyEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BackgroundImageId { get; set; }
        public ImageFile BackgroundImage { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        public DateTime? Modified { get; set; }
    }
}
