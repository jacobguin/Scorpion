using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Scorpion_Client.Better_Forms
{
    public partial class Login_Form : MetroForm
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
