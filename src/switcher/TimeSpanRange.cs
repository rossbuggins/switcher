using System;
using System.Collections.Generic;

namespace switcher
{

    public struct TimeSpanRange
    {
        public static bool InRange(TimeSpan time, IEnumerable<TimeSpanRange> ranges)
        {
            foreach (var on in ranges)
            {
                if(InRange(time, on))
                    return true;
            }
            return false;
        }

        public static bool InRange(TimeSpan time, TimeSpanRange range)
        {
            return time >= range.Start && time < range.End;
        }

        public TimeSpan Start {get;init;}
        public TimeSpan End {get;init;}
        public TimeSpan Duration {get;init;}
        

        public TimeSpanRange(TimeSpan start, TimeSpan end)
        {
            this.Start = start;
            this.End = end;
            this.Duration = this.End.Subtract(this.Start);
            ValidateIsEndAfterStart(start,end);
        }

        public static TimeSpanRange FromDuration(TimeSpan start, TimeSpan duration)
        {
            var end = start.Add(duration);
            return new TimeSpanRange(start, end);
        }

        public void ValidateIsEndAfterStart(TimeSpan start, TimeSpan end)
        {
            if(!IsEndAfterStart(start,end))
                throw new InvalidTimeSpanRangeException(start, end);
        }

        public bool IsEndAfterStart(TimeSpan start, TimeSpan end)
        {
            return end>start;
        }
    }
}
