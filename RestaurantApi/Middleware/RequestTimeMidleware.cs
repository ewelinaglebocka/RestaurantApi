using System.Diagnostics;

namespace RestaurantApi.Middleware
{
    public class RequestTimeMidleware : IMiddleware
    {
        private ILogger<RequestTimeMidleware> _logger;
        private Stopwatch _stopwatch;

        public RequestTimeMidleware(ILogger<RequestTimeMidleware> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();

            var elapsedMiliseconds = _stopwatch.ElapsedMilliseconds;

            if (elapsedMiliseconds / 1000 > 4)
            {
                var message = 
                    $"Request [{context.Request.Method}] at {context.Request.Path} took {elapsedMiliseconds} ms";
                _logger.LogInformation(message);
            }
        }
    }
}
