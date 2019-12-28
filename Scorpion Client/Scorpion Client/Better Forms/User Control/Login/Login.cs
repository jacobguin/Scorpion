using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Scorpion.net;

namespace Scorpion_Client.Better_Forms.User_Control.Login
{
    public partial class Login : UserControl
    {
        Server.LogIn server;
        Better_Better_Forms.MainForm MF;

        public Login()
        {
            InitializeComponent();
        }

        private void LollipopButton1_Click_1(object sender, EventArgs e)
        {
            if (server != null)
            {
                server = null;
            }
            server = new Server.LogIn(metroTextBox1.Text, metroTextBox2.Text);
            server.LoginResult += Server_LoginResult;
        }

        private async Task Server_LoginResult(string arg)
        {
            if (arg == "-1")
            {
                label2.Invoke(new MethodInvoker(() => { label2.Visible = true; }));
            }
            else if (arg == "-2")
            {
                MessageBox.Show("An Invalid json was sent to the server.");
            }
            else
            {
                Invoke(new MethodInvoker(() => { main(); }));
                Program.LF.Invoke(new MethodInvoker(() => { Program.LF.Hide(); }));
            }
        }

        private async void main()
        {
            MF = new Better_Better_Forms.MainForm(server);
            if (MF.InvokeRequired == true)
            {
                MF.Invoke(new MethodInvoker(() => { MF.Show(); }));
            }
            else
            {
                MF.Show();
            }
        }

        private void LollipopButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MetroTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (server != null)
                {
                    server = null;
                }
                server = new Server.LogIn(metroTextBox1.Text, metroTextBox2.Text);
                server.LoginResult += Server_LoginResult;
            }
        }
    }
}
