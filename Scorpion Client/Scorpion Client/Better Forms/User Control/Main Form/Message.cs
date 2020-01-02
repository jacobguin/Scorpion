namespace Scorpion_Client.Better_Forms.User_Control.Main_Form
{
    using System;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Scorpion.Net;
    using Scorpion.Net.Sockets;
    using Scorpion_Client.Controls;

    public partial class Message : UserControl
    {
        private readonly SocketMessage @this = null;
        private readonly Server.LogIn ser = null;
        private Better_Better_Forms.MainForm t = null;
        public event Func<ulong, Task> RefreshChat;

        public Message(SocketMessage msg, FlowLayoutPanel panel, Server.LogIn server, Better_Better_Forms.MainForm text)
        {
            InitializeComponent();
            t = text;
            panel.SizeChanged += Panel_SizeChanged;
            @this = msg;
            ser = server;
            Width = panel.Size.Width - 25;
            Username.Text = msg.Author.UserName;
            Text.Text = msg.Content;
            Size sz = new Size(Width - 40, int.MaxValue);
            sz = TextRenderer.MeasureText(Text.Text, Text.Font, sz, TextFormatFlags.WordBreak);
            Text.Height = sz.Height;
            pictureBox1.Image = Imagery.CropToCircle(msg.Author.Avatar, Theme.MainForm.Controles.Text.Background);
            Height = 32 + (Text.Height - 5);
            if (server.CurrentUser.ID == msg.Author.ID) addFriendToolStripMenuItem.Enabled = false;
            else if (msg.Author.ID == 0) addFriendToolStripMenuItem.Enabled = false;
            else if (msg.Author.FriendStatus == FriendStatus.Friends) addFriendToolStripMenuItem.Enabled = false;
            else if (msg.Author.FriendStatus == FriendStatus.PendingIN) addFriendToolStripMenuItem.Enabled = false;
            else if (msg.Author.FriendStatus == FriendStatus.PendingOut) addFriendToolStripMenuItem.Enabled = false;
            SetTheme();
            Theme.FileWatcher.Changed += FileWatcher_Changed;
        }

        private void FileWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            if (e.Name != Theme.CurentTheme) return;
            SetTheme();
        }

        private void Panel_SizeChanged(object sender, EventArgs e)
        {
            new Task(new Action(() => Task.Delay(1000)));
            Width = t.Siz - 25;
            Size sz = new Size(Width - 40, int.MaxValue);
            sz = TextRenderer.MeasureText(Text.Text, Text.Font, sz, TextFormatFlags.WordBreak);
            Text.Height = sz.Height;
            Height = 32 + (Text.Height - 5);
        }

        private void SetTheme()
        {
            Username.ForeColor = Theme.MainForm.Controles.Message.Username;
            Username.LinkColor = Theme.MainForm.Controles.Message.Username;
            Username.ActiveLinkColor = Theme.MainForm.Controles.Message.Username;
            Username.VisitedLinkColor = Theme.MainForm.Controles.Message.Username;
            Text.ForeColor = Theme.MainForm.Controles.Message.Text;
            pictureBox1.Image = Imagery.CropToCircle(@this.Author.Avatar, Theme.MainForm.Controles.Text.Background);
        }

        private void AddFriendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ser.SendFriendRequest(@this.Author.ID);
                RefreshChat.Invoke(@this.Channel.ID);
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("OutOfRange")) return;
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
