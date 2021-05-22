using System;

namespace switcher
{
    public class DeterministicDateTimeProvider : IDateTimeProvider
    {
        public Func<DateTime> Time = () =>
        {
            throw new NotImplementedException("Set Time property before use.");
        };

        public DateTime UtcNow()
        {
            return Time();
        }
    }


}
