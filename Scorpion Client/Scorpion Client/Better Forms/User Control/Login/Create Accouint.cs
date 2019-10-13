using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Scorpion.net;
using FileTransferProtocalLibrary;

namespace Scorpion_Client.Better_Forms.User_Control.Login
{
    public partial class Create_Accouint : UserControl
    {
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

        private void LollipopButton2_Click(object sender, EventArgs e)
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
                                        ulong id = Server.CreateAccount(metroTextBox5.Text, metroTextBox3.Text, metroTextBox1.Text, png);
                                        Form.ActiveForm.Hide();
                                        MainForm MainForm = new MainForm(id, new FTP($"ftp://{HiddenInfo.DNS}/Jacob/Program%20Files/Scorpion/", HiddenInfo.FTP.Username, HiddenInfo.FTP.Password));

                                        MainForm.Show();
                                        
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
    }
}
