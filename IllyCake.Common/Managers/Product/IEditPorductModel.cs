namespace IllyCake.Common.Managers
{
    using System.Collections.Generic;

    public interface IEditPorductModel : ICreatePorductModel
    {
        int Id { get; set; }
        
        IList<int> GalleryImagesIds { get; set; }
                
        string Description { get; set; }
        
        string MetaDescripton { get; set; }
        
        string MetaKeyWords { get; set; }

        bool ShowOnHomePage { get; set; }
    }
}
