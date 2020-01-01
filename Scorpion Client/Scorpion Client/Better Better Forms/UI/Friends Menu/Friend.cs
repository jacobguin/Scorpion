using Scorpion.net.Sockets;
using System.Windows.Forms;
using Scorpion.net;

namespace Scorpion_Client.Better_Better_Forms.UI.Friends_Menu
{
    public partial class Friend : UserControl
    {
        public SocketUser User;

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
        }
    }
}
