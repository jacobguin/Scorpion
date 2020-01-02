namespace Scorpion_Client.Controls
{
    public class IDHandler
    {
        public static string VerifyUserTag(short tag)
        {
            if (tag != -1)
            {
                return $"000{tag}".Substring(-4);
            }
            else
            {
                return "Developer";
            }
        }
    }
}
