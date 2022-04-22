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
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.createOrder);
            this.Controls.Add(this.deleteOrder);
            this.Controls.Add(this.updateOrder);
            this.Controls.Add(this.orderDataGrid);
            this.Name = "frmOrders";
            this.Size = new System.Drawing.Size(776, 411);
            this.Load += new System.EventHandler(this.frmOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView orderDataGrid;
        private System.Windows.Forms.Button updateOrder;
        private System.Windows.Forms.Button deleteOrder;
        private System.Windows.Forms.Button createOrder;
    }
}
