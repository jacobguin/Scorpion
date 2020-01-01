using Scorpion.net;
using Scorpion.net.Sockets;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scorpion_Client.Better_Better_Forms.UI.MainForm
{
    public partial class friend : UserControl
    {
        public SocketUser SocketUser;

        private UserInfo ui;

        public event Func<ulong, Task> DMOpen;

        Server.LogIn ser;

        public friend(SocketUser user, UserInfo form, Server.LogIn server)
        {
            InitializeComponent();
            ser = server;
            ser.UserStatusUpdate += Ser_UserStatusUpdate;
            ui = form;
            SocketUser = user;
            label1.Text = user.UserName;
            pictureBox1.Image = Scorpion_Client.Controls.Imagery.CropToCircle(user.Avatar, BackColor);
            string stat;
            if (user.Status == UserStatus.Online)
            {
                stat = "Online";
            }
            else if (user.Status == UserStatus.Offline)
            {
                stat = "Offline";
            }
            else
            {
                stat = "Idle";
            }
            label2.Text = "Status: " + stat;
        }

        private async Task Ser_UserStatusUpdate(SocketUser arg1, SocketUser arg2)
        {
            if (arg2.ID == SocketUser.ID)
            {
                string stat;
                if (arg2.Status == UserStatus.Online)
                {
                    stat = "Online";
                }
                else if (arg2.Status == UserStatus.Offline)
                {
                    stat = "Offline";
                }
                else
                {
                    stat = "Idle";
                }
                label2.Text = "Status: " + stat;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            change();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            change();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            change();
        }

        private void friend_Click(object sender, EventArgs e)
        {
            change();
        }

        private void change()
        {
            ulong ChannelID = SocketUser.ID ^ ui.User.ID;
            if (SocketUser.ID == 0) ChannelID = 0;
            DMOpen.Invoke(ChannelID);
        }
    }
}
