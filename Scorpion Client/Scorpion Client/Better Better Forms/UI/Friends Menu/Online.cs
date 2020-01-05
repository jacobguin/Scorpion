namespace Scorpion_Client.Better_Better_Forms.UI.Friends_Menu
{
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Scorpion.Net.Sockets;

    public partial class Online : UserControl
    {
        public Online()
        {
            InitializeComponent();
        }

        public void AddControl(Friend c)
        {
            c.Result += C_Result;
            flowLayoutPanel1.Controls.Add(c);
        }

        public void Clear()
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private async Task C_Result(Friend arg1, bool arg2, SocketUser arg3)
        {
            flowLayoutPanel1.Controls.Remove(arg1);
        }
    }
}
