using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Drawing;

namespace switcher
{
    public class MyWorker : BackgroundService
    {
        private readonly Switchers _switchers;
        private readonly MyLightWiringFactory _factory;
        private readonly SwitchableFactory _switchableFactory;
        private ILogger<MyWorker> _logger;

        private readonly MyLightBuilderFactory _lightBuilder;
        public MyWorker(
            MyLightWiringFactory factory,
            SwitchableFactory switchableFactory,
             ILogger<MyWorker> logger,
             MyLightBuilderFactory lightBuilder)
        {
            _switchers = new Switchers();
            _lightBuilder = lightBuilder;
            _switchableFactory = switchableFactory;
            _factory = factory;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            SetupRequiredLights();
            return base.StartAsync(cancellationToken);
        }

        private void SetupRequiredLights()
        {
            var x = _factory.Create<MyTimerLightWiring>();
            x.Timer.AddOnTime(new TimeSpanRange(TimeSpan.Zero, new TimeSpan(1, 59, 59)));
            _switchers.Add(x.Switcher);

            x.Switcher.CorrelationId = "Single switch";

            var multi = _factory.Create<MultiSwitch>();
            multi.Switcher.CorrelationId = "Multi switch switcher";
            var light1 =_lightBuilder.Create().Create().Build((o)=>
            {
                o.Colour = Color.Red;
            });

            var light2 = _lightBuilder.Create().Create().Build((o)=>
            {
                o.Colour = Color.Blue;
            });

            multi.Lights.Add(light1);
            multi.Lights.Add(light2);
            _switchers.Add(multi.Switcher);

            multi.Switcher.SwitchingProvider.ShouldBeOnProvider = () =>
            {
                return true;
            };// x.Timer.ShouldBeOn;


            multi.Enable();

            var whatItShouldBe = x.Timer.ShouldBeOnProvider;

            //This is showing the customisability of the system, its overriding 
            //default behaviour in a functional way.
            x.Timer.ShouldBeOnProvider = (p, o) =>
            {
                var onRulesCount = o.Count();
                var shouldBeRule = whatItShouldBe(p, o);
                var n = p.UtcNow().TimeOfDay;
                var state = n.Seconds % 2 == 0;
                _logger.LogInformation("There are {ruleCount} rules with a result of {plannedResult} but I'm ignoring them and setting the switch to what I want which is {state}.", onRulesCount, shouldBeRule, state);
                return state;
            };

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