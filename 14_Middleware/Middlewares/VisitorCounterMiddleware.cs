namespace _14_Middleware.Middlewares
{
    public class VisitorCounterMiddleware
    {
        private readonly RequestDelegate _next;
        private static int _visitorCount = 0;
        private static readonly object _lock = new object();

        public VisitorCounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value?.ToLower() ?? "";

            if (!path.Contains("favicon.ico") && !Path.HasExtension(path))
            {
                lock (_lock)
                {
                    _visitorCount++;
                }
            }

            context.Items["VisitorCount"] = _visitorCount;

            Console.WriteLine($"Ziyatreçi sayısı:{_visitorCount}");
            await _next(context);
        }


        public static int GetVisitorCount()
        {
            return _visitorCount;
        }
    }

}
