using Domain.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Persistence.Settings;

namespace Web.Authorization
{
    public class CanvasOptionsManagerAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, CanvasOptions>
    {
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   CanvasOptions resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }



            // Managers can approve or reject.
            if (context.User.IsInRole(Constants.ContactManagersRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
