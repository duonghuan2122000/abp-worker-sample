using Quartz;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.BackgroundWorkers.Quartz;

namespace Sora.AbpWorkerSample
{
    public class Worker : QuartzBackgroundWorkerBase
    {
        public Worker()
        {
            JobDetail = JobBuilder.Create<Worker>().WithIdentity(nameof(Worker)).Build();
            Trigger = TriggerBuilder.Create().WithIdentity(nameof(Worker)).StartNow()
                .Build();
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            Logger.LogDebug("Worker-Start");
            Task.Factory.StartNew(async () =>
            {
                int i = 0;
                while (true)
                {
                    Logger.LogDebug($"Worker - {i++}");
                    await Task.Delay(1000);
                }
            }, TaskCreationOptions.LongRunning);
        }
    }
}