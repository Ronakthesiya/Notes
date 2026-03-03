using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filter
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("======================== Aciton Executed");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("======================== Aciton Executing");
        }
    }
}
