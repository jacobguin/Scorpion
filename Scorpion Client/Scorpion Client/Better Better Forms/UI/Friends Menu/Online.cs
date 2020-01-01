using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scorpion_Client.Better_Better_Forms.UI.Friends_Menu
{
    public partial class Online : UserControl
    {
        public Online()
        {
            InitializeComponent();
        }

        public void addcontrol(Control c)
        {
            flowLayoutPanel1.Controls.Add(c);
        }
    }
}
