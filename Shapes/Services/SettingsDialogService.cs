namespace Shapes.Services
{
    /// <summary>
    /// Manages the settings for shape size and speed, providing validation and encapsulation of related properties.
    /// </summary>
    public class SettingsDialogService
    {
        private double _shapeSize;
        private double _speed;

        /// <summary>
        /// Gets or sets the size of the shape. Ensures the size is positive before updating.
        /// </summary>
        /// <value>The size of the shape.</value>
        public double ShapeSize
        {
            get => _shapeSize;
            set
            {
                if (value > 0)
                {
                    _shapeSize = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the speed of the shape. Ensures the speed is non-negative before updating.
        /// </summary>
        /// <value>The movement speed of the shape.</value>
        public double Speed
        {
            get => _speed;
            set
            {
                if (value >= 0)
                {
                    _speed = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsDialogService"/> class with the given size and speed.
        /// </summary>
        /// <param name="currentSize">The current size of the shape.</param>
        /// <param name="currentSpeed">The current speed of the shape.</param>
        public SettingsDialogService(double currentSize, double currentSpeed)
        {
            _shapeSize = currentSize;
            _speed = currentSpeed;
        }
    }

}
