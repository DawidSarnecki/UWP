using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Model
{
    class LapWasDoneEvent : EventArgs
    {
        public TimeSpan? LapTime { get;  private set; }
        public LapWasDoneEvent(TimeSpan? lapTime)
        {
            LapTime = lapTime;
        }
    }
}
