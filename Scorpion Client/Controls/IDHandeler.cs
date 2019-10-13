using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scorpion_Client.Controls
{
    public class IDHandeler
    {

        public static string VerifyUserTag(short tag)
        {
            if (tag != -1)
            {
                int num = 4 - tag.ToString().Length;
                string str = null;
                for (int i = 0; i < num; i++) str += "0";
                return str += tag.ToString();
            }
            else
            {
                return "Developer";
            }
        }
    }
}
