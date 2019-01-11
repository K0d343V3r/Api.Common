using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Common.Time
{
    public interface ISystemClock
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
