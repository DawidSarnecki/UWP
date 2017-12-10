using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.ViewModel
{
    using Stopwatch.Utilities;

    interface IStopwathViewModel
    {
        bool Running { get; }

        int LastHours { get; }

        int LastMinutes { get; }

        int LastSeconds { get; }

        int LapHours { get; }

        int LapMinutes { get; }

        int LapSeconds { get; }

        void Start();

        void Stop();

        void Reset();

        void Lap();
    }
}
