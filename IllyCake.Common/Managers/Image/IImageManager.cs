namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;

    public interface IImageManager
    {
        ImageFile AddImage(string relativePath, string fileName, string contentType, long length, byte[] imageBytes);
    }
}
