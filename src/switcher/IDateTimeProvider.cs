using System;

namespace switcher
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow();
    }
}
