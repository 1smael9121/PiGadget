using Avalonia.Controls;
using PiGadget.Modules.NetworkTools;
using PiGadget.Modules.SystemTools;

namespace PiGadget
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NetworkTools_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var net = new NetScannerWindow();
            net.ShowDialog(this);
        }

        private void SystemTools_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var cpu = new CpuMonitorWindow();
            cpu.ShowDialog(this);
        }
    }
}
