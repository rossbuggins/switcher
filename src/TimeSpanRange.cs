using System;

namespace switcher
{

    public struct TimeSpanRange
    {
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
