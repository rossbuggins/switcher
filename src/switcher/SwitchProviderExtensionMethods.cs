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
            services.AddTransient<MyLightBuilderFactory>();
            services.AddTransient<MyLightBuilder>();
            services.AddTransient<TimedSwitcherProvider>();
            services.AddTransient<SwitchableFactory>();
            services.AddTransient<MyLightWiringFactory>();
            services.AddTransient<MyLight>();
            services.AddTransient<MyTimerLightWiring>();
            services.AddTransient<Switcher>(
                (sp) =>
                {
                    var optionsValues = new SwitcherProviderOptions();
                    options(optionsValues);
                    return ActivatorUtilities.CreateInstance<Switcher>(sp, optionsValues);
                }
            );
            return services;
        }
    }
}
