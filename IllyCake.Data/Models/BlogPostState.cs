namespace IllyCake.Data.Models
{
    using System;
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
        Draft = 1,
        Published = 2,
        Archived = 3
    }
}
