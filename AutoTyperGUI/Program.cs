using System;
using System.Threading;
using System.Windows.Forms;

namespace AutoTyperGUI
{
    internal static class Program
    {
        /// <summary>
        /// Mutex object to prevent running multiple instances of the application
        /// </summary>
        static Mutex mutex = new Mutex(true, "autoEnforceOneInstance");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                // do the app code
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AutoTyperApplicationContext());

                // release mutex after the form is closed.
                mutex.ReleaseMutex();
                mutex.Dispose();
            }
        }
    }
}
