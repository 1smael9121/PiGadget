using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using PiGadget.Modules.NetworkTools;
using PiGadget.Modules.SystemTools;

namespace PiGadget
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Waits for Intialization
            this.Opened += (_, _) =>
            {
                var screen = Screens.Primary;
                if (screen != null)
                {
                    var bounds = screen.Bounds;
                    Width = bounds.Width;
                    Height = bounds.Height;
                    Position = new PixelPoint(0, 0);
                }
            };
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

        private void Calculator_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var calc = new CalculatorWindow();
            calc.ShowDialog(this);
        }
    }
}
