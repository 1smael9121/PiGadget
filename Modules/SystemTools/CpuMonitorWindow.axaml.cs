using Avalonia.Controls;
using Avalonia.Threading;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PiGadget.Modules.SystemTools
{
    public partial class CpuMonitorWindow : Window
    {
        private DispatcherTimer timer;

        public CpuMonitorWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            string cpuInfo = await GetCpuUsageAsync();
            CpuTextBox.Text += cpuInfo + "\n";
            CpuTextBox.CaretIndex = CpuTextBox.Text.Length;
        }

        private async Task<string> GetCpuUsageAsync()
        {
            try
            {
                string[] lines = await File.ReadAllLinesAsync("/proc/stat");
                string line = lines[0];
                return $"[{DateTime.Now:HH:mm:ss}] {line}";
            }
            catch
            {
                return $"[{DateTime.Now:HH:mm:ss}] Could not read CPU info.";
            }
        }
    }
}
