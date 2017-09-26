﻿namespace IllyCake.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BlogPost : DeletableEntity, IAuditInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public string Subtitle { get; set; }

        [Required]
        public int TumbImageId { get; set; }
        public virtual ImageFile TumbImage { get; set; }

        [Required]
        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int ViewCount { get; set; }
    }
}