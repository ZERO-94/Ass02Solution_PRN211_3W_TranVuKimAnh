namespace SalesWinApp
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.memberManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.productManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.orderManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.myProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMembers1 = new SalesWinApp.frmMembers();
            this.frmOrders1 = new SalesWinApp.frmOrders();
            this.frmProducts1 = new SalesWinApp.frmProducts();
            this.frmProfile1 = new SalesWinApp.frmProfile();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memberManagement,
            this.productManagement,
            this.orderManagement,
            this.myProfile,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // memberManagement
            // 
            this.memberManagement.Name = "memberManagement";
            this.memberManagement.Size = new System.Drawing.Size(64, 20);
            this.memberManagement.Text = "Member";
            this.memberManagement.Click += new System.EventHandler(this.memberManagement_Click);
            // 
            // productManagement
            // 
            this.productManagement.Name = "productManagement";
            this.productManagement.Size = new System.Drawing.Size(61, 20);
            this.productManagement.Text = "Product";
            this.productManagement.Click += new System.EventHandler(this.productManagement_Click);
            // 
            // orderManagement
            // 
            this.orderManagement.Name = "orderManagement";
            this.orderManagement.Size = new System.Drawing.Size(49, 20);
            this.orderManagement.Text = "Order";
            this.orderManagement.Click += new System.EventHandler(this.orderManagement_Click);
            // 
            // myProfile
            // 
            this.myProfile.Name = "myProfile";
            this.myProfile.Size = new System.Drawing.Size(73, 20);
            this.myProfile.Text = "My Profile";
            this.myProfile.Click += new System.EventHandler(this.myProfile_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.logoutToolStripMenuItem.Text = "logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // frmMembers1
            // 
            this.frmMembers1.Location = new System.Drawing.Point(12, 27);
            this.frmMembers1.Name = "frmMembers1";
            this.frmMembers1.Size = new System.Drawing.Size(776, 411);
            this.frmMembers1.TabIndex = 1;
            // 
            // frmOrders1
            // 
            this.frmOrders1.Location = new System.Drawing.Point(12, 27);
            this.frmOrders1.Name = "frmOrders1";
            this.frmOrders1.Size = new System.Drawing.Size(776, 411);
            this.frmOrders1.TabIndex = 2;
            // 
            // frmProducts1
            // 
            this.frmProducts1.Location = new System.Drawing.Point(12, 27);
            this.frmProducts1.Name = "frmProducts1";
            this.frmProducts1.Size = new System.Drawing.Size(776, 411);
            this.frmProducts1.TabIndex = 3;
            // 
            // frmProfile1
            // 
            this.frmProfile1.Location = new System.Drawing.Point(12, 27);
            this.frmProfile1.Name = "frmProfile1";
            this.frmProfile1.Size = new System.Drawing.Size(776, 411);
            this.frmProfile1.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.frmProfile1);
            this.Controls.Add(this.frmProducts1);
            this.Controls.Add(this.frmMembers1);
            this.Controls.Add(this.frmOrders1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem memberManagement;
        private System.Windows.Forms.ToolStripMenuItem productManagement;
        private System.Windows.Forms.ToolStripMenuItem orderManagement;
        private System.Windows.Forms.ToolStripMenuItem myProfile;
        private frmMembers frmMembers1;
        private frmOrders frmOrders1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private frmProducts frmProducts1;
        private frmProfile frmProfile1;
    }
}