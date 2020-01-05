namespace Scorpion_Client.Better_Better_Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Selector = new System.Windows.Forms.FlowLayoutPanel();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.manageFriendsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TextArea = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxWithWaterMark1 = new Scorpion_Client.Better_Better_Forms.UI.MainForm.TextBoxWithWaterMark();
            this.verticalLabel1 = new Scorpion_Client.Better_Better_Forms.UI.MainForm.VerticalLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.metroContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-14, -11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1113, 39);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseUp);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1048, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.Button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.Button1_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.verticalLabel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-2, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(68, 573);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // Selector
            // 
            this.Selector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Selector.ContextMenuStrip = this.metroContextMenu1;
            this.Selector.Location = new System.Drawing.Point(66, 28);
            this.Selector.Margin = new System.Windows.Forms.Padding(0);
            this.Selector.Name = "Selector";
            this.Selector.Padding = new System.Windows.Forms.Padding(7, 5, 0, 0);
            this.Selector.Size = new System.Drawing.Size(243, 510);
            this.Selector.TabIndex = 3;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageFriendsToolStripMenuItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(159, 26);
            // 
            // manageFriendsToolStripMenuItem
            // 
            this.manageFriendsToolStripMenuItem.Name = "manageFriendsToolStripMenuItem";
            this.manageFriendsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.manageFriendsToolStripMenuItem.Text = "Manage Friends";
            this.manageFriendsToolStripMenuItem.Click += new System.EventHandler(this.ManageFriendsToolStripMenuItem_Click);
            // 
            // TextArea
            // 
            this.TextArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextArea.AutoScroll = true;
            this.TextArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.TextArea.Location = new System.Drawing.Point(309, 28);
            this.TextArea.Name = "TextArea";
            this.TextArea.Size = new System.Drawing.Size(750, 510);
            this.TextArea.TabIndex = 5;
            this.TextArea.ClientSizeChanged += new System.EventHandler(this.TextArea_ClientSizeChanged);
            // 
            // textBoxWithWaterMark1
            // 
            this.textBoxWithWaterMark1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBoxWithWaterMark1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxWithWaterMark1.Location = new System.Drawing.Point(309, 542);
            this.textBoxWithWaterMark1.Multiline = true;
            this.textBoxWithWaterMark1.Name = "textBoxWithWaterMark1";
            this.textBoxWithWaterMark1.Size = new System.Drawing.Size(750, 56);
            this.textBoxWithWaterMark1.TabIndex = 6;
            this.textBoxWithWaterMark1.Watermark = "Hey There budy";
            this.textBoxWithWaterMark1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxWithWaterMark1_KeyDown);
            // 
            // verticalLabel1
            // 
            this.verticalLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.verticalLabel1.BackColor = System.Drawing.Color.Transparent;
            this.verticalLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verticalLabel1.ForeColor = System.Drawing.Color.White;
            this.verticalLabel1.Location = new System.Drawing.Point(3, 0);
            this.verticalLabel1.Name = "verticalLabel1";
            this.verticalLabel1.NewText = "Servers  Coming Soon.........";
            this.verticalLabel1.RotateAngle = -90;
            this.verticalLabel1.Size = new System.Drawing.Size(42, 7473);
            this.verticalLabel1.TabIndex = 1;
            this.verticalLabel1.Text = "Servers Coming Soon...";
            this.verticalLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1060, 598);
            this.Controls.Add(this.textBoxWithWaterMark1);
            this.Controls.Add(this.TextArea);
            this.Controls.Add(this.Selector);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.metroContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel Selector;
        private System.Windows.Forms.FlowLayoutPanel TextArea;
        private System.Windows.Forms.Button button1;
        private UI.MainForm.VerticalLabel verticalLabel1;
        private UI.MainForm.TextBoxWithWaterMark textBoxWithWaterMark1;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private System.Windows.Forms.ToolStripMenuItem manageFriendsToolStripMenuItem;
    }
}