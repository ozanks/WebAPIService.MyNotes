using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyNotes.Entities;
using MyNotes.WebAPIService.Models;
using System.Linq;

namespace MyNotes.WebAPIService.Filters
{
    public class CategoryValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ServiceResponse<Category> response = new ServiceResponse<Category>
                {
                    Errors = context.ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList(),
                    HasErrors = true
                };
                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
