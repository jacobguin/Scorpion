using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Scorpion.net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scorpion.net;
using Scorpion_Client.Better_Better_Forms.UI.Friends_Menu;

namespace Scorpion_Client.Better_Better_Forms.UI.MainForm
{
    public partial class FriendsMenu : UserControl
    {
        public SocketAppUser User;
        private Server.LogIn server;

        public FriendsMenu(Server.LogIn serverin)
        {
            InitializeComponent();
            User = serverin.CurrentUser;
            server = serverin;
            foreach (SocketUser friend in User.Friends)
            {
                if (friend.Status != UserStatus.Online)
                {
                    AddUser(friend, Section.all);
                }
                else
                {
                    AddUser(friend, Section.online);
                    AddUser(friend, Section.all);
                }
            }
        }

        public enum Section
        {
            online = 0,
            all = 1,
            pending = 2,
        }

        public void AddUser(SocketUser user, Section section)
        {
            switch (section)
            {
                case Section.all:
                    online2.addcontrol(new Friend(user));
                    break;
                case Section.online:
                    online1.addcontrol(new Friend(user));
                    break;
                case Section.pending:
                    online3.addcontrol(new Friend(user));
                    break;
            }
        }

        public void RemoveUser(SocketUser user, Section section)
        {
            switch (section)
            {
                case Section.all:
                    break;
                case Section.online:
                    break;
                case Section.pending:
                    break;
            }
        }
    }
}
