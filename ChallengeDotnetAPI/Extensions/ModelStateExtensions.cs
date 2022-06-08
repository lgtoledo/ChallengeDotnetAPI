using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace ChallengeDotnetAPI.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<String> GetErrorMessages(this ModelStateDictionary modelState)
        {
            // return friendly error messages for ModelState validation errors
            return modelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();
        }
    }
}
