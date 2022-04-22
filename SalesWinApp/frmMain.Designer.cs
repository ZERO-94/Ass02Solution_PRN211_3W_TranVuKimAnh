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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.memberManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.productManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.orderManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.myProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.frmMembers1 = new SalesWinApp.frmMembers();
            this.frmProducts1 = new SalesWinApp.frmProducts();
            this.frmOrders1 = new SalesWinApp.frmOrders();
            this.frmProfile1 = new SalesWinApp.frmProfile();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myProfile,
            this.memberManagement,
            this.productManagement,
            this.orderManagement});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // memberManagement
            // 
            this.memberManagement.Name = "memberManagement";
            this.memberManagement.Size = new System.Drawing.Size(138, 20);
            this.memberManagement.Text = "Member management";
            this.memberManagement.Click += new System.EventHandler(this.memberManagement_Click);
            // 
            // productManagement
            // 
            this.productManagement.Name = "productManagement";
            this.productManagement.Size = new System.Drawing.Size(135, 20);
            this.productManagement.Text = "Product management";
            this.productManagement.Click += new System.EventHandler(this.productManagement_Click);
            // 
            // orderManagement
            // 
            this.orderManagement.Name = "orderManagement";
            this.orderManagement.Size = new System.Drawing.Size(123, 20);
            this.orderManagement.Text = "Order management";
            this.orderManagement.Click += new System.EventHandler(this.orderManagement_Click);
            // 
            // myProfile
            // 
            this.myProfile.Name = "myProfile";
            this.myProfile.Size = new System.Drawing.Size(73, 20);
            this.myProfile.Text = "My Profile";
            this.myProfile.Click += new System.EventHandler(this.myProfile_Click);
            // 
            // frmMembers1
            // 
            this.frmMembers1.Location = new System.Drawing.Point(12, 27);
            this.frmMembers1.Name = "frmMembers1";
            this.frmMembers1.Size = new System.Drawing.Size(776, 411);
            this.frmMembers1.TabIndex = 1;
            // 
            // frmProducts1
            // 
            this.frmProducts1.Location = new System.Drawing.Point(12, 27);
            this.frmProducts1.Name = "frmProducts1";
            this.frmProducts1.Size = new System.Drawing.Size(776, 411);
            this.frmProducts1.TabIndex = 2;
            // 
            // frmOrders1
            // 
            this.frmOrders1.Location = new System.Drawing.Point(12, 27);
            this.frmOrders1.Name = "frmOrders1";
            this.frmOrders1.Size = new System.Drawing.Size(776, 411);
            this.frmOrders1.TabIndex = 3;
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
            this.Controls.Add(this.frmMembers1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.frmProducts1);
            this.Controls.Add(this.frmOrders1);
            this.Controls.Add(this.frmProfile1);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem memberManagement;
        private System.Windows.Forms.ToolStripMenuItem productManagement;
        private System.Windows.Forms.ToolStripMenuItem orderManagement;
        private System.Windows.Forms.ToolStripMenuItem myProfile;
        private frmMembers frmMembers1;
        private frmProducts frmProducts1;
        private frmOrders frmOrders1;
        private frmProfile frmProfile1;
    }
}