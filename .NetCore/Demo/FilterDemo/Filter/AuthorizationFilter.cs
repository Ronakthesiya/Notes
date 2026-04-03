using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filter
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine(" ================================================== Authorixation Filter");
            //Console.WriteLine(context.HttpContext.Request.Method);
            //Console.WriteLine(context.ActionDescriptor);
            //Console.WriteLine(context.Filters);
            //Console.WriteLine(context.ModelState.IsValid);
            //Console.WriteLine(context.RouteData.Values);
        }
    }
}
