namespace IllyCake.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Paragraph : IKeyEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [MaxLength(100)]
        public string CssClassList { get; set; }

        public int? ImageId { get; set; }
        public virtual ImageFile Image { get; set; }
        
        [MaxLength(1000)]
        public string EmbedVideoHtml { get; set; }

        [Required]
        public ParagraphType Type { get; set; }

        [Required]
        public SpecialContentPosition SpecialContentPosition { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public string BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }
    }

    public enum ParagraphType
    {
        TextOnly = 1,
        WithImage = 2,
        WithVideo = 3
    }

    public enum SpecialContentPosition
    {
        Left = 1,
        Right = 2,
        Center = 3
    }
}
