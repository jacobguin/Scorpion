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
            Friend x = new Friend(friend, ui, scorpion);
            x.DMOpen += X_DMOpen;
            Selector.Controls.Add(x);
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
            scorpion.UpdateStatus(UserStatus.Offline);
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
                    foreach (Newtonsoft.Json.Linq.JToken result in scorpion.CurrentUser.SelectedChannel.Messages)
                    {
                        SocketMessage message = new SocketMessage(ulong.Parse(result["msg_id"].ToString()), scorpion.CurrentUser.SelectedChannel);
                        TextArea.Controls.Add(new Better_Forms.User_Control.Main_Form.Message(message, TextArea, scorpion, this));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            scorpion.MessageReceived += Scorpion_MessageReceived;
            Theme.FileWatcher.Changed += FileWatcher_Changed;
            SetTheme();
        }

        private async Task Scorpion_MessageReceived(SocketMessage arg)
        {
            if (TextArea.InvokeRequired == false)
                TextArea.Controls.Add(new Better_Forms.User_Control.Main_Form.Message(arg, TextArea, scorpion, this));
            else
                TextArea.Invoke(new Action(() => { TextArea.Controls.Add(new Better_Forms.User_Control.Main_Form.Message(arg, TextArea, scorpion, this)); }));
        }

        private void FileWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            SetTheme();
        }

        private void SetTheme()
        {
            TextArea.BackColor = Theme.MainForm.Controles.Text.Background;
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
                foreach (Newtonsoft.Json.Linq.JToken result in scorpion.CurrentUser.SelectedChannel.Messages)
                {
                    SocketMessage message = new SocketMessage(ulong.Parse(result["msg_id"].ToString()), scorpion.CurrentUser.SelectedChannel);
                    TextArea.Controls.Add(new Better_Forms.User_Control.Main_Form.Message(message, TextArea, scorpion, this));
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
                Controls.Add(fm);
                TextArea.Hide();
                textBoxWithWaterMark1.Hide();
            }

            fm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            scorpion.UpdateStatus(UserStatus.Offline);
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
