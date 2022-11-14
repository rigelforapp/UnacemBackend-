namespace UNACEM.API.Authorization
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Linq;
    using UNACEM.Domain;
    using System.Web;

    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;
    using System.Diagnostics;

    /*[AttributeUsage(AttributeTargets.Method | AttributeTargets.All) ]
    public class AuthAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public AuthAttribute(params string[] roles) : base()
        {
            var r = "";
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (Users)context.HttpContext.Items["User"];
            if (user == null)
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (Users)context.HttpContext.Items["User"];
            if (user == null)
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }*/

    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly string _permission;
        public AuthorizeActionFilter()
        {
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            //bool isAuthorized = CheckUserPermission(context.HttpContext.Items["User"], _permission);
            if (context.HttpContext.Items["User"] == null)
            {
                context.Result = new UnauthorizedResult();
            }
            //context.Result = new UnauthorizedResult();
        }
        private bool CheckUserPermission(object user, string permission)
        {
            // Logic for checking the user permission goes here. 

            // Let's assume this user has only read permission.
            return permission == "Read";
        }
    }

    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute()
            : base(typeof(AuthorizeActionFilter))
        {
        }
    }
}
