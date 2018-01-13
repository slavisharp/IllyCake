namespace Microsoft.AspNetCore.Mvc.ModelBinding
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ModelStateExtensions
    {
        public static IList<string> GetErrorsList(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
        }
    }
}
