namespace SalesWinApp
{
    partial class frmMembers
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
            this.createMember = new System.Windows.Forms.Button();
            this.deleteMember = new System.Windows.Forms.Button();
            this.updateMember = new System.Windows.Forms.Button();
            this.memberDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.memberDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // createMember
            // 
            this.createMember.Location = new System.Drawing.Point(632, 198);
            this.createMember.Name = "createMember";
            this.createMember.Size = new System.Drawing.Size(116, 23);
            this.createMember.TabIndex = 7;
            this.createMember.Text = "create member";
            this.createMember.UseVisualStyleBackColor = true;
            this.createMember.Click += new System.EventHandler(this.createMember_Click);
            // 
            // deleteMember
            // 
            this.deleteMember.Location = new System.Drawing.Point(632, 155);
            this.deleteMember.Name = "deleteMember";
            this.deleteMember.Size = new System.Drawing.Size(116, 23);
            this.deleteMember.TabIndex = 6;
            this.deleteMember.Text = "delete";
            this.deleteMember.UseVisualStyleBackColor = true;
            this.deleteMember.Click += new System.EventHandler(this.deleteMember_Click);
            // 
            // updateMember
            // 
            this.updateMember.Location = new System.Drawing.Point(632, 113);
            this.updateMember.Name = "updateMember";
            this.updateMember.Size = new System.Drawing.Size(116, 23);
            this.updateMember.TabIndex = 5;
            this.updateMember.Text = "update";
            this.updateMember.UseVisualStyleBackColor = true;
            this.updateMember.Click += new System.EventHandler(this.updateMember_Click);
            // 
            // memberDataGrid
            // 
            this.memberDataGrid.AllowUserToAddRows = false;
            this.memberDataGrid.AllowUserToDeleteRows = false;
            this.memberDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memberDataGrid.Location = new System.Drawing.Point(26, 114);
            this.memberDataGrid.MultiSelect = false;
            this.memberDataGrid.Name = "memberDataGrid";
            this.memberDataGrid.ReadOnly = true;
            this.memberDataGrid.RowTemplate.Height = 25;
            this.memberDataGrid.Size = new System.Drawing.Size(600, 250);
            this.memberDataGrid.TabIndex = 4;
            // 
            // frmMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.createMember);
            this.Controls.Add(this.deleteMember);
            this.Controls.Add(this.updateMember);
            this.Controls.Add(this.memberDataGrid);
            this.Name = "frmMembers";
            this.Size = new System.Drawing.Size(776, 411);
            this.Load += new System.EventHandler(this.frmMembers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memberDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createMember;
        private System.Windows.Forms.Button deleteMember;
        private System.Windows.Forms.Button updateMember;
        private System.Windows.Forms.DataGridView memberDataGrid;
    }
}
