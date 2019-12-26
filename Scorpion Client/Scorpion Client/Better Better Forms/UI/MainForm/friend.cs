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
    public partial class friend : UserControl
    {
        public friend(Image Icon, string Username)
        {
            InitializeComponent();
            label1.Text = Username;
            pictureBox1.Image = Icon;
        }
    }
}
