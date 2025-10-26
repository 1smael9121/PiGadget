using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform;
using PiGadget.Modules.NetScanner;
using PiGadget.Modules.Stats;
using PiGadget.Modules.Calculator;

namespace PiGadget
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenApp(Window appWindow)
        {
            this.Hide();
            appWindow.Show();
            appWindow.Closed += (_, _) => this.Show();
        }

        private void NetworkScanner_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var net = new NetScannerWindow();
            OpenApp(net);
        }

        private void SystemStats_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var cpu = new CpuMonitorWindow();
            OpenApp(cpu);
        }

        private void Calculator_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var calc = new CalculatorWindow();
            OpenApp(calc);
        }
    }
}
