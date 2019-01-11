using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Common.Time
{
    public class SystemClock : ISystemClock
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
