using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using Scorpion.Net;
using Scorpion.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using Scorpion_Client.Controls;

namespace Scorpion_Client.Better_Forms.User_Control.Main_Form.Settings_forms
{
    public partial class Account : UserControl
    {
        Server.LogIn ScorpServer;
        public Account(SocketAppUser user, Server.LogIn server)
        {
            InitializeComponent();
            ScorpServer = server;
            pictureBox1.Image = user.Avatar;
            metroLabel2.Text = user.UserName + "#" + IDHandeler.VerifyUserTag(user.Tag);
        }

        private void changpfp_Click(object sender, EventArgs e)
        {
            string png;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Picture Files (*.png)|*.png";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            png = Path.GetFullPath(ofd.FileName);
            pictureBox1.Image = Image.FromFile(png);
            ScorpServer.ChangeAvatar(Image.FromFile(png));
        }
    }
}
