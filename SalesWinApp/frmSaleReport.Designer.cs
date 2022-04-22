namespace SalesWinApp
{
    partial class frmSaleReport
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
            this.soldProductDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMoney = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.soldProductDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // soldProductDataGrid
            // 
            this.soldProductDataGrid.AllowUserToAddRows = false;
            this.soldProductDataGrid.AllowUserToDeleteRows = false;
            this.soldProductDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.soldProductDataGrid.Location = new System.Drawing.Point(42, 87);
            this.soldProductDataGrid.MultiSelect = false;
            this.soldProductDataGrid.Name = "soldProductDataGrid";
            this.soldProductDataGrid.ReadOnly = true;
            this.soldProductDataGrid.RowTemplate.Height = 25;
            this.soldProductDataGrid.Size = new System.Drawing.Size(706, 268);
            this.soldProductDataGrid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Of Income: ";
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.Location = new System.Drawing.Point(145, 41);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(44, 15);
            this.lbMoney.TabIndex = 2;
            this.lbMoney.Text = "money";
            // 
            // frmSaleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 384);
            this.Controls.Add(this.lbMoney);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.soldProductDataGrid);
            this.Name = "frmSaleReport";
            this.Text = "frmSaleReport";
            this.Load += new System.EventHandler(this.frmSaleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.soldProductDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView soldProductDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMoney;
    }
}