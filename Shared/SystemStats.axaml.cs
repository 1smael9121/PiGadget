using System;
using System.Diagnostics;
using System.IO;

public class SystemStats
{
    public static string GetCpuInfo()
    {
        return File.ReadAllText("/proc/cpuinfo");
    }

    public static string GetMemoryInfo()
    {
        return File.ReadAllText("/proc/meminfo");
    }

    public static string GetCpuTemperature()
    {
        return RunBashCommand("vcgencmd measure_temp");
    }

    public static string GetCpuClock()
    {
        return RunBashCommand("vcgencmd measure_clock arm");
    }

    private static string RunBashCommand(string command)
    {
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"-c \"{command}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
        process.Start();
        string result = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        return result.Trim();
    }
}
