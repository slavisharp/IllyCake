﻿namespace IllyCake.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ImageFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(127)]
        public string Name { get; set; }

        [MaxLength(127)]
        public string Extension { get; set; }

        [MaxLength(127)]
        public string MimeType { get; set; }

        [Required]
        [MaxLength(200)]
        public string Path { get; set; }
        
        [InverseProperty("TumbImage")]
        public virtual ICollection<BlogPost> BlogPostTumbImages { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<Paragraph> ParagraphImages { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<CakeImage> CakeImages { get; set; }
    }
}
