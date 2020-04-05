using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyNotes.Entities;
using MyNotes.WebAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.WebAPIService.Filters
{
    public class NoteValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ServiceResponse<Note> response = new ServiceResponse<Note>
                {
                    Errors = context.ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList(),
                    HasErrors = true
                };
                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
