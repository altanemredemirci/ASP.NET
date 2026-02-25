using System.Reflection.Metadata;

namespace _14_Middleware.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                if(context.Response.StatusCode == 404)
                {
                    await Handle404(context);
                }
                
                else if (context.Response.StatusCode == 401)
                {
                    await Handle401(context);
                }
                
                else if (context.Response.StatusCode == 403)
                {
                    await Handle403(context);
                }

            }

            catch (Exception ex)
            {
                await Handle500(context, ex);
            }
        }

        private async Task Handle404(HttpContext context)
        {
            _logger.LogWarning($"404 - Sayfa Bulunumadı: {context.Request.Path}");

            context.Response.ContentType = "text/html; charset=utf-8";

            var errorHtml = $@"<!DOCTYPE html>
            <html>
            <head>
                <title>404 - Sayfa Bulunamadı</title>
                <style>
                    body {{ font-family: Arial; padding: 50px; text-align: center; background: #f5f5f5; }}
                    .error-box {{ background: white; padding: 40px; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); max-width: 600px; margin: 0 auto; }}
                    h1 {{ color: #ff9800; font-size: 72px; margin: 0; }}
                    h2 {{ color: #333; }}
                    a {{ display: inline-block; margin-top: 20px; padding: 10px 30px; background: #007bff; color: white; text-decoration: none; border-radius: 5px; }}
                    a:hover {{ background: #0056b3; }}
                </style>
            </head>
            <body>
                <div class='error-box'>
                    <h1>🔍 404</h1>
                    <h2>Sayfa Bulunamadı</h2>
                    <p><strong>Aranan Sayfa:</strong> {context.Request.Path}</p>
                    <p>Üzgünüz, aradığınız sayfa mevcut değil.</p>
                    <a href='/'>🏠 Ana Sayfaya Dön</a>
                </div>
            </body>
            </html>
            ";

            await context.Response.WriteAsync(errorHtml);
        }

        private async Task Handle401(HttpContext context)
        {
            _logger.LogWarning($"401 - Yetkisiz Erişim: {context.Request.Path}");

            context.Response.ContentType = "text/html; charset=utf-8";

            var errorHtml = $@"<!DOCTYPE html>
            <html>
            <head>
                <title>401 - Yetkisiz Erişim</title>
                <style>
                    body {{ font-family: Arial; padding: 50px; text-align: center; background: #f5f5f5; }}
                    .error-box {{ background: white; padding: 40px; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); max-width: 600px; margin: 0 auto; }}
                    h1 {{ color: #f44336; font-size: 72px; margin: 0; }}
                    h2 {{ color: #333; }}
                    a {{ display: inline-block; margin: 10px; padding: 10px 30px; background: #007bff; color: white; text-decoration: none; border-radius: 5px; }}
                </style>
            </head>
            <body>
                <div class='error-box'>
                    <h1>🔒 401</h1>
                    <h2>Yetkisiz Erişim</h2>
                    <p>Bu sayfaya erişmek için giriş yapmanız gerekiyor.</p>
                    <a href='/Home/Login'>🔑 Giriş Yap</a>
                    <a href='/'>🏠 Ana Sayfa</a>
                </div>
            </body>
            </html>";

            await context.Response.WriteAsync(errorHtml);
        }

        private async Task Handle403(HttpContext context)
        {
            _logger.LogWarning($"403 - Erişim Yasak: {context.Request.Path}");

            context.Response.ContentType = "text/html; charset=utf-8";

            context.Response.ContentType = "text/html; charset=utf-8";

            var errorHtml = $@"<!DOCTYPE html>
            <html>
            <head>
                <title>403 - Erişim Yasak</title>
                <style>
                    body {{ font-family: Arial; padding: 50px; text-align: center; background: #f5f5f5; }}
                    .error-box {{ background: white; padding: 40px; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); max-width: 600px; margin: 0 auto; }}
                    h1 {{ color: #f44336; font-size: 72px; margin: 0; }}
                    a {{ display: inline-block; margin-top: 20px; padding: 10px 30px; background: #007bff; color: white; text-decoration: none; border-radius: 5px; }}
                </style>
            </head>
            <body>
                <div class='error-box'>
                    <h1>⛔ 403</h1>
                    <h2>Erişim Yasak</h2>
                    <p>Bu sayfaya erişim yetkiniz bulunmuyor.</p>
                    <a href='/'>🏠 Ana Sayfaya Dön</a>
                </div>
            </body>
            </html>";

            await context.Response.WriteAsync(errorHtml);
        }
        
       
        // 500 - Sunucu Hatası (Exception)
        private async Task Handle500(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, $"Hata oluştu: {context.Request.Path}");

            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/html; charset=utf-8";

            var errorHtml = $@"<!DOCTYPE html>
            <html>
            <head>
                <title>Hata Oluştu</title>
                <style>
                    body {{ font-family: Arial; padding: 50px; text-align: center; background: #f5f5f5; }}
                    .error-box {{ background: white; padding: 40px; border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); max-width: 600px; margin: 0 auto; }}
                    h1 {{ color: #f44336; font-size: 72px; margin: 0; }}
                    .details {{ background: #f9f9f9; padding: 15px; border-left: 4px solid #f44336; margin: 20px 0; text-align: left; }}
                    a {{ display: inline-block; margin-top: 20px; padding: 10px 30px; background: #007bff; color: white; text-decoration: none; border-radius: 5px; }}
                </style>
            </head>
            <body>
                <div class='error-box'>
                    <h1>🚨 500</h1>
                    <h2>Bir Hata Oluştu</h2>
                    <div class='details'>
                        <p><strong>Sayfa:</strong> {context.Request.Path}</p>
                        <p><strong>Zaman:</strong> {DateTime.Now:dd.MM.yyyy HH:mm:ss}</p>
                        <p><strong>Hata:</strong> {ex.Message}</p>
                    </div>
                    <a href='/'>🏠 Ana Sayfaya Dön</a>
                </div>
            </body>
            </html>";

            await context.Response.WriteAsync(errorHtml);
        }
    }
}
