using Shapes.Helpers;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Shapes.Services
{

    /// <summary>
    /// Factory class responsible for creating different shapes (e.g., Circle, Rectangle) and assigning them to the canvas.
    /// </summary>
    public class ShapeFactory : IShapeFactory
    {
        private readonly Canvas _canvas;
        private readonly Brush[] _colors = { Brushes.Blue, Brushes.Red, Brushes.Green };
        private int _currentColorIndex = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeFactory"/> class with the provided canvas.
        /// </summary>
        /// <param name="canvas">The canvas on which shapes will be drawn.</param>
        public ShapeFactory(Canvas canvas)
        {
            _canvas = canvas;
        }

        /// <summary>
        /// Creates a new shape (either Circle or Rectangle) with the specified properties and adds it to the canvas.
        /// </summary>
        /// <param name="shapeType">The type of shape to create (Circle or Rectangle).</param>
        /// <param name="size">The size (width and height) of the shape.</param>
        /// <param name="dx">The initial horizontal speed of the shape.</param>
        /// <param name="dy">The initial vertical speed of the shape.</param>
        /// <param name="left">The initial horizontal position (left) of the shape on the canvas.</param>
        /// <param name="top">The initial vertical position (top) of the shape on the canvas.</param>
        /// <returns>A new instance of <see cref="IShapeHandler"/> for the created shape.</returns>
        public IShapeHandler CreateShape(ShapeType shapeType, double size, double dx, double dy, double left, double top)
        {
            Shape shape = shapeType switch
            {
                ShapeType.Circle => new Ellipse(),
                ShapeType.Rectangle => new Rectangle(),
                _ => throw new ArgumentOutOfRangeException()
            };

            try
            {
                shape.Width = size;
                shape.Height = size;
                shape.Fill = GetNextColor();

                Canvas.SetLeft(shape, left);
                Canvas.SetTop(shape, top);
                _canvas.Children.Add(shape); // Adds the shape to the canvas
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., invalid size, position, etc.)
                ExceptionHandler.HandleException(ex, nameof(CreateShape));
            }

            // Return an IShapeHandler instance that wraps the created shape and its properties
            return new ShapeHandler(shape, dx, dy, _canvas);
        }

        /// <summary>
        /// Gets the next color in the predefined color array and updates the color index.
        /// </summary>
        /// <returns>The next color to be assigned to a shape.</returns>
        private Brush GetNextColor()
        {
            var color = _colors[_currentColorIndex];
            _currentColorIndex = (_currentColorIndex + 1) % _colors.Length; // Cycles through the colors
            return color;
        }
    }


}
