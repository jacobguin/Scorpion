﻿using Scorpion_Client.Better_Forms;
using System;
using System.Windows.Forms;

namespace Scorpion_Client
{
    static class Program
    {
        public static Login_Form LF = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(LF = new Login_Form());
        }
    }
}
