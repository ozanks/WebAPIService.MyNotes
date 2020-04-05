using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyNotes.Entities;
using MyNotes.WebAPIService.Models;

namespace MyNotes.WebAPIService.Filters
{
    public class CategoryExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ServiceResponse<Category> response = new ServiceResponse<Category>
            {
                HasErrors = true,
            };
            response.Errors.Add("Bir hata oluştu: " + context.Exception.Message);
            context.Result = new BadRequestObjectResult(response);

        }
    }
}
