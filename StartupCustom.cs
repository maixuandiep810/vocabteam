using Microsoft.AspNetCore.Builder;
using vocabteam.Middlewares;

namespace vocabteam
{
    public static class StartupCustom
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtMiddleware>();
            return app;
        }

        public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<AuthorizationMiddleware>();
            return app;
        }
    }
}