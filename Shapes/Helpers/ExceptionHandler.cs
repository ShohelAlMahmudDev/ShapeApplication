using System.Windows;

namespace Shapes.Helpers
{
    /// <summary>
    /// Global Exception handler for any methods
    /// </summary>
    public static class ExceptionHandler
    {
        private static readonly string LogFilePath = "error_log.txt";
        public static void ExecuteWithExceptionHandling(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                 
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
                //If we need to store the exception, we can log the exception to a file, or send it to a logging service
            }
        }  
        public static void HandleException(Exception ex, string context = "Application")
        {
            // Log the exception
            LogException(ex, context);

            // Show a user friendly message if you want
            MessageBox.Show(
                $"An error occurred: {ex.Message}\n\nPlease contact support.",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        } 
        /// <summary>
        /// Log the exception to a file
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="context"></param>
        private static void LogException(Exception ex, string context)
        {
            var logMessage = $"{DateTime.Now}: Exception in {context}\n{ex}\n";
            System.IO.File.AppendAllText(LogFilePath, logMessage);
        }
    }
}
