using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scorpion.net.Sockets;
using Scorpion.net;
using Scorpion_Client.Controls;

namespace Scorpion_Client.Better_Forms.User_Control.Main_Form
{
    public partial class Text : UserControl
    {
        Server.LogIn Server;
        MainForm mf;
        bool servercon = true;

        public Text()
        {
            InitializeComponent();
        }

        public void load(Server.LogIn server, MainForm MF)
        {
            mf = MF;
            try
            {
                Server = server;
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("No connection could be made because the target machine actively refused it"))
                {
                    MessageBox.Show("Scorpion servers are currently down for maintenance!");
                    Application.Exit();
                }
                else if (ex.ToString().Contains("Object reference not set to an instance of an object"))
                {
                    MessageBox.Show("Scorpion servers are currently down for maintenance!");
                    Application.Exit();
                }
                else if (ex.ToString().Contains("Failed To Login"))
                {
                    MessageBox.Show("Scorpion servers are currently down for maintenance!");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Something went wrong trying to connect to Scorpion Server try again latter.");
                    Application.Exit();
                }
            }
            try
            {
                Server.ReceivedFriendRequest += Server_ReceivedFriendRequest;
                Server.MessageReceived += Server_MessageReceived;
                Server.UserStatusUpdate += Server_UserStatusUpdate;
                Server.FriendRequestResult += Server_FriendRequestResult;
                server.ServerShutdown += Server_ServerShutdown;
            }
            catch { }

            try
            {
                label1.Text = Server.CurrentUser.UserName;
                label2.Text = "#" + IDHandeler.VerifyUserTag(Server.CurrentUser.Tag);
                pictureBox1.Image = Imagery.CropToCircle(Server.CurrentUser.Avatar, Color.FromArgb(17, 17, 17));
                if (Server.CurrentUser.Friends != null)
                {
                    foreach (SocketUser Friend in Server.CurrentUser.Friends)
                    {
                        AddFriend(Friend);
                    }
                }

                if (Server.CurrentUser.SelectedChannel.Messages != null)
                {
                    foreach (var result in Server.CurrentUser.SelectedChannel.Messages)
                    {
                        SocketMessage message = new SocketMessage(ulong.Parse(result["msg_id"].ToString()), Server.CurrentUser.SelectedChannel);
                        //Chatbox.Controls.Add(new Message(message, Chatbox, Server, this));
                    }
                }

                ServerImageList.Images.Add(Imagery.CropToCircle(server.RequestImage(Assets.Type.client, "Friends.png"), Color.FromArgb(32, 32, 32)));
                pictureBox2.Image =(server.RequestImage(Assets.Type.client, "Settings.png"));
                ListViewItem item = new ListViewItem(new string[] { "", "", "" }, 0);
                //listView1.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SetTheme();
            Program.ThemeUpdater.Tick += ThemeUpdater_Tick;
        }

        private void ThemeUpdater_Tick(object sender, EventArgs e)
        {
            SetTheme();
        }

        private void SetTheme()
        {
            Chatbox.BackColor = Theme.MainForm.Controles.Text.Background;
        }

        private async Task Server_ServerShutdown()
        {
            MessageBox.Show("Scorpion servers have went offline. If we did not broadcast this in the global chat, I will try to fix this problem as fast as we can.", "Sorry for the inconvenience");
            servercon = false;
            Application.Exit();
            Environment.Exit(0);
        }


        private async Task Server_FriendRequestResult(SocketUser arg1, bool arg2)
        {
            if (arg2 == true)
            {
                AddFriend(arg1);
            }
            mf.friendresult(arg1, arg2);
        }

        private async Task Server_UserStatusUpdate(SocketUser arg1, SocketUser arg2)
        {
            //throw new NotImplementedException();
        }

        private async Task Server_ReceivedFriendRequest(SocketUser User)
        {
            Scorp.ShowBalloonTip(10000, "Friend Request", $"{User.UserName}#{IDHandeler.VerifyUserTag(User.tag)} Wants to be your friend, go to manage friends or click here.", ToolTipIcon.None);
            mf.add(User);
        }

        private async Task Server_MessageReceived(SocketMessage Message)
        {
            if (Message.Channel.ID == Server.CurrentUser.SelectedChannel.ID)
            {
                if (Chatbox.InvokeRequired == false)
                {
                    //Chatbox.Controls.Add(new Message(Message, Chatbox, Server, this));
                }
                else
                {
                   // Chatbox.Invoke(new Action(() => Chatbox.Controls.Add(new Message(Message, Chatbox, Server, this))));
                }
            }
        }

        public void Close()
        {
            if (servercon)
            {
                Server.LogOut();
            }
            Environment.Exit(0);
            Application.Exit();
        }

        private void LollipopButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(metroTextBox1.Text))
            {
                SocketAppUser u = Server.CurrentUser;
                Server.SendMessage(metroTextBox1.Text, Server.CurrentUser.SelectedChannel.ID);
                metroTextBox1.Clear();
            }
        }

        private void MetroTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(metroTextBox1.Text))
                {
                    Server.SendMessage(metroTextBox1.Text, Server.CurrentUser.SelectedChannel.ID);
                    metroTextBox1.Clear();
                }
            }
        }

        public void AddFriend(SocketUser Friend)
        {
            FriendsImageList.Images.Add(Friend.ID.ToString() + ".png", Imagery.CropToCircle(Friend.Avatar, Color.FromArgb(53, 53, 53)));
            int index = FriendsImageList.Images.IndexOfKey(Friend.ID.ToString() + ".png");
            ListViewItem item0 = new ListViewItem(new string[] { Friend.UserName, "", "" }, index);
            listView2.Items.Add(item0);
        }

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 0)
            {
                ulong FriendID = Server.CurrentUser.Friends[listView2.SelectedItems[0].Index].ID;
                ulong ChannelID = FriendID ^ Server.CurrentUser.ID;
                Server.ChangeChannel(new SocketChannel(ChannelID));
                Chatbox.Controls.Clear();
                if (Server.CurrentUser.SelectedChannel.Messages != null)
                {
                    foreach (var result in Server.CurrentUser.SelectedChannel.Messages)
                    {
                        SocketMessage message = new SocketMessage(ulong.Parse(result["msg_id"].ToString()), Server.CurrentUser.SelectedChannel);
                        //Chatbox.Controls.Add(new Message(message, Chatbox, Server, this));
                    }
                }
                mf.closefriend();
            }
        }

        private void ManageFriendsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mf.Openfriend(Server.CurrentUser);
        }

        private void Scorp_Click(object sender, EventArgs e)
        {
            mf.Openfriend(Server.CurrentUser);
        }

        public void sendfriend(SocketUser user, bool accept)
        {
            if (accept == true)
            {
                AddFriend(user);
            }
            Server.SendFriendResult(user, accept);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            mf.set(Server.CurrentUser, Server);
        }

        private void Chatbox_SizeChanged(object sender, EventArgs e)
        {
            siz = Chatbox.Size.Width;
        }

        public int siz = 771;

        private void Chatbox_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
