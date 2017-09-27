namespace IllyCake.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HomePage : DeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(80)]
        public string Title { get; set; }

        [Required]
        [MinLength(3), MaxLength(160)]
        public string SubTitle { get; set; }

        [Required]
        public int MainImageId { get; set; }
        public ImageFile MainImage { get; set; }

        [Required]
        public DateTime Created { get; set; }


        public DateTime? Modified { get; set; }
    }
}
