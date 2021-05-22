using System;
using System.Collections.Generic;
using System.Collections.Immutable;
namespace switcher
{
    public class TimedSwitcherProvider
    {
        public static Func<IDateTimeProvider, IEnumerable<TimeSpanRange>, bool> DefaultShouldBeOnProvider =
        (dtp, turnOns) =>
        {
            var now = dtp.UtcNow().TimeOfDay;
            return TimeSpanRange.InRange(now, turnOns);
        };

        private readonly IDateTimeProvider _timer;
        private ImmutableHashSet<TimeSpanRange> _onRanges;
        public IEnumerable<TimeSpanRange> OnTimes => _onRanges;
        public Func<IDateTimeProvider, IEnumerable<TimeSpanRange>, bool> ShouldBeOnProvider { get; set; } = DefaultShouldBeOnProvider;

        public TimedSwitcherProvider(IDateTimeProvider timer)
        {
            _onRanges = ImmutableHashSet<TimeSpanRange>.Empty;
            _timer = timer;
        }

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

        public bool ShouldBeOn()
        {
            return ShouldBeOnProvider(_timer, OnTimes);
        }
    }
}
