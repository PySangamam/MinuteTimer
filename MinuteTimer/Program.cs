using System;
using System.Windows.Forms;

namespace PySangamamTimer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var startTime = 20;
            var interval = 1;

            if (args.Length == 1)
            {
                startTime = Convert.ToInt32(args[0]);
            }
            else if (args.Length == 2)
            {
                startTime = Convert.ToInt32(args[0]);
                interval = Convert.ToInt32(args[1]);
            }

            Application.Run(new MainForm(startTime, interval));
        }
    }
}
