using Shapes.Services;
using System.Windows;
using System.Windows.Input;

namespace Shapes
{
    public partial class MainWindow : Window
    {
        private readonly ShapeService _shapeService;
        private readonly TimerService _timerService;

        public MainWindow()
        {

            InitializeComponent();
            IShapeFactory shapeFactory = new ShapeFactory(DrawingCanvas);
            _shapeService = new ShapeService(DrawingCanvas, shapeFactory);
            _timerService = new TimerService(_shapeService.MoveShapes);


            DrawingCanvas.Loaded += (s, e) => _shapeService.AddInitialShape();
        }

        private void AddShapeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _shapeService.AddRandomShape();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _shapeService.HandleCanvasClick(e.GetPosition(DrawingCanvas), e.ChangedButton);
        }

        private void OpenSettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            _shapeService.OpenSettingsDialog();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
