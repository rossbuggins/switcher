using System;
using Microsoft.Extensions.DependencyInjection;

namespace switcher
{
    public class MyLightBuilderFactory
    {
        private IServiceProvider _sp;
        public MyLightBuilderFactory(IServiceProvider sp)
        {
            _sp = sp;
        }
        public MyLightBuilder Create()
        {
            return ActivatorUtilities.CreateInstance<MyLightBuilder>(_sp);
        }
    }

}
