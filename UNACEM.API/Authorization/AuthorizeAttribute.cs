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
    }

    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute()
            : base(typeof(AuthorizeActionFilter))
        {
        }
    }
}
