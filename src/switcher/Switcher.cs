using System;
using Microsoft.Extensions.Logging;

namespace switcher
{
    public class Switcher
    {
        public string CorrelationId{get;set;}
        public Guid SwitcherId {get;} = Guid.NewGuid();
        private readonly SwitcherProviderOptions _switcherProvider;
        private readonly ILogger<Switcher> _logger;
        public SwitcherProviderOptions SwitchingProvider => _switcherProvider;

        public Switcher(
            ILogger<Switcher> logger,
            SwitcherProviderOptions options)
        {
            _logger = logger;
            _switcherProvider = options;
        }

        public bool ShouldBeOn()
        {
            return _switcherProvider.ShouldBeOnProvider();
        }

        public void SwitchOn()
        {
             _switcherProvider.SwitchOnProvider();
        }

        public void SwitchOff()
        {
            _switcherProvider.SwitchOffProvider();
        }

        public void SwitchIfNeeded()
        {
            SwitchIfNeeded(SwitchOn, SwitchOff);
        }

        public void SwitchIfNeeded(
            Action turnOnProvider, 
            Action turnOffProvider)
        {
            SwitchIfNeeded(ShouldBeOn, turnOnProvider, turnOffProvider);
        }

        public static void SwitchIfNeeded(
            Func<bool> shouldBeOn, 
            Action turnOnProvider, 
            Action turnOffProvider)
        {
            SwitchingDecider.Switch(shouldBeOn, turnOnProvider, turnOffProvider);
        }
    }
}
