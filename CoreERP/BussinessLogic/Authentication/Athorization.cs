using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CoreERP.BussinessLogic.Authentication
{
    public class Athorization:IAuthorizationRequirement
    {

        public string Permission { get; }

        public Athorization(string permission)
        {
            Permission = permission;
        }
    }

    public class CustomAuthorizationHandler : AuthorizationHandler<Athorization>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Athorization requirement)
        {
            // Check if the user is authenticated
            if (!context.User.Identity.IsAuthenticated)
            {
                return Task.CompletedTask;
            }

            // Check for the specific claim in the JWT token
            var permissionClaim = context.User.Claims.FirstOrDefault(c => c.Type == "Permission" && c.Value == requirement.Permission);

            if (permissionClaim != null)
            {
                context.Succeed(requirement);  // If permission is found, the user is authorized
            }

            return Task.CompletedTask;
        }
    }

    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _permission;

        public CustomAuthorizeAttribute(string permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var requirement = new Athorization(_permission);
            var authorizationService = context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();

            var result = authorizationService.AuthorizeAsync(context.HttpContext.User, null, requirement).Result;

            if (!result.Succeeded)
            {
                context.Result = new ForbidResult();  // If authorization fails, return forbidden
            }
        }
    }
}
