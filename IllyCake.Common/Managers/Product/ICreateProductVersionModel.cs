namespace IllyCake.Common.Managers
{
    public interface ICreateProductVersionModel
    {
        string Name { get; set; }
        
        decimal Price { get; set; }
        
        int ProductId { get; set; }
    }
}
