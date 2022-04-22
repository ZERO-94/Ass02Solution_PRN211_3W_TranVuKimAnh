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
            this.components = new System.ComponentModel.Container();
            this.createProduct = new System.Windows.Forms.Button();
            this.deleteProduct = new System.Windows.Forms.Button();
            this.updateProduct = new System.Windows.Forms.Button();
            this.productDataGrid = new System.Windows.Forms.DataGridView();
            this.tbUnitPrice = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbUnitInStock = new System.Windows.Forms.TextBox();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbUnitInStock = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.productDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.createProduct.Click += new System.EventHandler(this.createProduct_Click);
            // 
            // deleteProduct
            // 
            this.deleteProduct.Location = new System.Drawing.Point(632, 155);
            this.deleteProduct.Name = "deleteProduct";
            this.deleteProduct.Size = new System.Drawing.Size(116, 23);
            this.deleteProduct.TabIndex = 10;
            this.deleteProduct.Text = "delete";
            this.deleteProduct.UseVisualStyleBackColor = true;
            this.deleteProduct.Click += new System.EventHandler(this.deleteProduct_Click);
            // 
            // updateProduct
            // 
            this.updateProduct.Location = new System.Drawing.Point(632, 113);
            this.updateProduct.Name = "updateProduct";
            this.updateProduct.Size = new System.Drawing.Size(116, 23);
            this.updateProduct.TabIndex = 9;
            this.updateProduct.Text = "update";
            this.updateProduct.UseVisualStyleBackColor = true;
            this.updateProduct.Click += new System.EventHandler(this.updateProduct_Click);
            // 
            // productDataGrid
            // 
            this.productDataGrid.AllowUserToAddRows = false;
            this.productDataGrid.AllowUserToDeleteRows = false;
            this.productDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGrid.Location = new System.Drawing.Point(26, 114);
            this.productDataGrid.MultiSelect = false;
            this.productDataGrid.Name = "productDataGrid";
            this.productDataGrid.ReadOnly = true;
            this.productDataGrid.RowTemplate.Height = 25;
            this.productDataGrid.Size = new System.Drawing.Size(600, 250);
            this.productDataGrid.TabIndex = 8;
            // 
            // tbUnitPrice
            // 
            this.tbUnitPrice.Location = new System.Drawing.Point(26, 76);
            this.tbUnitPrice.Name = "tbUnitPrice";
            this.tbUnitPrice.Size = new System.Drawing.Size(207, 23);
            this.tbUnitPrice.TabIndex = 12;
            this.tbUnitPrice.Validating += new System.ComponentModel.CancelEventHandler(this.tbUnitPrice_Validating);
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(26, 30);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(207, 23);
            this.tbId.TabIndex = 13;
            this.tbId.Validating += new System.ComponentModel.CancelEventHandler(this.tbId_Validating);
            // 
            // tbUnitInStock
            // 
            this.tbUnitInStock.Location = new System.Drawing.Point(300, 76);
            this.tbUnitInStock.Name = "tbUnitInStock";
            this.tbUnitInStock.Size = new System.Drawing.Size(207, 23);
            this.tbUnitInStock.TabIndex = 14;
            this.tbUnitInStock.Validating += new System.ComponentModel.CancelEventHandler(this.tbUnitInStock_Validating);
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(300, 30);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(207, 23);
            this.tbProductName.TabIndex = 15;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(574, 30);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(116, 23);
            this.search.TabIndex = 16;
            this.search.Text = "search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Unit Price";
            // 
            // lbUnitInStock
            // 
            this.lbUnitInStock.AutoSize = true;
            this.lbUnitInStock.Location = new System.Drawing.Point(300, 58);
            this.lbUnitInStock.Name = "lbUnitInStock";
            this.lbUnitInStock.Size = new System.Drawing.Size(74, 15);
            this.lbUnitInStock.TabIndex = 20;
            this.lbUnitInStock.Text = "Unit In Stock";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbUnitInStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.tbProductName);
            this.Controls.Add(this.tbUnitInStock);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.tbUnitPrice);
            this.Controls.Add(this.createProduct);
            this.Controls.Add(this.deleteProduct);
            this.Controls.Add(this.updateProduct);
            this.Controls.Add(this.productDataGrid);
            this.Name = "frmProducts";
            this.Size = new System.Drawing.Size(776, 411);
            ((System.ComponentModel.ISupportInitialize)(this.productDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createProduct;
        private System.Windows.Forms.Button deleteProduct;
        private System.Windows.Forms.Button updateProduct;
        private System.Windows.Forms.DataGridView productDataGrid;
        private System.Windows.Forms.TextBox tbUnitPrice;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbUnitInStock;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbUnitInStock;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
