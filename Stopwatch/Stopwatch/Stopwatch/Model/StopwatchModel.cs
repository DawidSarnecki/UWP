using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch.Model
{
    class StopwatchModel : IStopwathModel
    {
        private bool _isRunning;

        private TimeSpan? _previousElapsedTime;

        private DateTime? _startTime;

        public bool Running => _isRunning;

        public TimeSpan? Elapsed => CalculateElpapsedTime();

        public TimeSpan? LapTime { get;  private set; }

        public event EventHandler<LapWasDoneEvent> LapTimeUpdated;

        public StopwatchModel()
        {
            //set the default value for private fields
            Reset();
        }

        public void Lap() 
        {
            LapTime = Elapsed;
            OnLapTimeUpdated(LapTime);
        }

        public void Reset()
        {
            _isRunning = false;
            _startTime = null;
            _previousElapsedTime = null;
            LapTime = null;
            OnLapTimeUpdated(LapTime);
        }

        public void Start()
        {
            _startTime = DateTime.Now;
            _isRunning = true;

            if (!_previousElapsedTime.HasValue)
            {
                _previousElapsedTime = new TimeSpan(0);
            }
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _previousElapsedTime += DateTime.Now - _startTime.Value;
            }

            _startTime = null;
            _isRunning = false;
        }

        private TimeSpan CalculateElpapsedTimeSinceStarted()
        {
            return DateTime.Now - _startTime.Value;
        }

        private TimeSpan? CalculateElpapsedTime()
        {
            if (_isRunning)
            {
                if (_previousElapsedTime.HasValue)
                {
                    return _previousElapsedTime + CalculateElpapsedTimeSinceStarted();
                }

                return CalculateElpapsedTimeSinceStarted();
            }

            return _previousElapsedTime;
        }

        private void OnLapTimeUpdated(TimeSpan? lapTime)
        {
            EventHandler<LapWasDoneEvent> lapTimeUpdated = LapTimeUpdated;
            if (lapTimeUpdated != null)
            {
                LapTimeUpdated(this, new LapWasDoneEvent(lapTime));
            }
        }


    }
}
