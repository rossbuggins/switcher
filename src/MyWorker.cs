using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace switcher
{
    public class MyWorker : BackgroundService
    {
        private readonly Switchers _switchers;
        private readonly MyLightWiringFactory _factory;

        public MyWorker(MyLightWiringFactory factory)
        {
            _switchers = new Switchers();
            _factory = factory;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            SetupRequiredLights();
            return base.StartAsync(cancellationToken);
        }

        private void SetupRequiredLights()
        {
            var x = _factory.Create<MyTimerLightWiring>();
            x.Timer.AddOnTime(new TimeSpanRange(TimeSpan.Zero, new TimeSpan(23,59,59)));
            _switchers.Add(x.Switcher);
            x.Enable();
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ExecuteIterationAsync(stoppingToken);
            }
        }

        private async Task ExecuteIterationAsync(CancellationToken stoppingToken)
        {
            await _switchers.SwitchIfNeededAsync(stoppingToken);
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}