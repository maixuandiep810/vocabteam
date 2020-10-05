using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using vocabteam.Models.Services;

namespace vocabteam.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var user = context.Items["User"];

            if (user != null)
                checkAuthorization(context, userService);

            await _next(context);
        }

        private void checkAuthorization(HttpContext context, IUserService userService)
        {
            try
            {
                var objectName = context.Request.Path.ToString();
                var action = context.Request.Method;
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
