namespace Shapes.Services
{
    /// <summary>
    /// Defines the contract for objects that can move within a canvas and toggle their movement state.
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// Moves the object within the boundaries of the canvas.
        /// </summary>
        /// <param name="canvasWidth">The width of the canvas.</param>
        /// <param name="canvasHeight">The height of the canvas.</param>
        void Move(double canvasWidth, double canvasHeight);

        /// <summary>
        /// Toggles the movement state of the object (e.g., starts or stops moving).
        /// </summary>
        void ToggleMovement();
    }

}
