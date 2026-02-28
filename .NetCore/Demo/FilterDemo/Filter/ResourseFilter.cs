using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filter
{
    public class ResourseFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("========================================== Resource Executed");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("========================================== Resource Executing");

        }
    }
}
