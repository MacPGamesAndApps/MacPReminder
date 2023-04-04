using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacPReminder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string message = "No message set yet.";
            bool skipSystemSoundVolume = false;
            if (args.Length > 0)
            {
                message = args[0];
                skipSystemSoundVolume = args.Contains("-sv");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmReminder(message, skipSystemSoundVolume));
        }
    }
}
