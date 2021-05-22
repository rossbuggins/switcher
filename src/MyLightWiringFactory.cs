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
        public MyLightWiring Create()
        {
            return ActivatorUtilities.CreateInstance<MyLightWiring>(_sp);
        }

    }

}
