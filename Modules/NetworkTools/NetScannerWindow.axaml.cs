using Avalonia.Controls;

namespace PiGadget.Modules.NetworkTools
{
    public partial class NetScannerWindow : Window
    {
        public NetScannerWindow()
        {
            InitializeComponent();
        }

        private void Scan_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ResultsBox.Text += "Scanning network...\n";
        }
    }
}
