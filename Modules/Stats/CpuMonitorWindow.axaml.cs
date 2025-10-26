using Avalonia.Controls;

namespace PiGadget.Modules.Stats
{
    public partial class CpuMonitorWindow : Window
    {
       public CpuMonitorWindow()
        {
            InitializeComponent();
            OnRefreshClick(null, null);
        }

        private void OnCloseClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnRefreshClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            CpuInfoText.Text = "Loading...";
            RamInfoText.Text = "Loading...";
            CpuTemperatureText.Text = "Loading...";
            CpuClockText.Text = "Loading...";
        }
    }
}
