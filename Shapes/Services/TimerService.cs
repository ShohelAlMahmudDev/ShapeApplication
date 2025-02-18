using System.Windows.Threading;

namespace Shapes.Services
{
    /// <summary>
    /// The TimerService class provides a timer that executes a given action at a regular interval.
    /// This class is used to handle time-based operations, such as periodic updates or animations.
    /// </summary>
    public class TimerService
    {
        // The DispatcherTimer is used to execute an action at regular intervals.
        private readonly DispatcherTimer _timer;

        /// <summary>
        /// Initializes a new instance of the TimerService class.
        /// The timer will execute the specified action at a regular interval (16 milliseconds by default).
        /// </summary>
        /// <param name="tickAction">The action to execute when the timer ticks.</param>
        public TimerService(Action tickAction)
        {
            // Initialize the DispatcherTimer with a 16-millisecond interval.
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(16)
            };

            // Subscribe to the Tick event of the timer and invoke the provided action.
            _timer.Tick += (s, e) => tickAction();

            // Start the timer.
            _timer.Start();
        }
    }

}
