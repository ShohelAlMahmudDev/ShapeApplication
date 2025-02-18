# Shape Application(SOLID Principles)

## Project Overview
### Purpose
This WPF application allows users to interact with shapes on a canvas, enabling shape creation, movement, and customization through a graphical interface. The project demonstrates principles of OOP and SOLID Principles.

### Features
- Add shapes to a canvas (initial and random).
- Toggle shape type (circle/rectangle) and color on a left-click.
- Toggle movement on a right-click.
- Open the settings dialog on double-click for shape size and speed customization.

## Development Environment
- **Operating System:** Windows 10 or later (Windows 11 recommended)
- **IDE:** Visual Studio 2022
- **.NET SDK:** .NET 8 SDK (latest version)
- **Package Manager:** NuGet, or .NET CLI (`dotnet restore`)

## Project Structure
### Solution Overview
- **Shapes (Main Project)**
  - `Services/`: Business logic (e.g., `ShapeService`, `ShapeFactory`)
  - `Views/`: WPF user interface files (e.g., `MainWindow.xaml`)
  - `Dialogs/`: UI elements (e.g., `SettingsDialog.xaml`)
  - `Helpers/`: Utility classes (`ExceptionHandler`, `ShapeConfig`, `ShapeType`, etc.)

### Class Descriptions
- **ShapeService**: Manages shape creation, movement, and interactions.
- **ShapeFactory**: Implements the Factory pattern to create shapes.
- **ShapeHandler**: Handles shape movement, toggling, etc.
- **SettingsDialog**: Manages shape customization settings.

## Implementation Details
### Design Patterns
- **Factory Pattern**: `ShapeFactory` creates shapes to decouple logic from `ShapeService`.
- **Dependency Injection**: `Canvas` is passed into `ShapeFactory` and `ShapeService` for flexibility.

### SOLID Principles
- **Single Responsibility**: Each class has a specific purpose.
- **Open-Closed Principle**: New shape types can be added via `ShapeFactory` without modifying existing logic.
- **Liskov Substitution**: Interfaces (`IShapeHandler`, `IShapeFactory`) allow for interchangeable implementations.
- **Interface Segregation**: Focused and minimal interfaces.
- **Dependency Inversion**: High-level modules depend on abstractions (`IShapeFactory`, `IShapeHandler`).

## Testing and Validation
- Manual testing has been conducted for UI interactions and functionality.
- Unit and automated testing were not implemented but are planned as a future enhancement.

## Future Enhancements
Potential improvements:
- Add support for custom shape types via plugins.
- Optimize performance for handling numerous shapes.

## Dependencies
This project does not use any external libraries other than:
- `.NETCore.App`
- `Microsoft.WindowsDesktop.App.WPF`

---

### How to Run
1. Clone the repository.
2. Open the project in **Visual Studio 2022**.
3. Restore dependencies using:
   ```sh
   dotnet restore
   ```
4. Build and run the project.

### Author
**Md. Shohel Al Mahmud**

---
This project is open-source and contributions are welcome!
