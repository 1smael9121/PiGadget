using Avalonia.Controls;

namespace PiGadget.Modules.NetScanner
{
    public partial class NetScannerWindow : Window
    {
        public NetScannerWindow()
        {
            InitializeComponent();
        }

        private void OnCloseClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
