using System;
using switcher;
using Xunit;

namespace tests
{
    public class TimeSpanRangeTests
    {
        [Fact]
        public void CreateFromStartEnd_SuccessfulCreation()
        {
            //arrange
            var start = new TimeSpan(1, 0, 0);
            var end = new TimeSpan(2, 0, 0);

            //act
            var actual = new TimeSpanRange(start, end);

            //assert
            Assert.IsType<TimeSpanRange>(actual);

        }

        [Fact]
        public void CreateFromStartEnd_StartCorrect()
        {
            //arrange
            var start = new TimeSpan(1, 0, 0);
            var end = new TimeSpan(2, 0, 0);
            var range = new TimeSpanRange(start, end);

            //act
            var actual = range.Start;

            //assert
            Assert.Equal(start, actual);
        }

        [Fact]
        public void CreateFromStartEnd_EndCorrect()
        {
            //arrange
            var start = new TimeSpan(1, 0, 0);
            var end = new TimeSpan(2, 0, 0);
            var range = new TimeSpanRange(start, end);

            //act
            var actual = range.End;

            //assert
            Assert.Equal(end, actual);
        }

        [Fact]
        public void CreateFromStartEnd_DurationCorrect()
        {
            //arrange
            var start = new TimeSpan(1, 0, 0);
            var end = new TimeSpan(2, 0, 0);
            var range = new TimeSpanRange(start, end);
            var expected = end.Subtract(start);

            //act
            var actual = range.Duration;

            //assert
            Assert.Equal(expected, actual);
        }

        public void CreateFromStartDuration_EndCorrect()
        {
            //arrange
            var start = new TimeSpan(1, 0, 0);
            var duration = new TimeSpan(3, 0, 0);
            var range = TimeSpanRange.FromDuration(start, duration);
            var expected = start.Add(duration);

            //act
            var actual = range.End;

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateFromEndLaterThanStart_ExceptionThrown()
        {
            //arrange
            var start = new TimeSpan(8, 0, 0);
            var end = new TimeSpan(3, 0, 0);

            //act and assert
            Assert.Throws<InvalidTimeSpanRangeException>(() => new TimeSpanRange(start, end));
        }
    }
}
