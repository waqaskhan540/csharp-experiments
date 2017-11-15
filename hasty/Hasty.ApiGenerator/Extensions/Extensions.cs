
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hasty.ApiGenerator.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddHasty(this IServiceCollection services)
        {
            
            return services;
        }

        public static void UseHastyApi<T>(this IApplicationBuilder app) where T : class
        {
            app.UseMiddleware<Middleware<T>>();
        }
        public static string GetEntityName(this string value)
        {
            var result = value.Trim('/').Substring(value.LastIndexOf('/'));
             result = char.ToUpper(result[0]) + result.Substring(1);
            return result;
                  
        }
    }
}
