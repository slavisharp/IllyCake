namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBlogPostManager
    {
        IQueryable<BlogPost> GetAll();

        Task<BlogPost> GetById(string id);

        IQueryable<BlogPost> GetQueryById(string id);

        Task<BlogPost> CreateBlogPost(ICreateBlogPost model);

        Task<BlogPost> UpdateBlogPost(IUpdateBlogPost model);

        Task<BlogPost> DeleteBlogPost(int id);

        Task<Paragraph> CreateParagraph(ICreateParagraph model);

        Task<Paragraph> UpdateParagraph(IUpdateParagraph model);

        Task MoveParagraph(int id, int delta);

        Task<Paragraph> DeleteParagraph(int id);
    }
}
