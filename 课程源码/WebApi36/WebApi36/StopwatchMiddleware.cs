using System.Diagnostics;

namespace WebApi36
{
    public class StopwatchMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<StopwatchMiddleware> logger;

        public StopwatchMiddleware(RequestDelegate next,ILogger<StopwatchMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            await next(httpContext);

            stopWatch.Stop();
            logger.LogInformation("执行时间:\t"+stopWatch.ElapsedTicks);
        }
    }
}
