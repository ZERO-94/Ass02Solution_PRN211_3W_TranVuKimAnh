namespace SalesWinApp
{
    partial class frmProducts
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
            this.createProduct = new System.Windows.Forms.Button();
            this.deleteProduct = new System.Windows.Forms.Button();
            this.updateProduct = new System.Windows.Forms.Button();
            this.productDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // createProduct
            // 
            this.createProduct.Location = new System.Drawing.Point(632, 198);
            this.createProduct.Name = "createProduct";
            this.createProduct.Size = new System.Drawing.Size(116, 23);
            this.createProduct.TabIndex = 11;
            this.createProduct.Text = "create product";
            this.createProduct.UseVisualStyleBackColor = true;
            // 
            // deleteProduct
            // 
            this.deleteProduct.Location = new System.Drawing.Point(632, 155);
            this.deleteProduct.Name = "deleteProduct";
            this.deleteProduct.Size = new System.Drawing.Size(116, 23);
            this.deleteProduct.TabIndex = 10;
            this.deleteProduct.Text = "delete";
            this.deleteProduct.UseVisualStyleBackColor = true;
            // 
            // updateProduct
            // 
            this.updateProduct.Location = new System.Drawing.Point(632, 113);
            this.updateProduct.Name = "updateProduct";
            this.updateProduct.Size = new System.Drawing.Size(116, 23);
            this.updateProduct.TabIndex = 9;
            this.updateProduct.Text = "update";
            this.updateProduct.UseVisualStyleBackColor = true;
            // 
            // productDataGrid
            // 
            this.productDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGrid.Location = new System.Drawing.Point(26, 114);
            this.productDataGrid.Name = "productDataGrid";
            this.productDataGrid.RowTemplate.Height = 25;
            this.productDataGrid.Size = new System.Drawing.Size(600, 250);
            this.productDataGrid.TabIndex = 8;
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.createProduct);
            this.Controls.Add(this.deleteProduct);
            this.Controls.Add(this.updateProduct);
            this.Controls.Add(this.productDataGrid);
            this.Name = "frmProducts";
            this.Size = new System.Drawing.Size(776, 411);
            this.Load += new System.EventHandler(this.frmProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createProduct;
        private System.Windows.Forms.Button deleteProduct;
        private System.Windows.Forms.Button updateProduct;
        private System.Windows.Forms.DataGridView productDataGrid;
    }
}
