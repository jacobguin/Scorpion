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
        private FlowLayoutPanel l;
        private UserInfo ui;
        private FlowLayoutPanel TextArea;
        private Better_Better_Forms.MainForm MainForm;

        public FriendsMenu(Server.LogIn serverin, FlowLayoutPanel list, UserInfo u, FlowLayoutPanel text, Better_Better_Forms.MainForm mf)
        {
            InitializeComponent();
            User = serverin.CurrentUser;
            l = list;
            ui = u;
            TextArea = text;
            server = serverin;
            MainForm = mf;
            server.FriendRequestResult += Server_FriendRequestResult;
            if (User.Friends != null)
            {
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

            if (User.PendingFriends != null)
            {
                foreach (SocketUser pend in User.PendingFriends)
                {
                    AddUser(pend, Section.pending);
                }
            }
        }

        private async Task Server_FriendRequestResult(SocketUser friend, bool arg2)
        {
            if (arg2 == true)
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
                    var f = new Friend(user, user.FriendStatus.ToString());
                    f.Result += F_Result;
                    online3.addcontrol(f);
                    break;
            }
        }

        private async Task F_Result(Friend arg1, bool arg2, SocketUser arg3)
        {
            server.SendFriendResult(arg3, arg2);
            if (arg2 == true)
            {
                var f = new friend(arg3, ui, server);
                l.Controls.Add(f);
                f.DMOpen += F_DMOpen;
            }
        }

        private async Task F_DMOpen(ulong arg)
        {
            server.ChangeChannel(new SocketChannel(arg));
            TextArea.Controls.Clear();
            if (server.CurrentUser.SelectedChannel.Messages != null)
            {
                foreach (var result in server.CurrentUser.SelectedChannel.Messages)
                {
                    SocketMessage message = new SocketMessage(ulong.Parse(result["msg_id"].ToString()), server.CurrentUser.SelectedChannel);
                    TextArea.Controls.Add(new Better_Forms.User_Control.Main_Form.Message(message, TextArea, server, MainForm));
                }
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
