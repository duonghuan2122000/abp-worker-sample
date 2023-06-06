using Quartz;
using Volo.Abp.BackgroundWorkers.Quartz;

namespace Sora.AbpWorkerSample
{
    public class BackgroundWorkerQuartzSample : QuartzBackgroundWorkerBase
    {
        public BackgroundWorkerQuartzSample()
        {
            JobDetail = JobBuilder.Create<BackgroundWorkerQuartzSample>().WithIdentity(nameof(BackgroundWorkerQuartzSample)).Build();
            Trigger = TriggerBuilder.Create().WithIdentity(nameof(BackgroundWorkerQuartzSample)).StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever()).Build();
        }

        public override async Task Execute(IJobExecutionContext context)
        {
            Logger.LogDebug("AbpWorkerSample-Executed");
        }
    }
}