using ASPNETv2.Helper.JwtUtils;
using ASPNETv2.Services.UserService;

namespace ASPNETv2.Helper.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;
        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            _nextRequestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if(userId != Guid.Empty)
            {
                httpContext.Items["User"] = userService.GetById(userId);
            }
            await _nextRequestDelegate(httpContext);
        }

    }
}
