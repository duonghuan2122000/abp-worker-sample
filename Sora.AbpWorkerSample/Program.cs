using Serilog;
using Volo.Abp;

namespace Sora.AbpWorkerSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            IHost host = Host.CreateDefaultBuilder(args)
                .UseAutofac()
                .ConfigureServices(services =>
                {
                    services.AddApplication<AbpWorkerSampleModule>(options =>
                    {
                        options.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
                    });

                    services.AddHostedService<DefaultWorker>();
                })
                .Build();

            host.Services.GetRequiredService<IAbpApplicationWithExternalServiceProvider>().Initialize(host.Services);

            host.Run();
        }
    }
}