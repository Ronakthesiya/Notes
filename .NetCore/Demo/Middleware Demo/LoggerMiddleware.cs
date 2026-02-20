namespace Middleware_Demo
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;

        // Constructor
        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("============================================================================");
            // Custom logic before calling the next middleware
            Console.WriteLine("Request incoming: " + context.Request.Path);

            // Call the next middleware in the pipeline
            await _next(context);

            // Custom logic after the next middleware has been called
            Console.WriteLine("Request processed: " + context.Request.Path);
            Console.WriteLine("============================================================================");
        }

    }
}
