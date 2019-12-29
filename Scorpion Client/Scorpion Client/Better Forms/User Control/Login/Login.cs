using System;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                server = new Server.LogIn(metroTextBox1.Text, metroTextBox2.Text);
                Program.LF.Hide();
                new Better_Better_Forms.MainForm(server).Show();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                if (ex.Message == "An Invalid json was sent to the server")
                {
                    server = null;
                    MessageBox.Show("An Invalid json was sent to the server.");
                }
                else if (ex.Message == "Invaled credentials")
                {
                    label2.Invoke(new MethodInvoker(() => { label2.Visible = true; }));
                    server = null;
                }
                else
                {
                    MessageBox.Show($"Something went weong: {ex.Message}");
                }
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
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    server = new Server.LogIn(metroTextBox1.Text, metroTextBox2.Text);
                    Program.LF.Hide();
                    new Better_Better_Forms.MainForm(server).Show();
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "An Invalid json was sent to the server")
                    {
                        server = null;
                        MessageBox.Show("An Invalid json was sent to the server.");
                    }
                    else if (ex.Message == "Invaled credentials")
                    {
                        label2.Invoke(new MethodInvoker(() => { label2.Visible = true; }));
                        server = null;
                    }
                    else
                    {
                        MessageBox.Show($"Something went weong: {ex.Message}");
                    }
                }
            }
        }
    }
}
