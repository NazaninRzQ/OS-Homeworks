using System;
using System.Management;
using System.Diagnostics;

class FlashDriveDetector
{
    static void Main(string[] args)
    {
        ManagementEventWatcher watcher = new ManagementEventWatcher();
        WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");

        watcher.Query = query;
        watcher.EventArrived += (s, e) =>
        {
            Console.WriteLine("Flash Drive Inserted!");
            Process.Start("mspaint.exe");
        };

        watcher.Start();

        Console.WriteLine("Waiting for flash drive insertion. Press any key to exit...");
        Console.ReadKey();

        watcher.Stop();
    }
}
