﻿using CCC.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCC.API.Filters
{
    public class ValidationFilters : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var errorResponse = new List<ErrorModel>();
                

                foreach (var error in errorsInModelState)
                {
                    foreach (var suberror in error.Value)
                    {
                        var errormodel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = suberror
                        };
                        errorResponse.Add(errormodel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
            await next();

            // after controller
        }
    }
}
