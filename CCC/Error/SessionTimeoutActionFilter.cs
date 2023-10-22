using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CCC.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace CCC.UI.Error
{
    public class SessionTimeoutActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var value = context.HttpContext.Session.GetString("UserObject");
            AuthSuccessResponseVM objSessionUser = value == null ? default(AuthSuccessResponseVM) : Newtonsoft.Json.JsonConvert.DeserializeObject<AuthSuccessResponseVM>(value);

            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                var controllerName = controllerActionDescriptor.ControllerName;
                if (controllerName != null &&
                    !controllerName.Equals("Error") &&
                    !controllerName.Equals("Login"))
                {
                    if (objSessionUser == null)
                    {
                        // The session has expired, so redirect to the SessionTimeout action
                        context.Result = new RedirectToActionResult("Index", "Error", null);
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Implement if needed
        }
    }
}
