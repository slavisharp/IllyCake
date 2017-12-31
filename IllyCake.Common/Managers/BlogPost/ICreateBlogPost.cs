namespace IllyCake.Common.Managers
{
    public interface ICreateBlogPost
    {
        string Title { get; set; }

        string Subtitle { get; set; }

        string ShortDescription { get; set; }

        string Alias { get; set; }

        string EmbededVideo { get; set; }

        int? ThumbImageId { get; set; }

        string CreatorId { get; set; }
    }
}
