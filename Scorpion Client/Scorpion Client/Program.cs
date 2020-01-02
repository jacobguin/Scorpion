namespace Scorpion_Client
{
    using System;
    using System.Windows.Forms;
    using Scorpion_Client.Better_Forms;

    internal static class Program
    {
        public static Timer ThemeUpdater = new Timer();
        public static Login_Form LF = null;
        private static bool lt = true;

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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Theme.CurentTheme = "default.ini";
            Application.Run(LF = new Login_Form());
        }
    }
}
