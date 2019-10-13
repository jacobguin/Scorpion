using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scorpion.net.Sockets;
using Scorpion_Client.Controls;

namespace Scorpion_Client.Better_Forms.User_Control.Main_Form
{
    public partial class Friends : UserControl
    {
        MainForm mf;
        SocketAppUser appuser;

        public Friends()
        {
            InitializeComponent();
        }

        public void load(SocketAppUser User, MainForm m)
        {
            mf = m;
            metroListView1.Items.Clear();
            Pending.Images.Clear();
            FriendImg.Images.Clear();
            if (User.Friends != null)
            {
                foreach (SocketUser friend in User.Friends)
                {
                    AddFriend(friend);
                }
            }
            if (User.PendingFriends != null)
            {
                foreach (SocketUser friend in User.PendingFriends)
                {
                    AddFriendReq(friend);
                }
            }
            appuser = User;
        }

        private void AddFriend(SocketUser Friend)
        {
            FriendImg.Images.Add(Friend.ID.ToString() + ".png", Imagery.CropToCircle(Friend.Avatar, Color.FromArgb(53, 53, 53)));
            int index = FriendImg.Images.IndexOfKey(Friend.ID.ToString() + ".png");
            ListViewItem item0 = new ListViewItem(new string[] { Friend.UserName, "", "" }, index);
            metroListView1.Items.Add(item0);
        }

        public void AddFriendReq(SocketUser Friend)
        {
            Pending.Images.Add(Friend.ID.ToString() + ".png", Imagery.CropToCircle(Friend.Avatar, Color.FromArgb(53, 53, 53)));
            int index = Pending.Images.IndexOfKey(Friend.ID.ToString() + ".png");
            ListViewItem item0 = new ListViewItem(new string[] { Friend.UserName, "", "" }, index);
            metroListView2.Items.Add(item0);
        }

        private void AddFriendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int index = metroListView2.SelectedItems[0].Index;
                mf.addf(appuser.PendingFriends[index], true);
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("OutOfRange")) return;
                MessageBox.Show(ex.ToString());
            }
        }

        private void MetroListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroListView2.SelectedItems.Count != 0)
            {
                metroContextMenu1.Items[0].Enabled = true;
            }
            else
            {
                metroContextMenu1.Items[0].Enabled = false;
            }
        }
    }
}
