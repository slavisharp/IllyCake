namespace IllyCake.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Paragraph : IKeyEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int? ImageId { get; set; }
        public virtual ImageFile Image { get; set; }
        
        [MaxLength(1000)]
        public string VideoUrl { get; set; }

        [Required]
        public ParagraphType Type { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public string BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }
    }

    public enum ParagraphType
    {
        Default = 1,
        WithImage = 2,
        WithVideo = 3
    }
}
