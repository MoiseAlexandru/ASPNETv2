using ASPNETv2.Models;
using ASPNETv2.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNETv2.Helper.Attributes
{
    public class Authorization : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;
        public Authorization(params Role[] roles)
        {
            _roles = roles;
        }
        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject = new JsonResult(new { Message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            if(_roles == null)
            {
                context.Result = unauthorizedStatusObject;
            }
            var user = (User)context.HttpContext.Items["User"];
            if(user == null || !_roles.Contains(user.Role))
            {
                context.Result = unauthorizedStatusObject;
            }
        }
    }
}
