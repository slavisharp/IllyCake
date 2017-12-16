namespace IllyCake.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BlogPost : DeletableEntity, IAuditInfo, IKeyEntity<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Subtitle { get; set; }

        [Required]
        public int ThumbImageId { get; set; }
        public virtual ImageFile ThumbImage { get; set; }

        [MaxLength(1000)]
        public string VideoUrl { get; set; }

        [Required]
        [MaxLength(1000)]
        public string ShortDescription { get; set; }

        [Required]
        public bool ShowOnHomePage { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        [Required]
        public BlogPostStates LastState { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int ViewCount { get; set; }

        [MaxLength(160)]
        public string MetaDescription { get; set; }

        [MaxLength(200)]
        public string MetaKeyWords { get; set; }
    }
}
