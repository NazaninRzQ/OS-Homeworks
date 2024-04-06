
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

while (true)
{
    Console.WriteLine(@"
 Menu:
 1 - Create process
 2 - Get process list
 3 - Kill process
 4 - Get parent of the process
 5 - Exit
 Enter your choice:
        ");
    int state = int.Parse(Console.ReadLine());
    Process[] plist = Process.GetProcesses();
    switch (state)
    {
        case 1:
            Console.WriteLine("Enter the process location to create:");
            String name = Console.ReadLine();
            Process.Start(new ProcessStartInfo
            {
                FileName = name,
                UseShellExecute = true
            });
            break;
        case 2:
            Console.WriteLine("The processes list:");
            foreach (Process p in plist)
             Console.WriteLine(p.Id + "\t" + p.ProcessName);
            break;
        case 3:
            Console.WriteLine("Enter the name of process for kill:");
            String name0 = Console.ReadLine();
            foreach (Process p in plist)
                if (p.ProcessName == name0)
                    p.Kill();
            break;
        case 4:
            Console.WriteLine("Enter the name of process:");
            String child = Console.ReadLine();
            foreach (Process p in plist)
                if (p.ProcessName == child)
                {
                    Console.WriteLine("The parent process is:" + p.Handle);

                }
            break;
        case 5:
            return 0;
         
    }

    Console.ReadKey();
}
