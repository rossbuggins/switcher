using System;
using System.Collections.Generic;
using System.Collections.Immutable;
namespace switcher
{
    public class TimedSwitcherProvider
    {
        private ImmutableHashSet<TimeSpanRange> _onRanges;
        public IEnumerable<TimeSpanRange> OnTimes => _onRanges;

        IDateTimeProvider _timer;

        public IEnumerable<TimeSpanRange> AddOnTime(TimeSpanRange range)
        {
            var ranges = _onRanges;
            var rangesWithRangeAdded = ranges.Add(range);
            _onRanges = rangesWithRangeAdded;
            return rangesWithRangeAdded;
        }

        public IEnumerable<TimeSpanRange> RemoveOnTime(TimeSpanRange range)
        {
            var ranges = _onRanges;
            var rangesWithRangeAdded = ranges.Remove(range);
            _onRanges = rangesWithRangeAdded;
            return rangesWithRangeAdded;
        }

        public TimedSwitcherProvider(IDateTimeProvider timer)
        {
            _onRanges = ImmutableHashSet<TimeSpanRange>.Empty;
            _timer = timer;
        }
        public bool ShouldBeOn()
        {
            return ShouldBeOnProvider(_timer, OnTimes);
        }

        public Func<IDateTimeProvider, IEnumerable<TimeSpanRange>, bool> ShouldBeOnProvider { get; set; } = DefaultShouldBeOnProvider;

        public static Func<IDateTimeProvider, IEnumerable<TimeSpanRange>, bool> DefaultShouldBeOnProvider =
        (dtp, turnOns) =>
        {
            var now = dtp.UtcNow().TimeOfDay;
            foreach (var on in turnOns)
            {
                if (now >= on.Start && now < on.End)
                    return true;
            }
            return false;
        };
    }
}
