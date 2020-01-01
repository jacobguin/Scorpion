using MetroFramework.Forms;
using Scorpion.Net.Sockets;
using System.Windows.Forms;
using Scorpion.Net;
using Scorpion_Client.Better_Forms.User_Control.Main_Form;
using System.Drawing;

namespace Scorpion_Client.Better_Forms
{
    public partial class MainForm : MetroForm
    {
        private bool gen = false;
        private Settings Set;

        public MainForm(Server.LogIn server)
        {
            InitializeComponent();
            text1.load(server, this);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            text1.Close();
        }

        public void Openfriend(SocketAppUser User)
        {
            friends1.load(User, this);
            friends1.Visible = true;
        }

        public void friendresult(SocketUser user, bool result)
        {
            if (result == true)
            {
                friends1.AddFriend(user);
            }
        }

        public void set(SocketAppUser u, Server.LogIn log)
        {
            if (gen == false)
            {
                Set = new Settings(u, log);
                Set.Location = new Point(16, 51);
                Controls.Add(Set);
                Set.BringToFront();
                gen = true;
            }
            else
            {
                Set.Show();
            }
        }

        public void closefriend()
        {
            friends1.Visible = false;
        }

        public void add(SocketUser u)
        {
            friends1.AddFriendReq(u);
        }

        public void addf(SocketUser u, bool accept)
        {
            text1.sendfriend(u, accept);
        }
    }
}
