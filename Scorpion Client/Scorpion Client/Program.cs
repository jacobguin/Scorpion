using Scorpion_Client.Better_Forms;
using System;
using System.Windows.Forms;

namespace Scorpion_Client
{
    static class Program
    {
        public static Timer ThemeUpdater = new Timer();
        public static Login_Form LF = null;
        public static bool LiveTheme
        {
            get
            {
                return lt;
            }
            set
            {
                if (lt == value) return;

                if (value == true)
                {
                    ThemeUpdater.Start();
                }
                else
                {
                    ThemeUpdater.Stop();
                }
                
                lt = value;
            }
        }

        private static bool lt = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ThemeUpdater.Interval = 1000;
            //Theme.CurentTheme = "default.ini";
            //if (lt == true) ThemeUpdater.Start();
            Application.Run(new Better_Better_Forms.MainForm());
        }
    }
}
