namespace IllyCake.Common.Managers
{
    public interface ICreatePorductCategoryModel
    {
        string Name { get; set; }

        string Alias { get; set; }

        bool ShowOnHomePage { get; set; }
    }
}
