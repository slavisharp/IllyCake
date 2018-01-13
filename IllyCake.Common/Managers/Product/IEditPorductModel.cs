namespace IllyCake.Common.Managers
{
    public interface IEditPorductModel : ICreatePorductModel
    {
        int Id { get; set; }
        
        string Description { get; set; }
        
        string MetaDescripton { get; set; }
        
        string MetaKeyWords { get; set; }

        bool ShowOnHomePage { get; set; }
    }
}
