using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Filter
{
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("======================= Result Executed");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("======================= Result Executing");
        }
    }
}
