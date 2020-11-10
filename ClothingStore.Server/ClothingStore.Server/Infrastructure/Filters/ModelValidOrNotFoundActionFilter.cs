namespace ClothingStore.Server.Infrastructure.Filters
{
    using Infrastructure.Services;

    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    
    public class ModelValidOrNotFoundActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Result errors = false;
                errors.Error = new List<Error>();

                var errorMessages = context.ModelState.Values.SelectMany(x => x.Errors).ToList();
                foreach (var error in errorMessages)
                {
                    errors.Error.Add(new Error
                    {
                        Description = error.ErrorMessage
                    });
                }

                context.Result = new BadRequestObjectResult(errors);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult result)
            {
                var model = result.Value;

                if (model == null)
                {
                    Result err = "Object is not found.";
                    context.Result = new NotFoundObjectResult(err);
                }
            }
        }
    }
}
