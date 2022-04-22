namespace SalesWinApp
{
    partial class frmOrders
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
            this.orderDataGrid = new System.Windows.Forms.DataGridView();
            this.updateOrder = new System.Windows.Forms.Button();
            this.deleteOrder = new System.Windows.Forms.Button();
            this.createOrder = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.report = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // orderDataGrid
            // 
            this.orderDataGrid.AllowUserToAddRows = false;
            this.orderDataGrid.AllowUserToDeleteRows = false;
            this.orderDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDataGrid.Location = new System.Drawing.Point(26, 114);
            this.orderDataGrid.MultiSelect = false;
            this.orderDataGrid.Name = "orderDataGrid";
            this.orderDataGrid.ReadOnly = true;
            this.orderDataGrid.RowTemplate.Height = 25;
            this.orderDataGrid.Size = new System.Drawing.Size(600, 250);
            this.orderDataGrid.TabIndex = 0;
            // 
            // updateOrder
            // 
            this.updateOrder.Location = new System.Drawing.Point(632, 113);
            this.updateOrder.Name = "updateOrder";
            this.updateOrder.Size = new System.Drawing.Size(116, 23);
            this.updateOrder.TabIndex = 1;
            this.updateOrder.Text = "update";
            this.updateOrder.UseVisualStyleBackColor = true;
            this.updateOrder.Click += new System.EventHandler(this.updateOrder_Click);
            // 
            // deleteOrder
            // 
            this.deleteOrder.Location = new System.Drawing.Point(632, 155);
            this.deleteOrder.Name = "deleteOrder";
            this.deleteOrder.Size = new System.Drawing.Size(116, 23);
            this.deleteOrder.TabIndex = 2;
            this.deleteOrder.Text = "delete";
            this.deleteOrder.UseVisualStyleBackColor = true;
            this.deleteOrder.Click += new System.EventHandler(this.deleteOrder_Click);
            // 
            // createOrder
            // 
            this.createOrder.Location = new System.Drawing.Point(632, 198);
            this.createOrder.Name = "createOrder";
            this.createOrder.Size = new System.Drawing.Size(116, 23);
            this.createOrder.TabIndex = 3;
            this.createOrder.Text = "create order";
            this.createOrder.UseVisualStyleBackColor = true;
            this.createOrder.Click += new System.EventHandler(this.createOrder_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(320, 64);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEndDate.TabIndex = 68;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(26, 64);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtpStartDate.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 66;
            this.label3.Text = "End date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 65;
            this.label2.Text = "Start date";
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(595, 64);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(116, 23);
            this.report.TabIndex = 69;
            this.report.Text = "report";
            this.report.UseVisualStyleBackColor = true;
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.report);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.createOrder);
            this.Controls.Add(this.deleteOrder);
            this.Controls.Add(this.updateOrder);
            this.Controls.Add(this.orderDataGrid);
            this.Name = "frmOrders";
            this.Size = new System.Drawing.Size(776, 411);
            this.Load += new System.EventHandler(this.frmOrders_Load);
            this.VisibleChanged += new System.EventHandler(this.frmOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView orderDataGrid;
        private System.Windows.Forms.Button updateOrder;
        private System.Windows.Forms.Button deleteOrder;
        private System.Windows.Forms.Button createOrder;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button report;
    }
}
