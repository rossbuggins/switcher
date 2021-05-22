using System;
using Microsoft.Extensions.DependencyInjection;


namespace switcher
{
    public class MyLightWiringFactory
    {
        private IServiceProvider _sp;
        public MyLightWiringFactory(IServiceProvider sp)
        {
            _sp = sp;
        }
        public T Create<T>() where T: IWiring
        {
            return ActivatorUtilities.CreateInstance<T>(_sp);
        }

    }

}
