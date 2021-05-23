using System.Drawing;
using Microsoft.Extensions.Logging;

namespace switcher
{

    public class MyLight : ISwitchable
    {
        public Color Color {get;set;}
        public bool IsOn { get; private set; }
        ILogger<MyLight> _logger;
        public MyLight(ILogger<MyLight> logger)
        {
            _logger = logger;
            Color = Color.White;
        }

        public void On()
        {
           SetState(true);
        }

        public void Off()
        {
            SetState(false);
        }

        public void SetState(bool newState)
        {
            var oldState = IsOn;
            IsOn = newState;
            _logger.LogInformation("Turned {newState} from {oldState} {colour}",
                oldState ? "on":"off",
                newState ? "on":"off",
                Color);
        }
    }

}
