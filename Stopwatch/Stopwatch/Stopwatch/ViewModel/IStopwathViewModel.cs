using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.ViewModel
{
    interface IStopwathViewModel
    {
        bool Running { get; }

        int LastHours { get; }

        int LastMinutes { get; }

        decimal LastSeconds { get; }

        int LapHours { get; }

        int LapMinutes { get; }

        decimal LapSeconds { get; }

        void Start();

        void Stop();

        void Reset();

        void Lap();
    }
}
