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

        public void addcontrol(Friend c)
        {
            c.Result += C_Result;
            flowLayoutPanel1.Controls.Add(c);
        }

        private async Task C_Result(Friend arg1, bool arg2, Scorpion.net.Sockets.SocketUser arg3)
        {
            flowLayoutPanel1.Controls.Remove(arg1);
        }
    }
}
