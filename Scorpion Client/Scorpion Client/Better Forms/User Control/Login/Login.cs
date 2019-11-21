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
using FileTransferProtocalLibrary;

namespace Scorpion_Client.Better_Forms.User_Control.Login
{
    public partial class Login : UserControl
    {
        FTP ftp = new FTP($"ftp://{HiddenInfo.DNS}/Jacob/Program%20Files/Scorpion/", HiddenInfo.FTP.Username, HiddenInfo.FTP.Password);

        public Login()
        {
            InitializeComponent();
        }

        private void LollipopButton1_Click_1(object sender, EventArgs e)
        {
            string LoginFile = ftp.DownloadString("Logins.json");
            if (LoginFile.Contains('"' + metroTextBox1.Text + '"'))
            {
                try
                {
                    JObject user = JObject.Parse(JObject.Parse(LoginFile)[metroTextBox1.Text].ToString());
                    if (metroTextBox2.Text == user["password"].ToString())
                    {
                        MainForm MainForm = new MainForm(ulong.Parse(user["id"].ToString()), ftp);
                        Form.ActiveForm.Hide();
                        MainForm.Show();
                    }
                    else
                    {
                        label2.Visible = true;
                    }

                }
                catch
                {
                    label2.Visible = true;
                }
            }
            else label2.Visible = true;
        }

        private void LollipopButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MetroTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string LoginFile = ftp.DownloadString("Logins.json");
                if (LoginFile.Contains('"' + metroTextBox1.Text + '"'))
                {
                    try
                    {
                        JObject user = JObject.Parse(JObject.Parse(LoginFile)[metroTextBox1.Text].ToString());
                        if (metroTextBox2.Text == user["password"].ToString())
                        {
                            MainForm MainForm = new MainForm(ulong.Parse(user["id"].ToString()), ftp);
                            Program.LF.Hide();
                            MainForm.Show();
                        }
                        else
                        {
                            label2.Visible = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        label2.Visible = true;
                    }
                }
                else label2.Visible = true;
            }
        }
    }
}
