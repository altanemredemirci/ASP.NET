using System.Diagnostics;

namespace _14_Middleware.Middlewares
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(RequestDelegate next, ILogger<RequestTimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopWatch = Stopwatch.StartNew();
            var requestId = Guid.NewGuid().ToString();

            _logger.LogInformation($"[{requestId}] İstek başladı: {DateTime.Now:HH:mm:ss}");

            // Request başlangıç zamanını kaydet
            context.Items["RequestStartTime"] = DateTime.Now;
            context.Items["RequestId"] = requestId;

            await _next(context);

            stopWatch.Stop();
            var duration = stopWatch.ElapsedMilliseconds;

            // Response header'a süre ekle
            //context.Response.Headers.Add("X-Response-Time", $"{duration}ms");

            _logger.LogInformation($"[{requestId}] İstek tamanlandı: {duration}ms");
        }
    }
}
