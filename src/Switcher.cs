using System;
using Microsoft.Extensions.Logging;

namespace switcher
{
    public class Switcher
    {
        SwitcherProviderOptions _switcherProvider;

        ILogger<Switcher> _logger;

        public SwitcherProviderOptions SwitchingProvider=>_switcherProvider;

        public Switcher(
            ILogger<Switcher> logger,
            SwitcherProviderOptions options)
        {
        
            _logger = logger;
            _switcherProvider = options;
        }

        public static bool ShouldBeOn(
            Func< bool> shouldBeOnProvider
           )
        {
            return shouldBeOnProvider();
        }

        public bool ShouldBeOn()
        {
            return Switcher.ShouldBeOn(
                _switcherProvider.ShouldBeOnProvider);
        }

        public void Switch()
        {
            SwitchingDecider.Switch(
                ShouldBeOn,
                _switcherProvider.SwitchOnProvider,
                _switcherProvider.SwitchOffProvider);
        }

        public void Switch(Action turnOnProvider, Action turnOffProvider)
        {
            SwitchingDecider.Switch(ShouldBeOn, turnOnProvider, turnOffProvider);
        }

    }
}
