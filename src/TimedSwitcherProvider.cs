using System;
using System.Collections.Generic;

namespace switcher
{
    public class TimedSwitcherProvider
    {
        public List<TimeSpan> Ons = new List<TimeSpan>();
        public List<TimeSpan> Offs = new List<TimeSpan>();
        IDateTimeProvider _timer;
        public TimedSwitcherProvider(IDateTimeProvider timer)
        {
            _timer = timer;
        }
        public bool ShouldBeOn()
        {
              return ShouldBeOnProvider(_timer, Ons, Offs);
        }

        public Func<IDateTimeProvider, IEnumerable<TimeSpan>, IEnumerable<TimeSpan>, bool> ShouldBeOnProvider {get;set;}= DefaultShouldBeOnProvider;

        public static Func<IDateTimeProvider, IEnumerable<TimeSpan>, IEnumerable<TimeSpan>, bool> DefaultShouldBeOnProvider =
        (dtp, turnOns, turnOffs)=>
        {
                var now = dtp.UtcNow().TimeOfDay;
                return now.Seconds % 2 == 0;
        };
    }
}
