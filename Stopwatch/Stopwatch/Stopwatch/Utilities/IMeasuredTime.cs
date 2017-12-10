using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Utilities
{
    interface IMeasuredTime
    {
        bool isTimeUnitChanged { get;  }

        int GetHours(TimeSpan? measuredTime);

        int GetMinutes(TimeSpan? measuredTime);

        int GetSeconds(TimeSpan? measuredTime);
    }
}
