using CargoApi.Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CargoApi.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                var errorMessages = errors.SelectMany(e => e.Value).ToList();

                // TODO : Log the validation errors if necessary verificar el metodo
                context.Result = new BadRequestObjectResult(
                    ApiResponse.ValidationErrorResponse(errorMessages, "Validation failed")
                );
                return;
            }

            await next();
        }
    }
}