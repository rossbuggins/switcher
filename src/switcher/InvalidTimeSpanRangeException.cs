using System;

namespace switcher
{
    public class InvalidTimeSpanRangeException : Exception
    {
        public TimeSpan Start {get; init;}
         public TimeSpan End {get; init;}
        public InvalidTimeSpanRangeException (TimeSpan start, TimeSpan end)
            : base("Start must be before end.")
        {
            Start = start;
            End = end;
        }
    }
}
