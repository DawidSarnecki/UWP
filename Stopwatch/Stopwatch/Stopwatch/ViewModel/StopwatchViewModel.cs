using System;
using System.ComponentModel;
using Windows.UI.Xaml;
using Stopwatch.Model;
using System.Windows.Input;

namespace Stopwatch.ViewModel
{
    public class StopwatchViewModel : IStopwathViewModel, INotifyPropertyChanged
    {
        private IStopwathModel _stopwathModel;

        private DispatcherTimer _timer;

        private int _lastHours;

        private int _lasMinutes;

        private decimal _lastSeconds;

        private bool _lastRunning;

        private int _lapHours;

        private int _lapMinutes;

        private decimal _lapSeconds;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Running => _stopwathModel.Running;

        public int LastHours => GetHours(_stopwathModel.Elapsed);

        public int LastMinutes => GetMinutes(_stopwathModel.Elapsed);

        public decimal LastSeconds => GetSeconds(_stopwathModel.Elapsed);

        public int LapHours => GetHours(_stopwathModel.LapTime);

        public int LapMinutes => GetMinutes(_stopwathModel.LapTime);

        public decimal LapSeconds => GetSeconds(_stopwathModel.LapTime);

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
            if (_lastRunning != Running)
            {
                _lastRunning = Running;
                OnPropertyChanged(nameof(Running));
            }

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
                _lapMinutes = LapMinutes;
                OnPropertyChanged(nameof(LapMinutes));
            }

            if (_lapSeconds != LapSeconds)
            {
                _lapSeconds = LapSeconds;
                OnPropertyChanged(nameof(LapSeconds));
            }
        }

        public ICommand Lap => new RelayCommand((object arg) => _stopwathModel.Lap());

        public ICommand Start => new RelayCommand((object arg) => _stopwathModel.Start());

        public ICommand Stop => new RelayCommand((object arg) => _stopwathModel.Stop());

        public ICommand Reset => new RelayCommand((object arg) => _stopwathModel.Reset());

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

        private decimal GetSeconds(TimeSpan? measuredTime)
        {
            return measuredTime.HasValue ? measuredTime.Value.Seconds + (measuredTime.Value.Milliseconds * .001M) : 0.0M;
        }


    }

}
