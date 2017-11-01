namespace IllyCake.Data.Models
{
    using System;
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

        [Required]
        [MinLength(5), MaxLength(127)]
        public string GuidName { get; set; }

        [MaxLength(127)]
        public string Extension { get; set; }

        [MaxLength(127)]
        public string MimeType { get; set; }

        [Required]
        [MaxLength(200)]
        public string Path { get; set; }

        [Required]
        public DateTime UploadedDate { get; set; }
        
        [InverseProperty("ThumbImage")]
        public virtual ICollection<BlogPost> BlogPosts { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<Paragraph> Paragraphs { get; set; }

        [InverseProperty("ThumbImage")]
        public virtual ICollection<Product> ProductThumbImages { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<QuoteImage> QuoteImages { get; set; }

        [InverseProperty("BackgroundImage")]
        public virtual ICollection<HomePage> HomePages { get; set; }
    }
}
