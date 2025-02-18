using System.Windows;
using System.Windows.Shapes;

namespace Shapes.Services
{
    /// <summary>
    /// Defines the contract for handling shape behaviors, including movement, interaction, and updates.
    /// </summary>
    public interface IShapeHandler
    {
        /// <summary>
        /// Gets the size of the shape.
        /// </summary>
        double Size { get; }

        /// <summary>
        /// Gets the current speed of the shape.
        /// </summary>
        double Speed { get; }


        Shape Shape { get; }  

        /// <summary>
        /// Moves the shape within the boundaries of the canvas based on its speed and direction.
        /// </summary>
        /// <param name="canvasWidth">The width of the canvas.</param>
        /// <param name="canvasHeight">The height of the canvas.</param>
        void Move(double canvasWidth, double canvasHeight);

        /// <summary>
        /// Toggles the shape's type (e.g., Circle to Rectangle) and changes its color.
        /// </summary>
        void ToggleShapeAndColor();

        /// <summary>
        /// Toggles the movement state of the shape, enabling or disabling its motion.
        /// </summary>
        void ToggleMovement();

        /// <summary>
        /// Determines if the shape was clicked based on a given position.
        /// </summary>
        /// <param name="position">The position to check for a click.</param>
        /// <returns>
        /// <c>true</c> if the position overlaps the shape; otherwise, <c>false</c>.
        /// </returns>
        bool IsClicked(Point position);

        /// <summary>
        /// Updates the shape's size and speed with new values.
        /// </summary>
        /// <param name="newSize">The new size of the shape.</param>
        /// <param name="newSpeed">The new speed of the shape.</param>
        void Update(double newSize, double newSpeed);
    }

}
