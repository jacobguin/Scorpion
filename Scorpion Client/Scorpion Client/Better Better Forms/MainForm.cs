using Scorpion.net;
using Scorpion.net.Sockets;
using Scorpion_Client.Better_Better_Forms.UI.MainForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scorpion_Client.Better_Better_Forms
{
    public partial class MainForm : Form
    {
        private Server.LogIn Scorpion;
        private UserInfo ui;

        public MainForm(Server.LogIn server)
        {
            Scorpion = server;
            InitializeComponent();
        }

        private const int CS_DROPSHADOW = 0x30000;
        private bool mouseDown;
        private Point lastLocation;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Scorpion.RequestImage(Assets.Type.client, "Title.png");
            try
            {
                ui = new UserInfo(Scorpion.CurrentUser);
                ui.Location = new Point(66, 538);
                this.Controls.Add(ui);
                if (Scorpion.CurrentUser.Friends != null)
                {
                    foreach (SocketUser Friend in Scorpion.CurrentUser.Friends)
                    {
                        AddFriend(Friend);
                    }
                }

                if (Scorpion.CurrentUser.SelectedChannel.Messages != null)
                {
                    foreach (var result in Scorpion.CurrentUser.SelectedChannel.Messages)
                    {
                        SocketMessage message = new SocketMessage(ulong.Parse(result["msg_id"].ToString()), Scorpion.CurrentUser.SelectedChannel);
                        TextArea.Controls.Add(new Better_Forms.User_Control.Main_Form.Message(message, TextArea, Scorpion, this));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Theme.FileWatcher.Changed += FileWatcher_Changed;
            SetTheme();
        }

        private void FileWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            SetTheme();
        }

        private void SetTheme()
        {
            TextArea.BackColor = Theme.MainForm.Controles.Text.Background;
        }

        public void AddFriend(SocketUser Friend)
        {
            var x = new friend(Friend, ui, Scorpion);
            x.DMOpen += X_DMOpen;
            Selector.Controls.Add(x);
        }

        private async Task X_DMOpen(ulong arg)
        {
            Scorpion.ChangeChannel(new SocketChannel(arg));
            TextArea.Controls.Clear();
            if (Scorpion.CurrentUser.SelectedChannel.Messages != null)
            {
                foreach (var result in Scorpion.CurrentUser.SelectedChannel.Messages)
                {
                    SocketMessage message = new SocketMessage(ulong.Parse(result["msg_id"].ToString()), Scorpion.CurrentUser.SelectedChannel);
                    TextArea.Controls.Add(new Better_Forms.User_Control.Main_Form.Message(message, TextArea, Scorpion, this)) ;
                }
            }
        }

        public int siz = 771;

        private void TextArea_ClientSizeChanged(object sender, EventArgs e)
        {
            siz = TextArea.Size.Width;
        }

        private void textBoxWithWaterMark1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Scorpion.SendMessage(textBoxWithWaterMark1.Text, Scorpion.CurrentUser.SelectedChannel.ID);
                textBoxWithWaterMark1.Clear();
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            TextArea.VerticalScroll.Value = e.NewValue;
        }
    }
}
