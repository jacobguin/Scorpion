namespace Scorpion_Client.Better_Better_Forms.UI.Friends_Menu
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Scorpion.Net;
    using Scorpion.Net.Sockets;
    using Scorpion_Client.Controls;

    public partial class Friend : UserControl
    {
        public SocketUser User;

        public Friend(SocketUser friend)
        {
            InitializeComponent();
            User = friend;
            label3.Text = friend.UserName;
            string stat;
            if (friend.Status == UserStatus.Online) stat = "Online";
            else if (friend.Status == UserStatus.Offline) stat = "Offline";
            else stat = "Idle";

            label4.Text = stat;
            pictureBox1.Image = Imagery.CropToCircle(friend.Avatar, BackColor);
        }

        public Friend(SocketUser person, string status)
        {
            InitializeComponent();
            User = person;
            label3.Text = person.UserName;
            label4.Text = status;
            pictureBox1.Image = Imagery.CropToCircle(person.Avatar, BackColor);
            if (status == "PendingOut") return;
            ContextMenuStrip = metroContextMenu1;
            pictureBox1.ContextMenuStrip = metroContextMenu1;
            label3.ContextMenuStrip = metroContextMenu1;
            label4.ContextMenuStrip = metroContextMenu1;
        }

        public event Func<Friend, bool, SocketUser, Task> Result;

        private void AddFriendToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Result.Invoke(this, true, User);
        }

        private void DeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result.Invoke(this, false, User);
        }
    }
}
