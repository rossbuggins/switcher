using Microsoft.Extensions.Logging;

namespace switcher
{
    public class MyLight : ISwitchable
    {
        ILogger<MyLight> _logger;
        public MyLight(ILogger<MyLight> logger)
        {
            _logger = logger; 
        }

        public void On()
        {
            _logger.LogInformation("Turned On");
        }

        public void Off()
        {
            _logger.LogInformation("Turned Off");
        }
    }

}
