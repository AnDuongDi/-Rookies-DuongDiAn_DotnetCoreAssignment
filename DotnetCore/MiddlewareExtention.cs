using Microsoft.AspNetCore.Builder;

namespace DotnetCore
{
    public static class MiddlewareExtention
    {
        public static IApplicationBuilder UseLogInMiddleware(this IApplicationBuilder builder){
            return builder.UseMiddleware<LogInMiddleware>();
        }
    }
}