using Scorpion.Net.Sockets;
using System.Windows.Forms;
using Scorpion.Net;
using System;
using System.Threading.Tasks;

namespace Scorpion_Client.Better_Better_Forms.UI.Friends_Menu
{
    public partial class Friend : UserControl
    {
        public SocketUser User;

        public event Func<Friend, bool, SocketUser, Task> Result;

        public Friend(SocketUser friend)
        {
            InitializeComponent();
            User = friend;
            label3.Text = friend.UserName;
            string stat;
            if (friend.Status == UserStatus.Online)
            {
                stat = "Online";
            }
            else if (friend.Status == UserStatus.Offline)
            {
                stat = "Offline";
            }
            else
            {
                stat = "Idle";
            }
            label4.Text = stat;
            pictureBox1.Image = Scorpion_Client.Controls.Imagery.CropToCircle(friend.Avatar, BackColor);
        }

        public Friend(SocketUser person, string status)
        {
            InitializeComponent();
            User = person;
            label3.Text = person.UserName;
            label4.Text = status;
            pictureBox1.Image = Scorpion_Client.Controls.Imagery.CropToCircle(person.Avatar, BackColor);
            ContextMenuStrip = metroContextMenu1;
            pictureBox1.ContextMenuStrip = metroContextMenu1;
            label3.ContextMenuStrip = metroContextMenu1;
            label4.ContextMenuStrip = metroContextMenu1;
        }

        private void addFriendToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Result.Invoke(this, true, User);
        }

        private void deToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result.Invoke(this, false, User);
        }
    }
}
