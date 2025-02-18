using Shapes.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Shapes.Services
{
    /// <summary>
    /// Handler for managing and manipulating a shape (e.g., moving it, toggling its type and color, etc.).
    /// Implements <see cref="IShapeHandler"/> and <see cref="IMovable"/> to provide functionality for moving the shape and modifying its properties.
    /// </summary>
    public class ShapeHandler : IShapeHandler, IMovable
    {
        private Shape _shape;
        private double _dx;
        private double _dy;
        private bool _isMoving = false;
        private readonly Canvas _canvas;

        /// <summary>
        /// Gets the size of the shape (width and height).
        /// </summary>
        public double Size => _shape.Width;

        /// <summary>
        /// Gets the speed of the shape (horizontal speed).
        /// </summary>
        public double Speed => _dx;
        /// <summary>
        /// Expose the _shape field via a public property this will help to test.
        /// </summary>
        public Shape Shape => _shape;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeHandler"/> class.
        /// </summary>
        /// <param name="shape">The shape to be managed.</param>
        /// <param name="dx">The horizontal movement speed of the shape.</param>
        /// <param name="dy">The vertical movement speed of the shape.</param>
        /// <param name="canvas">The canvas on which the shape is drawn.</param>
        public ShapeHandler(Shape shape, double dx, double dy, Canvas canvas)
        {
            _shape = shape;
            _dx = dx;
            _dy = dy;
            _canvas = canvas;
        }

        /// <summary>
        /// Moves the shape on the canvas based on its speed and direction. Reverses direction when the shape reaches the canvas boundaries.
        /// </summary>
        /// <param name="canvasWidth">The width of the canvas.</param>
        /// <param name="canvasHeight">The height of the canvas.</param>
        public void Move(double canvasWidth, double canvasHeight)
        {
            if (!_isMoving) return;

            double left = Canvas.GetLeft(_shape);
            double top = Canvas.GetTop(_shape);

            // Reverse direction if the shape hits the canvas boundaries
            if (left + _shape.Width >= canvasWidth || left <= 0) _dx = -_dx;
            if (top + _shape.Height >= canvasHeight || top <= 0) _dy = -_dy;

            // Move the shape
            Canvas.SetLeft(_shape, left + _dx);
            Canvas.SetTop(_shape, top + _dy);
        }

        /// <summary>
        /// Toggles the shape between an Ellipse and a Rectangle, and changes its color.
        /// </summary>
        public void ToggleShapeAndColor()
        {
            try
            {
                // Remove the current shape from the canvas
                _canvas.Children.Remove(_shape);

                // Toggle between Ellipse and Rectangle
                Shape newShape = _shape is Ellipse ? new Rectangle() : new Ellipse();

                // Apply the same size and position to the new shape
                newShape.Width = _shape.Width;
                newShape.Height = _shape.Height;

                double left = Canvas.GetLeft(_shape);
                double top = Canvas.GetTop(_shape);

                Canvas.SetLeft(newShape, left);
                Canvas.SetTop(newShape, top);

                // Cycle through the colors
                Brush newColor = (_shape.Fill == Brushes.Blue) ? Brushes.Red :
                                 (_shape.Fill == Brushes.Red) ? Brushes.Green :
                                 Brushes.Blue;
                newShape.Fill = newColor;

                // Add the new shape to the canvas
                _canvas.Children.Add(newShape);

                // Replace the reference to the current shape
                _shape = newShape;
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., invalid operation or issues while toggling shape)
                ExceptionHandler.HandleException(ex, nameof(ToggleShapeAndColor));
            }
        }

        /// <summary>
        /// Toggles the movement state of the shape. Starts or stops movement based on the current state.
        /// </summary>
        public void ToggleMovement()
        {
            _isMoving = !_isMoving;

            if (_isMoving)
            {
                // Set default movement speed if the shape was previously stationary
                if (_dx == 0 && _dy == 0)
                {
                    _dx = 5; // Default speed
                    _dy = 5;
                }
            }
            else
            {
                // Stop the movement by setting the speed to 0
                _dx = 0;
                _dy = 0;
            }
        }

        /// <summary>
        /// Determines whether the shape was clicked by comparing its position with the given click position.
        /// </summary>
        /// <param name="position">The position of the click.</param>
        /// <returns><c>true</c> if the shape was clicked, <c>false</c> otherwise.</returns>
        public bool IsClicked(Point position)
        {
            double left = Canvas.GetLeft(_shape);
            double top = Canvas.GetTop(_shape);
            return position.X >= left && position.X <= left + _shape.Width &&
                   position.Y >= top && position.Y <= top + _shape.Height;
        }

        /// <summary>
        /// Updates the size and speed of the shape.
        /// </summary>
        /// <param name="newSize">The new size for the shape.</param>
        /// <param name="newSpeed">The new speed for movement.</param>
        public void Update(double newSize, double newSpeed)
        {
            _shape.Width = _shape.Height = newSize;
            _dx = newSpeed;
            _dy = newSpeed;
        }
    }

}
