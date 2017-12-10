using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Model
{
    interface IStopwathModel
    {
        bool Running { get; }
        TimeSpan? Elapsed { get; }
        TimeSpan? LapTime { get; }
        event EventHandler<LapWasDoneEvent> LapTimeUpdated;

        void Start();
        void Stop();
        void Reset();
        void Lap();
    }
}
