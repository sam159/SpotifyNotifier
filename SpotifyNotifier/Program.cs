using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows;

namespace SpotifyNotifier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Only allow one instance to run (dont want multiple popups)
            var processes = System.Diagnostics.Process.GetProcesses();
            var thisProcess = System.Diagnostics.Process.GetCurrentProcess();

            foreach (var p in processes)
            {
                if (p.Id == thisProcess.Id)
                    continue;
                if (p.ProcessName == thisProcess.ProcessName)
                    return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NotifyForm());
        }
    }
}
