using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MRTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRTestProject.Attributs
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(!context.ModelState.IsValid)
            {
                var errorModelState = context.ModelState.Where(_ => _.Value.Errors.Count > 0)
                    .ToDictionary(_=>_.Key,_=>_.Value.Errors.Select(error=>error.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();
                foreach (var error in errorModelState)
                {
                    foreach (var item in error.Value)
                    {
                        var errorModel = new ErrorModel
                        {
                            Name = error.Key,
                            Message = item
                        };
                        errorResponse.ErrorModels.Add(errorModel);
                    }

                }
                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }

            await next();
        }
    }
}
