using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stopwatch.Utilities;
using System.ComponentModel;

namespace Stopwatch.ViewModel
{
    using Stopwatch.Model;
    using Windows.UI.Xaml;

    public class StopwatchViewModel : IStopwathViewModel, INotifyPropertyChanged
    {
        private IStopwathModel _stopwathModel;

        private DispatcherTimer _timer;

        private int _lastHours;

        private int _lasMinutes;

        private int _lastSeconds;

        private int _lapHours;

        private int _lapMinutes;

        private int _lapSeconds;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Running => _stopwathModel.Running;

        public int LastHours => GetHours(_stopwathModel.Elapsed);

        public int LastMinutes => GetMinutes(_stopwathModel.Elapsed);

        public int LastSeconds => GetSeconds(_stopwathModel.Elapsed);

        public int LapHours => GetHours(_stopwathModel.LapTime);

        public int LapMinutes => GetMinutes(_stopwathModel.LapTime);

        public int LapSeconds => GetSeconds(_stopwathModel.LapTime);

        public StopwatchViewModel()
        {
            _stopwathModel = new StopwatchModel();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += TimerTick;
            _timer.Start();

            _stopwathModel.LapTimeUpdated += LapTimeUpdated;
        }

        private void TimerTick(object sender, object e)
        {
            if (_lastHours != LastHours)
            {
                _lastHours = LastHours;
                OnPropertyChanged(nameof(LastHours));
            }

            if (_lasMinutes != LastMinutes)
            {
                _lasMinutes = LastMinutes;
                OnPropertyChanged(nameof(LastMinutes));
            }

            if (_lastSeconds != LastSeconds)
            {
                _lastSeconds = LastSeconds;
                OnPropertyChanged(nameof(LastSeconds));
            }
        }

        private void LapTimeUpdated(object sender, LapWasDoneEvent e)
        {
            if (_lapHours != LapHours)
            {
                _lapHours = LapHours;
                OnPropertyChanged(nameof(LapHours));
            }

            if (_lapMinutes != LapMinutes)
            {
                _lasMinutes = LapMinutes;
                OnPropertyChanged(nameof(LapMinutes));
            }

            if (_lapSeconds != LapSeconds)
            {
                _lapSeconds = LapSeconds;
                OnPropertyChanged(nameof(LapSeconds));
            }
        }
    
        public void Lap()
        {
            _stopwathModel.Lap();
        }

        public void Reset()
        {
            _stopwathModel.Reset();
        }

        public void Start()
        {
            _stopwathModel.Start();
        }

        public void Stop()
        {
            _stopwathModel.Stop();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int GetHours(TimeSpan? measuredTime)
        {
            return measuredTime.HasValue ? measuredTime.Value.Hours : 0;
        }

        private int GetMinutes(TimeSpan? measuredTime)
        {
            return measuredTime.HasValue ? measuredTime.Value.Minutes : 0;
        }

        private int GetSeconds(TimeSpan? measuredTime)
        {
            return measuredTime.HasValue ? measuredTime.Value.Seconds : 0;
        }


    }

}
