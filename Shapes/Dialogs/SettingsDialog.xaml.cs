using Shapes.Helpers;
using Shapes.Services;
using System.Windows;

namespace Shapes.Dialogs
{
    /// <summary>
    /// Interaction logic for SettingsDialog.xaml
    /// </summary>
    public partial class SettingsDialog : Window
    {
        private readonly SettingsDialogService _viewModel;

        public double ShapeSize => _viewModel.ShapeSize;
        public double Speed => _viewModel.Speed;

        public SettingsDialog(double currentSize, double currentSpeed)
        {
            InitializeComponent();
            _viewModel = new SettingsDialogService(currentSize, currentSpeed);
            DataContext = _viewModel; 

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
           
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
