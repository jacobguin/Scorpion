namespace Scorpion_Client.Better_Forms.User_Control.Login
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Scorpion.Net;

    public partial class Create_Account : UserControl
    {
        private Server.LogIn server;
        private string png = null;

        public Create_Account()
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
            string[] arr = new string[]
            {
                metroTextBox1.Text,
                metroTextBox3.Text,
                png,
                metroTextBox5.Text,
            };
            if (arr.Any(str => string.IsNullOrEmpty(str)))
            {
                MessageBox.Show("Please fill in all fields.");
            }
            else if (metroTextBox1.Text != metroTextBox2.Text)
            {
                MessageBox.Show("The emails do not match.");
            }
            else if (metroTextBox3.Text != metroTextBox4.Text)
            {
                MessageBox.Show("The passwords do not match.");
            }
            else
            {
                try
                {
                    if (!await Server.CreateAccount(metroTextBox5.Text, metroTextBox3.Text, metroTextBox1.Text, png)) throw new Exception("already used");
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
                        else
                        {
                            MessageBox.Show($"Something went wrong: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("already used"))
                        label2.Visible = true;
                    else
                        MessageBox.Show("Something went wrong please try again later.");
                }
            }
        }
    }
}
