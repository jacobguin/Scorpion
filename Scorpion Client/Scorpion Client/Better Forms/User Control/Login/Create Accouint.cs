using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Scorpion.Net;
using System.Threading.Tasks;

namespace Scorpion_Client.Better_Forms.User_Control.Login
{
    public partial class Create_Accouint : UserControl
    {
        Server.LogIn server;
        MainForm MF;
        string png = null;

        public Create_Accouint()
        {
            InitializeComponent();
        }

        private void LollipopButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Picture Files (*.png)|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                png = Path.GetFullPath(ofd.FileName);
                pictureBox2.Image = new Bitmap(png);
            }
            else
            {
                lollipopButton1.Enabled = true;
                png = null;
            }
        }

        private async void LollipopButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(metroTextBox1.Text))
            {
                if (!string.IsNullOrEmpty(metroTextBox3.Text))
                {
                    if (!string.IsNullOrEmpty(png))
                    {
                        if (!string.IsNullOrEmpty(metroTextBox5.Text))
                        {
                            if (metroTextBox1.Text == metroTextBox2.Text)
                            {
                                if (metroTextBox3.Text == metroTextBox4.Text)
                                {
                                    try
                                    {
                                        await Server.CreateAccount(metroTextBox5.Text, metroTextBox3.Text, metroTextBox1.Text, png);
                                        try
                                        {
                                            server = new Server.LogIn(metroTextBox1.Text, metroTextBox2.Text);
                                            Program.LF.Hide();
                                            new Better_Better_Forms.MainForm(server).Show();
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
                                    catch (Exception ex)
                                    {
                                        if (ex.Message.Contains("already used"))
                                        {
                                            label2.Visible = true;
                                        }
                                        else
                                        { MessageBox.Show("Something went wrong please try again latter."); }
                                        
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("The passwords do not match.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("The emails do not match.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill in all fields.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please fill in all fields.");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all fields.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
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

        private void main()
        {
            MF = new MainForm(server);
            if (MF.InvokeRequired == true)
            {
                MF.Invoke(new MethodInvoker(() => { MF.Show(); }));
            }
            else
            {
                MF.Show();
            }
        }
    }
}
