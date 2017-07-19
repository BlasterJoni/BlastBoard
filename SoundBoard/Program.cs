using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Squirrel;

namespace BlastBoard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            update();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainWindow = new MainForm();
            Application.Run(mainWindow);
        }

        static async void update()
        {
            using (var mgr = new UpdateManager(@"C:\Users\joaom\Documents\Auto.Squirrel\Projects\BlastBoard_files\Releases"))
            {
                await mgr.UpdateApp();
            }
        }
    }
}
