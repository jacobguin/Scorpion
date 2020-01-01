namespace Scorpion_Client.Better_Forms
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Windows.Forms;
    using MetroFramework.Forms;

    public partial class Login_Form : MetroForm
    {
        private bool Download = false;

        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Download)
            {
                new Process()
                {
                    StartInfo =
                    {
                        FileName = $"{Application.StartupPath}/Updater.exe",
                        Arguments = "\"Scorpion Client\" Scorpion"

                    }
                }.Start();
                Application.Exit();
                Environment.Exit(0);
            }
            else
            {
                Application.Exit();
                Environment.Exit(0);
            }
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            string Online = web.DownloadString("http://jacobtech.org/Scorpion/ver.txt");
            if (Online != "1.0.0")
            {
                Download = true;
                Application.Exit();
            }
        }
    }
}
