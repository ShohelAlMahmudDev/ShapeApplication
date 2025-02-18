using Shapes.Helpers;

namespace Shapes.Services
{
    /// <summary>
    /// Defines the contract for creating shape objects with specified properties.
    /// </summary>
    public interface IShapeFactory
    {
        /// <summary>
        /// Creates a shape of the specified type with the given properties and adds it to a canvas.
        /// </summary>
        /// <param name="shapeType">The type of the shape to create (e.g., Circle, Rectangle).</param>
        /// <param name="size">The size of the shape (width and height).</param>
        /// <param name="dx">The horizontal movement speed of the shape.</param>
        /// <param name="dy">The vertical movement speed of the shape.</param>
        /// <param name="left">The initial left position of the shape on the canvas.</param>
        /// <param name="top">The initial top position of the shape on the canvas.</param>
        /// <returns>An instance of <see cref="IShapeHandler"/> representing the created shape.</returns>
        IShapeHandler CreateShape(ShapeType shapeType, double size, double dx, double dy, double left, double top);
    }

}
