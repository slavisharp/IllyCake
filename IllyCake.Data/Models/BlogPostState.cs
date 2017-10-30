namespace IllyCake.Data.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class BlogPostState
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public BlogPostStates State { get; set; }

        [Required]
        public DateTime DateSet { get; set; }

        [Required]
        public int BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }
    }

    public enum BlogPostStates
    {
        [DisplayName("Чернова")]
        Draft = 1,

        [DisplayName("Публикуван")]
        Published = 2,

        [DisplayName("Архивиран")]
        Archived = 3
    }
}
