using System;
using Microsoft.Extensions.DependencyInjection;

namespace switcher
{
    public class SwitchableFactory
    {
        private IServiceProvider _sp;
        public SwitchableFactory(IServiceProvider sp)
        {
            _sp = sp;
        }
        public T Create<T>() where T : ISwitchable
        {
            return ActivatorUtilities.CreateInstance<T>(_sp);
        }
    }

}
