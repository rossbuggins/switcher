using Microsoft.Extensions.Logging;

namespace switcher
{
    public class MyLight : ISwitchable
    {
        public bool IsOn{ get;private set;}
        ILogger<MyLight> _logger;
        public MyLight(ILogger<MyLight> logger)
        {
            _logger = logger; 
        }

        public void On()
        {
            IsOn = true;
            _logger.LogInformation("Turned On");
        }

        public void Off()
        {
            IsOn = false;
            _logger.LogInformation("Turned Off");
        }
    }

}
