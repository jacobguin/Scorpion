namespace Scorpion_Client.Better_Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.text1 = new Scorpion_Client.Better_Forms.User_Control.Main_Form.Text();
            this.friends1 = new Scorpion_Client.Better_Forms.User_Control.Main_Form.Friends();
            this.SuspendLayout();
            // 
            // text1
            // 
            this.text1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text1.BackColor = System.Drawing.Color.Transparent;
            this.text1.Location = new System.Drawing.Point(16, 51);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(1001, 554);
            this.text1.TabIndex = 2;
            // 
            // friends1
            // 
            this.friends1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friends1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.friends1.Location = new System.Drawing.Point(347, 51);
            this.friends1.Name = "friends1";
            this.friends1.Size = new System.Drawing.Size(666, 554);
            this.friends1.TabIndex = 1;
            this.friends1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 605);
            this.Controls.Add(this.friends1);
            this.Controls.Add(this.text1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Scorpion";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private User_Control.Main_Form.Friends friends1;
        private User_Control.Main_Form.Text text1;
    }
}