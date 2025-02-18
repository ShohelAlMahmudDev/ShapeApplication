using Shapes.Dialogs;
using Shapes.Helpers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Shapes.Services
{
    /// <summary>
    /// The ShapeService class manages the creation, movement, and interaction of shapes within a canvas.
    /// It handles adding initial and random shapes, moving them, and processing mouse clicks for shape interaction.
    /// </summary>
    public class ShapeService
    {
        // List to store all shapes that will be manipulated.
        private readonly List<IShapeHandler> _shapes = new();

        // Factory used to create new shapes.
        private readonly IShapeFactory _shapeFactory;

        // Canvas where shapes will be drawn and manipulated.
        private readonly Canvas _canvas;

        // Random number generator for randomizing shapes' properties.
        private readonly Random _rand = new();

        // Keeps track of the last click time for double-click detection.
        private DateTime _lastClickTime = DateTime.MinValue;

        // Stores the last clicked shape.
        private IShapeHandler? _lastClickedShape = null;

        // Constructor to initialize the canvas and shape factory.
        public ShapeService(Canvas canvas, IShapeFactory shapeFactory)
        {
            _canvas = canvas;
            _shapeFactory = shapeFactory;
        }

        // Adds an initial shape (rectangle) to the canvas at the center.
        public void AddInitialShape()
        {
            try
            {
                // Create a new rectangle at the center of the canvas and add it to the list.
                var shape = _shapeFactory.CreateShape(ShapeType.Rectangle, ShapeConfig.Default_MinSize, 0, 0, _canvas.ActualWidth / 2, _canvas.ActualHeight / 2);
                _shapes.Add(shape);
            }
            catch (Exception ex)
            {
                // Handle any errors during shape creation.
                ExceptionHandler.HandleException(ex, nameof(AddRandomShape));
            }
        }

        // Adds a random shape (circle or rectangle) to the canvas at a random position.
        public void AddRandomShape()
        {
            try
            {
                // Generate random properties for the new shape.
                double size = ShapeConfig.Default_MinSize;  // Default initial size.
                double dx = ShapeConfig.DefaultDx;  // Default X speed.
                double dy = ShapeConfig.DefaultDy;  // Default Y speed.
                double left = _rand.NextDouble() * (_canvas.ActualWidth - size);  // Random X position.
                double top = _rand.NextDouble() * (_canvas.ActualHeight - size);  // Random Y position.

                // Randomly pick between a circle or rectangle shape.
                var shapeType = _rand.Next(2) == 0 ? ShapeType.Circle : ShapeType.Rectangle;
                var shape = _shapeFactory.CreateShape(shapeType, size, dx, dy, left, top);

                // Add the newly created shape to the list and start its movement.
                _shapes.Add(shape);
                shape.ToggleMovement();
            }
            catch (Exception ex)
            {
                // Handle any errors during random shape creation.
                ExceptionHandler.HandleException(ex, nameof(AddRandomShape));
            }
        }

        // Moves all shapes based on their movement speed and direction.
        public void MoveShapes()
        {
            foreach (var shape in _shapes)
            {
                shape.Move(_canvas.ActualWidth, _canvas.ActualHeight);
            }
        }

        // Handles mouse click events, including double-click detection and shape interaction.
        public void HandleCanvasClick(Point position, MouseButton button)
        {
            try
            {
                // If it's a double-click, open the settings dialog for the last clicked shape.
                if (IsDoubleClick())
                {
                    OpenSettingsDialog();
                    return;
                }

                // Check if any shape is clicked based on the position and handle the click.
                foreach (var shape in _shapes)
                {
                    if (shape.IsClicked(position))
                    {
                        _lastClickedShape = shape;

                        // Left-click: Toggle shape and color.
                        if (button == MouseButton.Left)
                            shape.ToggleShapeAndColor();
                        // Right-click: Toggle movement.
                        else if (button == MouseButton.Right)
                            shape.ToggleMovement();

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors during the click handling.
                ExceptionHandler.HandleException(ex, nameof(AddRandomShape));
            }
        }

        // Checks if the current click is a double-click based on time interval.
        private bool IsDoubleClick()
        {
            var now = DateTime.Now;
            bool isDoubleClick = (now - _lastClickTime).TotalMilliseconds < 300; // Double-click threshold.
            _lastClickTime = now;
            return isDoubleClick;
        }

        // Opens a settings dialog to modify the properties of the last clicked shape.
        public void OpenSettingsDialog()
        {
            if (_lastClickedShape == null)
            {
                // Show a warning if no shape is selected.
                MessageBox.Show("No shape selected for settings.", "Settings", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create and show the settings dialog with current shape size and speed.
            var dialog = new SettingsDialog(_lastClickedShape.Size, _lastClickedShape.Speed);
            if (dialog.ShowDialog() == true)
            {
                // Update the shape's properties based on the dialog input.
                _lastClickedShape.Update(dialog.ShapeSize, dialog.Speed);
            }
        }
    }

}
