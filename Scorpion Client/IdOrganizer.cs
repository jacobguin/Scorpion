using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorpion_Client
{
    public class IdOrganizer
    {
        public static string GetUserTag(short id)
        {
            string tag;
            if (id.ToString().Length == 1) tag = $"000{id}";
            else if (id.ToString().Length == 2) tag = $"00{id}";
            else if (id.ToString().Length == 3) tag = $"0{id}";
            else tag = $"{id}";
            return tag;
        }
    }
}
