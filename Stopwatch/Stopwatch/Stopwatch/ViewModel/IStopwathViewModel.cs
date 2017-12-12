using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stopwatch.ViewModel
{
    interface IStopwathViewModel
    {
        bool Running { get; }

        ICommand Start { get; }

        ICommand Stop { get; }

        ICommand Reset { get; }

        ICommand Lap { get; }

        int LastHours { get; }

        int LastMinutes { get; }

        decimal LastSeconds { get; }

        int LapHours { get; }

        int LapMinutes { get; }

        decimal LapSeconds { get; }
    }
}
