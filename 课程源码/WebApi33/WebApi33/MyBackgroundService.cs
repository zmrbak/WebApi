namespace WebApi33
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly ILogger<MyBackgroundService> logger;

        public MyBackgroundService(ILogger<MyBackgroundService> logger)
        {
            this.logger = logger;
            logger.LogInformation(DateTime.Now + "\tMyBackgroundService 构造函数");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation(DateTime.Now + "\tMyBackgroundService StartAsync");
            await Task.Factory.StartNew(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    logger.LogInformation(DateTime.Now + "\tMyBackgroundService ...");
                    try
                    {
                        await Task.Delay(2000, stoppingToken);
                    }
                    catch { }
                }
            }, stoppingToken);
        }
    }
}
