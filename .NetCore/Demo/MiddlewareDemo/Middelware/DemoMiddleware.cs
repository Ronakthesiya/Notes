namespace MiddlewareDemo.Middelware
{
    public class DemoMiddleware
    {
        private RequestDelegate _requestDelegate;

        public DemoMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["StartTime"] = DateTime.UtcNow;

            await _requestDelegate(context);

            TimeSpan diff = DateTime.UtcNow - DateTime.Parse(context.Items["StartTime"].ToString());

            Console.WriteLine(diff);

        }
    }
}
