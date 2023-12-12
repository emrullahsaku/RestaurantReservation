﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Is_Sistem.Application.Models;

namespace Is_Sistem.API.Filters;

public class ValidateModelAttribute : Attribute, IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState.Values
                .SelectMany(modelState => modelState.Errors)
                .Select(modelError => modelError.ErrorMessage);

            context.Result = new BadRequestObjectResult(ApiResult<string>.Failure(errors));
        }

        await next();
    }
}
