namespace Scorpion_Client.Better_Forms
{
    using System;
    using System.Windows.Forms;
    using MetroFramework.Forms;

    public partial class Login_Form : MetroForm
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
