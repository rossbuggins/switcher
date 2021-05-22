using System;
using Microsoft.Extensions.DependencyInjection;

namespace switcher
{
    public static class SwitchProviderExtensionMethods
    {
        public static IServiceCollection AddSwitchProvider(
            this IServiceCollection services,
            Action<SwitcherProviderOptions> options)
        {
            var optionsValues = new SwitcherProviderOptions();
            options(optionsValues);
            services.AddTransient<TimedSwitcherProvider>();
            services.AddTransient<MyLightWiringFactory>();
            services.AddTransient<MyLight>();
            services.AddTransient<MyTimerLightWiring>();
            services.AddTransient<Switcher>(
                (sp) =>
                {
                    return ActivatorUtilities.CreateInstance<Switcher>(sp, optionsValues);
                }
            );
            return services;
        }
    }
}
