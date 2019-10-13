using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Scorpion.net.Sockets;
using FileTransferProtocalLibrary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scorpion_Client.Better_Forms
{
    public partial class MainForm : MetroForm
    {
        public MainForm(ulong User, FTP ftp)
        {
            InitializeComponent();
            text1.load(User, ftp, this);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            text1.Close();
        }

        public void Openfriend(SocketAppUser User)
        {
            friends1.load(User, this);
            friends1.Visible = true;
        }

        public void closefriend()
        {
            friends1.Visible = false;
        }

        public void add(SocketUser u)
        {
            friends1.AddFriendReq(u);
        }

        public void addf(SocketUser u, bool accept)
        {
            text1.sendfriend(u, accept);
        }
    }
}
