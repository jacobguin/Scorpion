namespace Scorpion_Client.Better_Forms.User_Control.Main_Form.Settings_forms
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Scorpion.Net;
    using Scorpion.Net.Sockets;
    using Scorpion_Client.Controls;

    public partial class Account : UserControl
    {
        private readonly Server.LogIn scorpServer;

        public Account(SocketAppUser user, Server.LogIn server)
        {
            InitializeComponent();
            scorpServer = server;
            pictureBox1.Image = user.Avatar;
            metroLabel2.Text = $"{user.UserName}#{IDHandler.VerifyUserTag(user.Tag)}";
        }

        private void Changepfp_Click(object sender, EventArgs e)
        {
            string png;
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Picture Files (*.png)|*.png",
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            png = Path.GetFullPath(ofd.FileName);
            pictureBox1.Image = Image.FromFile(png);
            scorpServer.ChangeAvatar(Image.FromFile(png));
        }
    }
}
