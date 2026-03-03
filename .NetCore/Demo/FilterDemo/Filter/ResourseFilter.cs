using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filter
{
    public class ResourseFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // context.HttpContext;
            // context.ActionDescriptor
            // context.ModelState
            // context.Exception
            // context.Canceled
            // context.RouteData
            // context.Filters
            // context.ExceptionHandled
            // context.Result
            Console.WriteLine("========================================== Resource Executed");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("========================================== Resource Executing");

        }
    }
}
