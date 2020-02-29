namespace Scorpion_Client.Better_Better_Forms.UI.MainForm
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Scorpion.Net;
    using Scorpion.Net.Sockets;

    public partial class FriendsMenu : UserControl
    {
        public SocketAppUser User;
        private readonly Server.LogIn server;
        private readonly FlowLayoutPanel l;
        private readonly UserInfo ui;
        private readonly FlowLayoutPanel textArea;
        private readonly Better_Better_Forms.MainForm mainForm;

        public FriendsMenu(Server.LogIn serverin, FlowLayoutPanel list, UserInfo u, FlowLayoutPanel text, Better_Better_Forms.MainForm mf)
        {
            InitializeComponent();
            User = serverin.CurrentUser;
            l = list;
            ui = u;
            textArea = text;
            server = serverin;
            mainForm = mf;
            server.FriendRequestResult += Server_FriendRequestResult;
        }

        public enum Section
        {
            Online = 0,
            All = 1,
            Pending = 2,
        }

        public void Reload()
        {
            online1.Clear();
            online2.Clear();
            online3.Clear();
            if (User.Friends != null)
            {
                foreach (SocketUser friend in User.Friends)
                {
                    if (friend.ID == 0) return;
                    if (friend.Status != UserStatus.Online)
                    {
                        AddUser(friend, Section.All);
                    }
                    else
                    {
                        AddUser(friend, Section.Online);
                        AddUser(friend, Section.All);
                    }
                }
            }

            if (User.PendingFriends != null)
            {
                foreach (SocketUser pend in User.PendingFriends)
                {
                    if (pend.ID == 0) return;
                    AddUser(pend, Section.Pending);
                }
            }
        }

        public void AddUser(SocketUser user, Section section)
        {
            if (user.ID == 0) return;
            switch (section)
            {
                case Section.All:
                    online2.AddControl(new Friends_Menu.Friend(user));
                    break;
                case Section.Online:
                    online1.AddControl(new Friends_Menu.Friend(user));
                    break;
                case Section.Pending:
                    var f = new Friends_Menu.Friend(user, user.FriendStatus.ToString());
                    f.Result += F_Result;
                    online3.AddControl(f);
                    break;
            }
        }

        public void RemoveUser(SocketUser user, Section section)
        {
            switch (section)
            {
                case Section.All:
                    break;
                case Section.Online:
                    break;
                case Section.Pending:
                    break;
            }
        }

        private async Task Server_FriendRequestResult(SocketUser friend, bool arg2)
        {
            if (arg2 == true)
            {
                if (friend.ID == 0) return;
                if (friend.Status != UserStatus.Online)
                {
                    AddUser(friend, Section.All);
                }
                else
                {
                    AddUser(friend, Section.Online);
                    AddUser(friend, Section.All);
                }
            }
        }

        private async Task F_Result(Friends_Menu.Friend arg1, bool arg2, SocketUser arg3)
        {
            server.SendFriendResult(arg3, arg2);
            if (arg2 == true)
            {
                Friend f = new Friend(arg3, ui, server);
                l.Controls.Add(f);
                f.DMOpen += F_DMOpen;
            }
        }

        private async Task F_DMOpen(ulong arg)
        {
            Hide();
            textArea.Show();
            mainForm.UnHide();
            server.ChangeChannel(new SocketChannel(arg));

            textArea.Controls.Clear();
            if (server.CurrentUser.SelectedChannel.Messages != null)
            {
                foreach (SocketMessage message in server.CurrentUser.SelectedChannel.Messages)
                {
                    Better_Forms.User_Control.Main_Form.Message m = new Better_Forms.User_Control.Main_Form.Message(message, textArea, server, mainForm);
                    m.RefreshChat += M_RefreshChat;
                    textArea.Controls.Add(m);
                }
            }
        }

        private async Task M_RefreshChat(SocketMessage arg)
        {
            AddUser(arg.Author, Section.Pending);
            textArea.Controls.Clear();
            if (server.CurrentUser.SelectedChannel.Messages != null)
            {
                foreach (SocketMessage message in server.CurrentUser.SelectedChannel.Messages)
                {
                    Better_Forms.User_Control.Main_Form.Message m = new Better_Forms.User_Control.Main_Form.Message(message, textArea, server, mainForm);
                    m.RefreshChat += M_RefreshChat;
                    textArea.Controls.Add(m);
                }
            }
        }
    }
}
