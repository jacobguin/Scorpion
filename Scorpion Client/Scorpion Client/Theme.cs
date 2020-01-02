namespace Scorpion_Client
{
    using System;
    using System.Drawing;
    using System.IO;

    public static class Theme
    {
        public static FileSystemWatcher FileWatcher = null;
        private static readonly string DefaultTheme = ";Use hex only for color EX:#ffa500!\n[Message]\nUsername=#f00\nText=#4cff00\n\n[Text]\nBackground=#1E1E1E\n";
        private static string theme = "default.ini";

        public static string CurentTheme
        {
            get
            {
                return theme;
            }

            set
            {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Scorpion";
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                dir += "/Themes";
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                if (!File.Exists($"{dir}/{value}")) value = "default.ini";
                if (!File.Exists($"{dir}/default.ini")) File.WriteAllText($"{dir}/default.ini", DefaultTheme);
                if (FileWatcher == null) FileWatcher = new FileSystemWatcher($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}/Scorpion/Themes/");
                FileWatcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;
                FileWatcher.EnableRaisingEvents = true;
                FileWatcher.Filter = value;
                theme = value;
            }
        }

        private static void Set(string theme, string section, string key, string value)
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Scorpion";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            dir += "/Themes";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            dir += $"/{theme}";
            if (File.Exists(dir))
            {
                IniFile ini = new IniFile(dir);
                ini.IniWriteValue(section, key, value);
            }
        }

        private static string Get(string theme, string section, string key)
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/Scorpion";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            dir += "/Themes";
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            dir += "/default.ini";
            if (!File.Exists(dir)) File.WriteAllText(dir, ";Use hex only for color EX:#ffa500!\n[Message]\nUsername=#f00");
            IniFile ini = new IniFile(dir);
            return ini.IniReadValue(section, key);
        }

        private static Color StringToColor(string color)
        {
            return ColorTranslator.FromHtml(color);
        }

        public static class MainForm
        {
            public static class Controles
            {
                public static class Text
                {
                    public static Color Background
                    {
                        get
                        {
                            return StringToColor(Get(theme, "Text", "Background"));
                        }

                        set
                        {
                            Set(theme, "Text", "Background", ColorTranslator.ToHtml(value));
                        }
                    }
                }

                public static class Message
                {
                    public static Color Username
                    {
                        get
                        {
                            return StringToColor(Get(theme, "Message", "Username"));
                        }

                        set
                        {
                            Set(theme, "Message", "Username", ColorTranslator.ToHtml(value));
                        }
                    }

                    public static Color Text
                    {
                        get
                        {
                            return StringToColor(Get(theme, "Message", "Text"));
                        }

                        set
                        {
                            Set(theme, "Message", "Text", ColorTranslator.ToHtml(value));
                        }
                    }
                }
            }
        }
    }
}
