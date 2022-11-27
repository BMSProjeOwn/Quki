using Microsoft.AspNetCore.Builder;


namespace Middleware.CanonicalURL
{
    public static class CanonicalUrlMiddlewareExtensions{
        public static IApplicationBuilder UseCanonicalUrlMiddleware(this IApplicationBuilder builder, CanonicalURLMiddlewareOptions options)
        {
            return builder.UseMiddleware<CanonicalURLMiddleware>(options);
        }
    }
}