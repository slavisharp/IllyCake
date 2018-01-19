namespace IllyCake.Data.Models
{
    using System.ComponentModel;
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
        [Display(Name = "Само текст")]
        TextOnly = 1,
        [Display(Name = "С изображение")]
        WithImage = 2,
        [Display(Name = "С видео")]
        WithVideo = 3,
        [Display(Name = "Само изображение")]
        ImageOnly = 4,
        [Display(Name = "Само видео")]
        VideoOnly = 5
    }

    public enum SpecialContentPosition
    {
        [Display(Name = "В ляво")]
        Left = 1,
        [Display(Name = "В дясно")]
        Right = 2,
        [Display(Name = "В средата")]
        Center = 3
    }
}
