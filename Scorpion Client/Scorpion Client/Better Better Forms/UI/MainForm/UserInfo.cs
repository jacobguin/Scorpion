namespace Scorpion_Client.Better_Better_Forms.UI.MainForm
{
    using System.Windows.Forms;
    using Scorpion.Net.Sockets;
    using Scorpion_Client.Controls;

    public partial class UserInfo : UserControl
    {
        public SocketAppUser User;

        public UserInfo(SocketAppUser user)
        {
            InitializeComponent();
            User = user;
            pictureBox1.Image = user.Avatar;
            label1.Text = user.UserName;
            label2.Text = $"#{IDHandler.VerifyUserTag(user.Tag)}";
        }
    }
}
