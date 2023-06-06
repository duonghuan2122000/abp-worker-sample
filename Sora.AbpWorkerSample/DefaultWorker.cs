using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.DependencyInjection;

namespace Sora.AbpWorkerSample
{
    public class DefaultWorker : BackgroundService
    {
        public IAbpLazyServiceProvider LazyServiceProvider { get; set; }

        protected ILoggerFactory LoggerFactory => LazyServiceProvider.LazyGetRequiredService<ILoggerFactory>();
        protected ILogger Logger => LazyServiceProvider.LazyGetService<ILogger>(provider => LoggerFactory?.CreateLogger(GetType().FullName) ?? NullLogger.Instance);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogDebug("DefaultWorker-Start");

            Task.Factory.StartNew(async () =>
            {
                int i = 0;
                while (true)
                {
                    Logger.LogDebug($"DefaultWorker - {i++}");
                    await Task.Delay(1000);
                }
            }, TaskCreationOptions.LongRunning);
        }
    }
}