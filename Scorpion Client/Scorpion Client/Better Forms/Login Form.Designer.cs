using Scorpion_Client.Better_Forms.User_Control.Login;

namespace Scorpion_Client.Better_Forms
{
    partial class Login_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.login1 = new Scorpion_Client.Better_Forms.User_Control.Login.Login();
            this.create_Accouint1 = new Scorpion_Client.Better_Forms.User_Control.Login.Create_Account();
            this.SuspendLayout();
            // 
            // login1
            // 
            this.login1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.login1.Location = new System.Drawing.Point(11, 28);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(290, 418);
            this.login1.TabIndex = 1;
            // 
            // create_Accouint1
            // 
            this.create_Accouint1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.create_Accouint1.Location = new System.Drawing.Point(11, 28);
            this.create_Accouint1.Name = "create_Accouint1";
            this.create_Accouint1.Size = new System.Drawing.Size(290, 418);
            this.create_Accouint1.TabIndex = 0;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 451);
            this.Controls.Add(this.login1);
            this.Controls.Add(this.create_Accouint1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login_Form";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Login";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_Form_FormClosing);
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Create_Account create_Accouint1;
        private Login login1;
    }
}