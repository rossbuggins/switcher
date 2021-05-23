using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace switcher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await SetUp();
        }

        static async Task SetUp()
        {
            await Host.CreateDefaultBuilder()
                .ConfigureServices((services) =>
                {
                    services.AddHostedService<MyWorker>();
                    services.AddTransient<IDateTimeProvider, DateTimeProvider>();
                    services.AddSwitchProvider(
                        (switchP) =>
                        {
                            
                        });
                }).RunConsoleAsync();
        }
    }

}
