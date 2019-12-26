using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scorpion_Client.Better_Better_Forms.UI.MainForm
{
    public partial class UserInfo : UserControl
    {
        public UserInfo(Image Icon, string Username, string tag)
        {
            InitializeComponent();
            pictureBox1.Image = Icon;
            label1.Text = Username;
            label2.Text = tag;
        }
    }
}
