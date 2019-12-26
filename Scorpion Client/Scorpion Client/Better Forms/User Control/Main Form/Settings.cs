using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using Scorpion.net;
using Scorpion.net.Sockets;
using System.Windows.Forms;
using Scorpion_Client.Better_Forms.User_Control.Main_Form.Settings_forms;

namespace Scorpion_Client.Better_Forms.User_Control.Main_Form
{
    public partial class Settings : UserControl
    {
        SocketAppUser u;
        private Point loc = new Point(239, 28);
        private Server.LogIn server;
        Account account;
        Settings_forms.Theme theme;

        public Settings(SocketAppUser user, Server.LogIn s)
        {
            InitializeComponent();
            server = s;
            u = user;
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            GenControls();
            HideAll();
            Controls.Add(account);
            metroLabel1.Text = "Account Settings";
            Selected = Setting.account;
        }

        private Setting Selected;

        private enum Setting
        {
            account,
            theme,
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (Selected != Setting.account)
            {
                HideAll();
                Controls.Add(account);
                Selected = Setting.account;
            }
        }

        private void GenControls()
        {
            account = new Account(u, server);
            account.Location = loc;
            theme = new Settings_forms.Theme();
            theme.Location = loc;
        }

        private void HideAll()
        {
            Controls.Remove(account);
            Controls.Remove(theme);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (Selected != Setting.theme)
            {
                HideAll();
                Controls.Add(theme);
                Selected = Setting.theme;
            }
        }
    }
}
