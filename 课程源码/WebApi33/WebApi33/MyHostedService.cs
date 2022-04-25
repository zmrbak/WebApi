namespace WebApi33
{
    public class MyHostedService : IHostedService
    {
        private readonly ILogger<MyHostedService> logger;

        public MyHostedService(ILogger<MyHostedService> logger)
        {
            this.logger = logger;

            logger.LogInformation(DateTime.Now + "\tMyHostedService 构造函数");
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation(DateTime.Now + "\tMyHostedService StartAsync");
            return Task.Factory.StartNew( async () => {
                while (!cancellationToken.IsCancellationRequested)
                {
                    logger.LogInformation(DateTime.Now + "\tMyHostedService ...");
                    try
                    {
                        await Task.Delay(2000, cancellationToken);
                    }
                    catch { }                    
                }
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation(DateTime.Now + "\tMyHostedService StopAsync");
            return Task.CompletedTask;
        }
    }
}
