using System.Threading;

internal class BackgroundWorkerService : BackgroundService
{
    readonly ILogger<BackgroundWorkerService> _logger;

    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger)
    {
        _logger = logger;
    }

    // This will prevent Swagger from starting
    //public async Task StartAsync(CancellationToken cancellationToken)
    //{
    //    _logger.LogInformation("Service started");

    //    while (!cancellationToken.IsCancellationRequested)
    //    {
    //        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
    //        await Task.Delay(1000, cancellationToken);
    //    }

    //}


    // This will run in the background of the application, is implemented from BackgroundService
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}