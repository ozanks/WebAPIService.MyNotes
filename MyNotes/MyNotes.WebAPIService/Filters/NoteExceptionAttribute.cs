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
    public class NoteExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ServiceResponse<Note> response = new ServiceResponse<Note>
            {
                HasErrors = true,
            };
            response.Errors.Add("Bir hata oluştu: "+context.Exception.Message);
            context.Result = new BadRequestObjectResult(response);

        }
    }
}
