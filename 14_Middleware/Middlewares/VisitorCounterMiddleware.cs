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
            // Her istek için sayacı artır
            lock (_lock)
            {
                _visitorCount++;
            }

            // Visitor count'u HttpContext'e ekle
            context.Items["VisitorCount"] = _visitorCount;

            // Console'a yazdır (debug için)
            Console.WriteLine($"🔢 Ziyaretçi Sayısı: {_visitorCount}");

            await _next(context);
        }

        public static int GetVisitorCount()
        {
            return _visitorCount;
        }
    }
}
