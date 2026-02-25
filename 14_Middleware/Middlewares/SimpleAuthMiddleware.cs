namespace _14_Middleware.Middlewares
{
    public class SimpleAuthMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly List<string> _protectedPaths = new()
        {
            "/home/dashboard",
            "/home/admin",
            "/home/settings"
        };

        public SimpleAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();

            //Korumalı sayfa kontrolü
            if(_protectedPaths.Any(p=> path?.StartsWith(p) == true))
            {
                var isLogggedIn = context.Session.GetString("IsLoggedIn");

                if (isLogggedIn != "true")
                {
                    //Giriş yapmamışsa AccessDenied'a yönlendir
                    context.Response.Redirect("/Home/AccessDenied");
                    return;
                }
            }

            await _next(context);

        }
    }
}
