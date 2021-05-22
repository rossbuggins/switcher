using System;
using Microsoft.Extensions.Logging;

namespace switcher
{
    public class Switcher
    {
        SwitcherProviderOptions _switcherProvider;
        ILogger<Switcher> _logger;

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

        public void SwitchIfNeeded()
        {
            SwitchIfNeeded(
                _switcherProvider.SwitchOnProvider,
                _switcherProvider.SwitchOffProvider);
        }

        public void SwitchIfNeeded(Action turnOnProvider, Action turnOffProvider)
        {
            SwitchingDecider.Switch(ShouldBeOn, turnOnProvider, turnOffProvider);
        }
    }
}
