using System;
using System.Drawing;

namespace switcher
{
    public class MyLightBuilder
    {
        private MyLightOptions _options;
        private readonly SwitchableFactory _factory;
        public MyLightBuilder(SwitchableFactory factory)
        {
            _factory = factory;

        }

        public MyLightBuilder Create()
        {
            _options = new MyLightOptions();
            return this;
        }

        public MyLightBuilder Color(Color color)
        {
            _options.Colour = color;
            return this;
        }

        public MyLight Build()
        {
            return Build(_options);
        }

        public MyLight Build(Action<MyLightOptions> optionsProvider)
        {
            return Build(_options, optionsProvider);
        }

        public MyLight Build(MyLightOptions options)
        {
            return Build(options, (o) => { });
        }

        

        public MyLight Build(MyLightOptions options, Action<MyLightOptions> optionsProvider)
        {
            var light = _factory.Create<MyLight>();
            optionsProvider(options);
            light.Color = options.Colour;
            return light;
        }
    }

}
