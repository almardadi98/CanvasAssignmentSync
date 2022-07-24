using Domain.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Persistence.Settings;

namespace Web.Authorization
{
    public class CanvasOptionsAdministratorsAuthorizationHandler
                    : AuthorizationHandler<OperationAuthorizationRequirement, CanvasOptions>
    {
        protected override Task HandleRequirementAsync(
                                              AuthorizationHandlerContext context,
                                    OperationAuthorizationRequirement requirement,
                                              CanvasOptions resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.ContactAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
