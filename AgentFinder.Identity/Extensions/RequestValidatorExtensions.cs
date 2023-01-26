using Microsoft.AspNetCore.Builder;

namespace AgentFinder.Identity.Extensions
{
    public static class RequestValidatorExtensions
    {
        // Extensions method to simplify RequestValidatorMiddleware usage 
        public static IApplicationBuilder UseRequestValidator(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestValidatorMiddleware>();
        }
    }
}
