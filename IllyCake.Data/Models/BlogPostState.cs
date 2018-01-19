namespace IllyCake.Data.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class BlogPostState : IKeyEntity<int>
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
        [Display(Name = "Чернова")]
        Draft = 1,

        [Display(Name = "Публикуван")]
        Published = 2,

        [Display(Name = "Архивиран")]
        Archived = 3
    }
}
