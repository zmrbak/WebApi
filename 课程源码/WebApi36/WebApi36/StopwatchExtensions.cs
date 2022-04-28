namespace WebApi36
{
    public static class StopwatchExtensions
    {
        public static IApplicationBuilder UseStopWatch(this IApplicationBuilder app)
        {
            return app.UseMiddleware<StopwatchMiddleware>();
        }
    }
}
