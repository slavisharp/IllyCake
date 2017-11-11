namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;

    public interface ICreatePorductModel
    {
        string Name { get; set; }
        
        decimal Price { get; set; }
        
        ProductType Type { get; set; }
        
        int CategoryId { get; set; }
        
        int ThumbImageId { get; set; }
    }
}