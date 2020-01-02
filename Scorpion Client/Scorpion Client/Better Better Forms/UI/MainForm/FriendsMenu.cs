namespace Scorpion_Client.Better_Better_Forms.UI.MainForm
{
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
            if (User.Friends != null)
            {
                foreach (SocketUser friend in User.Friends)
                {
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
                    AddUser(pend, Section.Pending);
                }
            }
        }

        public enum Section
        {
            Online = 0,
            All = 1,
            Pending = 2,
        }

        public void AddUser(SocketUser user, Section section)
        {
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
                var f = new Friend(arg3, ui, server);
                l.Controls.Add(f);
                f.DMOpen += F_DMOpen;
            }
        }

        private async Task F_DMOpen(ulong arg)
        {
            server.ChangeChannel(new SocketChannel(arg));
            textArea.Controls.Clear();
            if (server.CurrentUser.SelectedChannel.Messages != null)
            {
                foreach (var result in server.CurrentUser.SelectedChannel.Messages)
                {
                    SocketMessage message = new SocketMessage(ulong.Parse(result["msg_id"].ToString()), server.CurrentUser.SelectedChannel);
                    Better_Forms.User_Control.Main_Form.Message m = new Better_Forms.User_Control.Main_Form.Message(message, textArea, server, mainForm);
                    m.RefreshChat += M_RefreshChat;
                    textArea.Controls.Add(m);
                }
            }
        }

        private async Task M_RefreshChat(ulong arg)
        {
            server.ChangeChannel(new SocketChannel(arg));
            textArea.Controls.Clear();
            if (server.CurrentUser.SelectedChannel.Messages != null)
            {
                foreach (var result in server.CurrentUser.SelectedChannel.Messages)
                {
                    SocketMessage message = new SocketMessage(ulong.Parse(result["msg_id"].ToString()), server.CurrentUser.SelectedChannel);
                    Better_Forms.User_Control.Main_Form.Message m = new Better_Forms.User_Control.Main_Form.Message(message, textArea, server, mainForm);
                    m.RefreshChat += M_RefreshChat;
                    textArea.Controls.Add(m);
                }
            }
        }
    }
}
