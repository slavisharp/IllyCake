namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBlogPostManager
    {
        IQueryable<BlogPost> GetAll();

        IQueryable<BlogPost> GetAllPublished();

        Task<BlogPost> GetById(string id);

        IQueryable<BlogPost> GetQueryById(string id);

        IQueryable<BlogPost> GetQueryByAlias(string alias);

        IQueryable<Paragraph> GetParagraphsForBlog(string blogId);

        Task<BlogPost> CreateBlogPost(ICreateBlogPost model);

        Task<BlogPost> UpdateBlogPost(IUpdateBlogPost model);

        Task<BlogPost> DeleteBlogPost(string id);

        Task<Paragraph> CreateParagraph(ICreateParagraph model);

        Task<Paragraph> UpdateParagraph(IUpdateParagraph model);

        Task MoveParagraph(int id, int delta);

        Task<Paragraph> DeleteParagraph(int id);

        Task<Paragraph> CreateBlankParagraph(string blogId);
    }
}
