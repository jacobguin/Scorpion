namespace Scorpion_Client.Better_Better_Forms.UI.MainForm
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Scorpion.Net;
    using Scorpion.Net.Sockets;

    public partial class Friend : UserControl
    {
        public SocketUser SocketUser;

        private readonly UserInfo ui;
        private readonly Server.LogIn ser;

        public Friend(SocketUser user, UserInfo form, Server.LogIn server)
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

        public event Func<ulong, Task> DMOpen;

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

        private void Label2_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void Friend_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void Change()
        {
            ulong channelID = SocketUser.ID ^ ui.User.ID;
            if (SocketUser.ID == 0) channelID = 0;
            DMOpen.Invoke(channelID);
        }
    }
}
