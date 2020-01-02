namespace Scorpion_Client.Better_Forms.User_Control.Main_Form
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Scorpion.Net;
    using Scorpion.Net.Sockets;
    using Scorpion_Client.Better_Forms.User_Control.Main_Form.Settings_forms;

    public partial class Settings : UserControl
    {
        private readonly SocketAppUser u;
        private readonly Server.LogIn server;
        private Point loc = new Point(239, 28);
        private Account account;
        private Theme theme;
        private Setting selected;

        public Settings(SocketAppUser user, Server.LogIn s)
        {
            InitializeComponent();
            server = s;
            u = user;
        }

        private enum Setting
        {
            Account,
            Theme,
        }

        private void MetroButton12_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            GenControls();
            HideAll();
            Controls.Add(account);
            metroLabel1.Text = "Account Settings";
            selected = Setting.Account;
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (selected != Setting.Account)
            {
                HideAll();
                Controls.Add(account);
                selected = Setting.Account;
            }
        }

        private void GenControls()
        {
            account = new Account(u, server)
            {
                Location = loc,
            };
            theme = new Theme
            {
                Location = loc,
            };
        }

        private void HideAll()
        {
            Controls.Remove(account);
            Controls.Remove(theme);
        }

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            if (selected != Setting.Theme)
            {
                HideAll();
                Controls.Add(theme);
                selected = Setting.Theme;
            }
        }
    }
}
