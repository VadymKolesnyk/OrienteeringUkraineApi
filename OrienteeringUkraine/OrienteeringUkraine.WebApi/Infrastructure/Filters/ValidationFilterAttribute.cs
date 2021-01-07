using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrienteeringUkraine.WebApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrienteeringUkraine.WebApi.Infrastructure.Filters
{
    public class ValidationFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                                                .Where(kvp => kvp.Value.Errors.Count > 0)
                                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage));

                var errorResponse = new ErrorResponse();
                foreach (var error in errorsInModelState)
                {
                    foreach (var errorMessage in error.Value)
                    {
                        errorResponse.Errors.Add(new ErrorModel { FieldName = error.Key, Message = errorMessage });
                    }
                }
                context.Result = new BadRequestObjectResult(errorResponse);
            }
            else
            {
                await next();
            }
        }
    }
}
