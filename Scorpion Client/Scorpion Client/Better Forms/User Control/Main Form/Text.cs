using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scorpion.net.Sockets;
using FileTransferProtocalLibrary;
using Scorpion.net;
using Scorpion_Client.Controls;

namespace Scorpion_Client.Better_Forms.User_Control.Main_Form
{
    public partial class Text : UserControl
    {
        Server.LogIn Server;
        private FTP ftp;
        MainForm mf;

        public Text()
        {
            InitializeComponent();
        }

        public void load(ulong user, FTP Ftp, MainForm MF)
        {
            mf = MF;
            ftp = Ftp;
            try
            {
                Server = new Server.LogIn(user);
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
            }
            catch { }


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
                    ChatImageList.Images.Add(message.Author.ID + ".png", Imagery.CropToCircle(message.Author.Avatar, Color.FromArgb(53, 53, 53)));
                    int index = ChatImageList.Images.IndexOfKey(message.Author.ID + ".png");
                    ListViewItem item0 = new ListViewItem(new string[] { message.Author.UserName, message.Content, "where is this at?" }, index);
                    listView3.Items.Add(item0);
                }
            }

            ListViewItem item = new ListViewItem(new string[] { "","",""}, 0);
            listView1.Items.Add(item);
        }

        private async Task Server_FriendRequestResult(SocketUser arg1, bool arg2)
        {
            //throw new NotImplementedException();
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

                int FindIndex = ChatImageList.Images.IndexOfKey($"{Message.Author.ID}.png");
                if (FindIndex == -1)
                {
                    Image profilePic = Message.Author.Avatar;
                    ChatImageList.Images.Add($"{Message.Author.ID}.png", Imagery.CropToCircle(profilePic, Color.FromArgb(32, 32, 32)));
                    int index = ChatImageList.Images.IndexOfKey($"{Message.Author.ID}.png");
                    ListViewItem item0 = new ListViewItem(new string[] { Message.Author.UserName, Message.Content, "" }, index);
                    listView3.Invoke(new Action(() => listView3.Items.Add(item0)));
                }
                else
                {
                    ListViewItem item0 = new ListViewItem(new string[] { Message.Author.UserName, Message.Content, "" }, FindIndex);
                    listView3.Invoke(new Action(() => listView3.Items.Add(item0)));
                }
            }
        }

        public void Close()
        {
            Server.LogOut();
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

        private void AddFriend(SocketUser Friend)
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
                long RawID = long.Parse((FriendID ^ Server.CurrentUser.ID).ToString());
                ulong ChannelID = 0;
                if (RawID < 0) ChannelID = ulong.Parse((RawID * -1).ToString());
                else ChannelID = ulong.Parse(RawID.ToString());
                Server.ChangeChannel(ChannelID);
                listView3.Items.Clear();
                ChatImageList.Images.Clear();
                if (Server.CurrentUser.SelectedChannel.Messages != null)
                {
                    foreach (var result in Server.CurrentUser.SelectedChannel.Messages)
                    {
                        SocketMessage message = new SocketMessage(ulong.Parse(result["msg_id"].ToString()), Server.CurrentUser.SelectedChannel);
                        ChatImageList.Images.Add(message.Author.ID + ".png", Imagery.CropToCircle(message.Author.Avatar, Color.FromArgb(32, 32, 32)));
                        int index = ChatImageList.Images.IndexOfKey(message.Author.ID + ".png");
                        ListViewItem item0 = new ListViewItem(new string[] { message.Author.UserName, message.Content, "" }, index);
                        listView3.Items.Add(item0);
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

        private void AddFriendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Server.SendFriendRequest(new SocketUser(ulong.Parse(Server.CurrentUser.SelectedChannel.Messages[listView3.SelectedItems[0].Index]["userID"].ToString())));
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("OutOfRange")) return;
                MessageBox.Show(ex.ToString());
            }
        }

        private void ListView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count != 0)
            {
                ulong id = 0;

                id = ulong.Parse(Server.CurrentUser.SelectedChannel.Messages[listView3.SelectedItems[0].Index]["userID"].ToString());


                if (id == Server.CurrentUser.ID)
                {
                    Chat.Items[0].Enabled = false;
                }
                else
                {
                    Chat.Items[0].Enabled = true;
                }
            }
            else
            {
                Chat.Items[0].Enabled = false;
            }
        }

        public void sendfriend(SocketUser user, bool accept)
        {
            Server.SendFriendResult(user, accept);
        }
    }
}
