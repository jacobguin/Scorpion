namespace Scorpion_Client.Better_Better_Forms.UI.MainForm
{
    partial class FriendsMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FriendManager = new MetroFramework.Controls.MetroTabControl();
            this.Online = new MetroFramework.Controls.MetroTabPage();
            this.online1 = new Scorpion_Client.Better_Better_Forms.UI.Friends_Menu.Online();
            this.Aff_Friends = new MetroFramework.Controls.MetroTabPage();
            this.online2 = new Scorpion_Client.Better_Better_Forms.UI.Friends_Menu.Online();
            this.Pending = new MetroFramework.Controls.MetroTabPage();
            this.online3 = new Scorpion_Client.Better_Better_Forms.UI.Friends_Menu.Online();
            this.FriendManager.SuspendLayout();
            this.Online.SuspendLayout();
            this.Aff_Friends.SuspendLayout();
            this.Pending.SuspendLayout();
            this.SuspendLayout();
            // 
            // FriendManager
            // 
            this.FriendManager.Controls.Add(this.Online);
            this.FriendManager.Controls.Add(this.Aff_Friends);
            this.FriendManager.Controls.Add(this.Pending);
            this.FriendManager.Location = new System.Drawing.Point(1, 1);
            this.FriendManager.Name = "FriendManager";
            this.FriendManager.SelectedIndex = 0;
            this.FriendManager.Size = new System.Drawing.Size(755, 572);
            this.FriendManager.TabIndex = 0;
            this.FriendManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FriendManager.UseSelectable = true;
            // 
            // Online
            // 
            this.Online.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Online.Controls.Add(this.online1);
            this.Online.HorizontalScrollbarBarColor = true;
            this.Online.HorizontalScrollbarHighlightOnWheel = false;
            this.Online.HorizontalScrollbarSize = 10;
            this.Online.Location = new System.Drawing.Point(4, 38);
            this.Online.Name = "Online";
            this.Online.Size = new System.Drawing.Size(747, 530);
            this.Online.TabIndex = 0;
            this.Online.Text = "Online";
            this.Online.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Online.VerticalScrollbarBarColor = true;
            this.Online.VerticalScrollbarHighlightOnWheel = false;
            this.Online.VerticalScrollbarSize = 10;
            // 
            // online1
            // 
            this.online1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.online1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.online1.Location = new System.Drawing.Point(1, 1);
            this.online1.Name = "online1";
            this.online1.Size = new System.Drawing.Size(747, 529);
            this.online1.TabIndex = 2;
            // 
            // Aff_Friends
            // 
            this.Aff_Friends.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Aff_Friends.Controls.Add(this.online2);
            this.Aff_Friends.HorizontalScrollbarBarColor = true;
            this.Aff_Friends.HorizontalScrollbarHighlightOnWheel = false;
            this.Aff_Friends.HorizontalScrollbarSize = 10;
            this.Aff_Friends.Location = new System.Drawing.Point(4, 38);
            this.Aff_Friends.Name = "Aff_Friends";
            this.Aff_Friends.Size = new System.Drawing.Size(747, 530);
            this.Aff_Friends.TabIndex = 1;
            this.Aff_Friends.Text = "All Friends";
            this.Aff_Friends.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Aff_Friends.VerticalScrollbarBarColor = true;
            this.Aff_Friends.VerticalScrollbarHighlightOnWheel = false;
            this.Aff_Friends.VerticalScrollbarSize = 10;
            // 
            // online2
            // 
            this.online2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.online2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.online2.Location = new System.Drawing.Point(1, 1);
            this.online2.Name = "online2";
            this.online2.Size = new System.Drawing.Size(747, 529);
            this.online2.TabIndex = 2;
            // 
            // Pending
            // 
            this.Pending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pending.Controls.Add(this.online3);
            this.Pending.HorizontalScrollbarBarColor = true;
            this.Pending.HorizontalScrollbarHighlightOnWheel = false;
            this.Pending.HorizontalScrollbarSize = 10;
            this.Pending.Location = new System.Drawing.Point(4, 38);
            this.Pending.Name = "Pending";
            this.Pending.Size = new System.Drawing.Size(747, 530);
            this.Pending.TabIndex = 2;
            this.Pending.Text = "Pending";
            this.Pending.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Pending.VerticalScrollbarBarColor = true;
            this.Pending.VerticalScrollbarHighlightOnWheel = false;
            this.Pending.VerticalScrollbarSize = 10;
            // 
            // online3
            // 
            this.online3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.online3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.online3.Location = new System.Drawing.Point(1, 1);
            this.online3.Name = "online3";
            this.online3.Size = new System.Drawing.Size(748, 528);
            this.online3.TabIndex = 2;
            // 
            // FriendsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.FriendManager);
            this.Name = "FriendsMenu";
            this.Size = new System.Drawing.Size(755, 572);
            this.FriendManager.ResumeLayout(false);
            this.Online.ResumeLayout(false);
            this.Aff_Friends.ResumeLayout(false);
            this.Pending.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl FriendManager;
        private MetroFramework.Controls.MetroTabPage Online;
        private MetroFramework.Controls.MetroTabPage Aff_Friends;
        private MetroFramework.Controls.MetroTabPage Pending;
        private Friends_Menu.Online online1;
        private Friends_Menu.Online online2;
        private Friends_Menu.Online online3;
    }
}
