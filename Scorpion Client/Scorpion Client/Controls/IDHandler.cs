namespace Scorpion_Client.Controls
{
    public class IDHandler
    {
        public static string VerifyUserTag(short tag)
        {
            if (tag != -1)
            {
                string str = $"000{tag}";
                return str.Substring(str.Length - 4);
            }
            else
            {
                return "Developer";
            }
        }
    }
}
