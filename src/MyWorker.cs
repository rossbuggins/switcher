using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace switcher
{
    public class MyWorker : BackgroundService
    {
        List<Switcher> switchers = new List<Switcher>();

        MyLightWiringFactory _factory;
        public MyWorker(MyLightWiringFactory factory)
        {
            _factory = factory;
        }
     
        public void Work()
        {
            var x = _factory.Create();
            x.Enable();
            switchers.Add(x.Switcher);

        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Work();
            return base.StartAsync(cancellationToken);
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                foreach(var sw in switchers)
                {
                    sw.Switch();
                    await Task.Yield();
                }
                await Task.Delay(TimeSpan.FromSeconds(1),stoppingToken);
            }
        }
    }
}
