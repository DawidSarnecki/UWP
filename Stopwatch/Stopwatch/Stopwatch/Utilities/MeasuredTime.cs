using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Utilities
{
    class MeasuredTime : IMeasuredTime
    {
        private int _hours;

        private int _minutes;

        private int _seconds;

        public int GetHours(TimeSpan? measuredTime)
        {
            return measuredTime.HasValue ? measuredTime.Value.Hours : 0;
        }

        public int GetMinutes(TimeSpan? measuredTime)
        {
            return measuredTime.HasValue ? measuredTime.Value.Minutes : 0;
        }

        public int GetSeconds(TimeSpan? measuredTime)
        {
            return measuredTime.HasValue ? measuredTime.Value.Seconds : 0;
        }

        public bool isTimeUnitChanged => throw new NotImplementedException();

        public MeasuredTime()
        {
            _hours = 0;
            _minutes = 0;
            _seconds = 0;
        }

    }
}
