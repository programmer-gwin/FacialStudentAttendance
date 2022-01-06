namespace FacialStudentAttendance
{
    partial class HowDoI
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Add Client");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Update Client");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Client", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Add Lot");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Update Lot");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Lot", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Add Contract");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Update Contract");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Contract", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Add Payment");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Update Payment");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Daily Collection");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Monthly Collection");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("List of Client\'s Payment");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Report", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Payment", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Collectables");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Sales");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Sold Lots");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("SMS Notification");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Matured Accounts");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Summary");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HowDoI));
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.RichTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.OKButton);
            this.GroupBox1.Controls.Add(this.TreeView1);
            this.GroupBox1.Location = new System.Drawing.Point(12, 71);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(158, 327);
            this.GroupBox1.TabIndex = 32;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Content";
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.OKButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OKButton.ForeColor = System.Drawing.Color.White;
            this.OKButton.Location = new System.Drawing.Point(41, 287);
            this.OKButton.Margin = new System.Windows.Forms.Padding(2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(65, 24);
            this.OKButton.TabIndex = 31;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // TreeView1
            // 
            this.TreeView1.BackColor = System.Drawing.SystemColors.Info;
            this.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeView1.Location = new System.Drawing.Point(3, 16);
            this.TreeView1.Name = "TreeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Add Client";
            treeNode2.Name = "Node3";
            treeNode2.Text = "Update Client";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Client";
            treeNode4.Name = "Node5";
            treeNode4.Text = "Add Lot";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Update Lot";
            treeNode6.Name = "Node4";
            treeNode6.Text = "Lot";
            treeNode7.Name = "Node8";
            treeNode7.Text = "Add Contract";
            treeNode8.Name = "Node9";
            treeNode8.Text = "Update Contract";
            treeNode9.Name = "Node7";
            treeNode9.Text = "Contract";
            treeNode10.Name = "Node11";
            treeNode10.Text = "Add Payment";
            treeNode11.Name = "Node13";
            treeNode11.Text = "Update Payment";
            treeNode12.Name = "Node19";
            treeNode12.Text = "Daily Collection";
            treeNode13.Name = "Node20";
            treeNode13.Text = "Monthly Collection";
            treeNode14.Name = "Node21";
            treeNode14.Text = "List of Client\'s Payment";
            treeNode15.Name = "Node18";
            treeNode15.Text = "Report";
            treeNode16.Name = "Node10";
            treeNode16.Text = "Payment";
            treeNode17.Name = "Node16";
            treeNode17.Text = "Collectables";
            treeNode18.Name = "Node17";
            treeNode18.Text = "Sales";
            treeNode19.Name = "Node22";
            treeNode19.Text = "Sold Lots";
            treeNode20.Name = "Node23";
            treeNode20.Text = "SMS Notification";
            treeNode21.Name = "Node24";
            treeNode21.Text = "Matured Accounts";
            treeNode22.Name = "Node25";
            treeNode22.Text = "Summary";
            this.TreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode9,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            this.TreeView1.PathSeparator = "aa";
            this.TreeView1.Size = new System.Drawing.Size(152, 308);
            this.TreeView1.TabIndex = 1;
            this.TreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // RichTextBox1
            // 
            this.RichTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.RichTextBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox1.Location = new System.Drawing.Point(172, 77);
            this.RichTextBox1.Name = "RichTextBox1";
            this.RichTextBox1.Size = new System.Drawing.Size(340, 318);
            this.RichTextBox1.TabIndex = 31;
            this.RichTextBox1.Text = "";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.PictureBox1);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Location = new System.Drawing.Point(1, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(521, 56);
            this.Panel1.TabIndex = 33;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(179, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(337, 38);
            this.Label1.TabIndex = 26;
            this.Label1.Text = "FACIAL RECOGNITION BASED\r\nSTUDENT ATTENDANCE MANAGEMENT SYSTEM";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(-1, 2);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(50, 48);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(49, 16);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(111, 23);
            this.Label6.TabIndex = 0;
            this.Label6.Text = "How Do I";
            // 
            // HowDoI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 402);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.RichTextBox1);
            this.Controls.Add(this.Panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HowDoI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "How Do I? Help";
            this.GroupBox1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button OKButton;
        internal System.Windows.Forms.TreeView TreeView1;
        internal System.Windows.Forms.RichTextBox RichTextBox1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label6;
    }
}