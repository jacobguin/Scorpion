namespace Scorpion_Client.Better_Better_Forms
{
    using System;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Scorpion.Net;
    using Scorpion.Net.Sockets;
    using Scorpion_Client.Better_Better_Forms.UI.MainForm;

    public partial class MainForm : Form
    {
        public int Siz = 771;
        private const int CSDROPSHADOW = 0x30000;
        private readonly Server.LogIn scorpion;
        private UserInfo ui;
        private FriendsMenu fm = null;
        private bool mouseDown;
        private Point lastLocation;
        private bool servercon = true;

        public MainForm(Server.LogIn server)
        {
            scorpion = server;
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CSDROPSHADOW;
                return cp;
            }
        }

        public void AddFriend(SocketUser friend)
        {
            try
            {
                Friend x = new Friend(friend, ui, scorpion);
                x.DMOpen += X_DMOpen;
                if (Selector.InvokeRequired)
                {
                    Selector.Invoke(new Action(() =>
                    {
                        Selector.Controls.Add(x);
                    }));
                }
                else
                {
                    Selector.Controls.Add(x);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UnHide()
        {
            textBoxWithWaterMark1.Show();
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            scorpion.LogOut();
            Application.Exit();
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = scorpion.RequestImage(Assets.Type.Client, "Title.png");
            try
            {
                ui = new UserInfo(scorpion.CurrentUser)
                {
                    Location = new Point(66, 538),
                };
                Controls.Add(ui);
                if (scorpion.CurrentUser.Friends != null)
                {
                    foreach (SocketUser friend in scorpion.CurrentUser.Friends)
                        AddFriend(friend);
                }

                if (scorpion.CurrentUser.SelectedChannel.Messages != null)
                {
                    foreach (SocketMessage message in scorpion.CurrentUser.SelectedChannel.Messages)
                    {
                        Better_Forms.User_Control.Main_Form.Message m = new Better_Forms.User_Control.Main_Form.Message(message, TextArea, scorpion, this);
                        m.RefreshChat += RefreshChat;
                        TextArea.Controls.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            scorpion.MessageReceived += Scorpion_MessageReceived;
            Theme.FileWatcher.Changed += FileWatcher_Changed;
            scorpion.ServerShutdown += Scorpion_ServerShutdown;
            scorpion.FriendRequestResult += Scorpion_FriendRequestResult;
            SetTheme();
        }

        private async Task Scorpion_FriendRequestResult(SocketUser arg1, bool arg2)
        {
            if (arg2 == true)
            {
                AddFriend(arg1);
            }
        }

        private async Task Scorpion_ServerShutdown()
        {
            MessageBox.Show("Scorpion servers have went offline. If we did not broadcast this in the global chat, We will try to fix this problem as fast as we can.", "Sorry for the inconvenience");
            servercon = false;
            Application.Exit();
            Environment.Exit(0);
        }

        private async Task Scorpion_MessageReceived(SocketMessage arg)
        {
            if (TextArea.InvokeRequired == false)
            {
                AddMsg(arg);
            }
            else
            {
                BeginInvoke(new MethodInvoker(new Action(() => { AddMsg(arg); })));
            }
        }

        private void AddMsg(SocketMessage msg)
        {
            if (msg.Channel.ID != scorpion.CurrentUser.SelectedChannel.ID) return;
            Better_Forms.User_Control.Main_Form.Message m = new Better_Forms.User_Control.Main_Form.Message(msg, TextArea, scorpion, this);
            m.RefreshChat += RefreshChat;
            TextArea.Controls.Add(m);
        }

        private void FileWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            SetTheme();
        }

        private void SetTheme()
        {
            TextArea.BackColor = Theme.MainForm.Controles.Text.Background;
            textBoxWithWaterMark1.ForeColor = Theme.MainForm.Controles.Message.Text;
        }

        private async Task X_DMOpen(ulong arg)
        {
            if (fm != null)
            {
                fm.Hide();
                TextArea.Show();
                textBoxWithWaterMark1.Show();
            }

            scorpion.ChangeChannel(new SocketChannel(arg));
            TextArea.Controls.Clear();
            if (scorpion.CurrentUser.SelectedChannel.Messages != null)
            {
                foreach (SocketMessage message in scorpion.CurrentUser.SelectedChannel.Messages)
                {
                    Better_Forms.User_Control.Main_Form.Message m = new Better_Forms.User_Control.Main_Form.Message(message, TextArea, scorpion, this);
                    m.RefreshChat += RefreshChat;
                    TextArea.Controls.Add(m);
                }
            }
        }

        private async Task RefreshChat(SocketMessage arg)
        {
            if (fm != null)
            {
                fm.Hide();
                TextArea.Show();
                textBoxWithWaterMark1.Show();
            }

            TextArea.Controls.Clear();
            if (scorpion.CurrentUser.SelectedChannel.Messages != null)
            {
                foreach (SocketMessage message in scorpion.CurrentUser.SelectedChannel.Messages)
                {
                    Better_Forms.User_Control.Main_Form.Message m = new Better_Forms.User_Control.Main_Form.Message(message, TextArea, scorpion, this);
                    m.RefreshChat += RefreshChat;
                    TextArea.Controls.Add(m);
                }
            }
        }

        private void TextArea_ClientSizeChanged(object sender, EventArgs e)
        {
            Siz = TextArea.Size.Width;
        }

        private void TextBoxWithWaterMark1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(textBoxWithWaterMark1.Text)) return;
                if (string.IsNullOrWhiteSpace(textBoxWithWaterMark1.Text)) return;
                scorpion.SendMessage(textBoxWithWaterMark1.Text, scorpion.CurrentUser.SelectedChannel.ID);
                textBoxWithWaterMark1.Clear();
            }
        }

        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            TextArea.VerticalScroll.Value = e.NewValue;
        }

        private void ManageFriendsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fm == null)
            {
                fm = new FriendsMenu(scorpion, Selector, ui, TextArea, this)
                {
                    Location = TextArea.Location,
                };
            }

            fm.Reload();
            Controls.Add(fm);
            TextArea.Hide();
            textBoxWithWaterMark1.Hide();
            fm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (servercon) scorpion.UpdateStatus(UserStatus.Offline);
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
