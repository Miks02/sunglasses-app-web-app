using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using SunglassesApp.Models;

namespace SunglassesApp.Helpers
{
    public static class Helper
    {

        public static List<SelectListItem> LoadPromotions( IEnumerable<Promotion> promotions)
        {
            return promotions.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name,
            }).ToList();
        }

        public static void LogModelErrors(ModelStateDictionary modelState, ILogger logger, string? userMessage)
        {

            if(userMessage != null) logger.LogWarning(userMessage);
           
            foreach(var key in modelState.Keys)
            {
                var state = modelState[key];
                if (state == null) continue;

                if(state.Errors.Any())
                {
                    logger.LogInformation($"Greška u polju: {key}");
                    foreach(var error in state.Errors)
                    {
                        logger.LogInformation($" - {error}");
                    }
                }
            }

        }
    }
}
