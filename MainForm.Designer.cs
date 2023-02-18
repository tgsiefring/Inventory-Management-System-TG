namespace InventoryManagementSystem
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
            this.parts = new System.Windows.Forms.DataGridView();
            this.products = new System.Windows.Forms.DataGridView();
            this.deletePartButton = new System.Windows.Forms.Button();
            this.addPartButton = new System.Windows.Forms.Button();
            this.modifyPartButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.modifyProductButton = new System.Windows.Forms.Button();
            this.deleteProductButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.searchPartButton = new System.Windows.Forms.Button();
            this.searchProductButton = new System.Windows.Forms.Button();
            this.searchText1 = new System.Windows.Forms.TextBox();
            this.searchText2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.parts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.products)).BeginInit();
            this.SuspendLayout();
            // 
            // parts
            // 
            this.parts.AllowUserToDeleteRows = false;
            this.parts.AllowUserToResizeColumns = false;
            this.parts.AllowUserToResizeRows = false;
            this.parts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.parts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parts.Location = new System.Drawing.Point(0, 94);
            this.parts.MultiSelect = false;
            this.parts.Name = "parts";
            this.parts.ReadOnly = true;
            this.parts.RowHeadersVisible = false;
            this.parts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.parts.Size = new System.Drawing.Size(480, 323);
            this.parts.TabIndex = 0;
            this.parts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Parts_CellClick);
            this.parts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.AllPartsBindingComplete);
            // 
            // products
            // 
            this.products.AllowUserToAddRows = false;
            this.products.AllowUserToDeleteRows = false;
            this.products.AllowUserToResizeColumns = false;
            this.products.AllowUserToResizeRows = false;
            this.products.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.products.Location = new System.Drawing.Point(544, 94);
            this.products.MultiSelect = false;
            this.products.Name = "products";
            this.products.ReadOnly = true;
            this.products.RowHeadersVisible = false;
            this.products.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.products.Size = new System.Drawing.Size(480, 323);
            this.products.TabIndex = 1;
            this.products.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Products_CellClick);
            this.products.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ProductsBindingComplete);
            // 
            // deletePartButton
            // 
            this.deletePartButton.Location = new System.Drawing.Point(405, 432);
            this.deletePartButton.Name = "deletePartButton";
            this.deletePartButton.Size = new System.Drawing.Size(75, 23);
            this.deletePartButton.TabIndex = 2;
            this.deletePartButton.Text = "Delete";
            this.deletePartButton.UseVisualStyleBackColor = true;
            this.deletePartButton.Click += new System.EventHandler(this.DeletePartButton_Click);
            // 
            // addPartButton
            // 
            this.addPartButton.Location = new System.Drawing.Point(243, 432);
            this.addPartButton.Name = "addPartButton";
            this.addPartButton.Size = new System.Drawing.Size(75, 23);
            this.addPartButton.TabIndex = 3;
            this.addPartButton.Text = "Add";
            this.addPartButton.UseVisualStyleBackColor = true;
            this.addPartButton.Click += new System.EventHandler(this.AddPartButton_Click);
            // 
            // modifyPartButton
            // 
            this.modifyPartButton.Location = new System.Drawing.Point(324, 432);
            this.modifyPartButton.Name = "modifyPartButton";
            this.modifyPartButton.Size = new System.Drawing.Size(75, 23);
            this.modifyPartButton.TabIndex = 4;
            this.modifyPartButton.Text = "Modify";
            this.modifyPartButton.UseVisualStyleBackColor = true;
            this.modifyPartButton.Click += new System.EventHandler(this.ModifyPartButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(787, 432);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(75, 23);
            this.addProductButton.TabIndex = 5;
            this.addProductButton.Text = "Add";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // modifyProductButton
            // 
            this.modifyProductButton.Location = new System.Drawing.Point(868, 432);
            this.modifyProductButton.Name = "modifyProductButton";
            this.modifyProductButton.Size = new System.Drawing.Size(75, 23);
            this.modifyProductButton.TabIndex = 6;
            this.modifyProductButton.Text = "Modify";
            this.modifyProductButton.UseVisualStyleBackColor = true;
            this.modifyProductButton.Click += new System.EventHandler(this.ModifyProductButton_Click);
            // 
            // deleteProductButton
            // 
            this.deleteProductButton.Location = new System.Drawing.Point(949, 432);
            this.deleteProductButton.Name = "deleteProductButton";
            this.deleteProductButton.Size = new System.Drawing.Size(75, 23);
            this.deleteProductButton.TabIndex = 7;
            this.deleteProductButton.Text = "Delete";
            this.deleteProductButton.UseVisualStyleBackColor = true;
            this.deleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(949, 541);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Inventory Management System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-4, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Parts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(540, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Products";
            // 
            // searchPartButton
            // 
            this.searchPartButton.Location = new System.Drawing.Point(162, 65);
            this.searchPartButton.Name = "searchPartButton";
            this.searchPartButton.Size = new System.Drawing.Size(75, 23);
            this.searchPartButton.TabIndex = 12;
            this.searchPartButton.Text = "Search";
            this.searchPartButton.UseVisualStyleBackColor = true;
            this.searchPartButton.Click += new System.EventHandler(this.SearchPartButton_Click);
            // 
            // searchProductButton
            // 
            this.searchProductButton.Location = new System.Drawing.Point(706, 65);
            this.searchProductButton.Name = "searchProductButton";
            this.searchProductButton.Size = new System.Drawing.Size(75, 23);
            this.searchProductButton.TabIndex = 13;
            this.searchProductButton.Text = "Search";
            this.searchProductButton.UseVisualStyleBackColor = true;
            this.searchProductButton.Click += new System.EventHandler(this.SearchProductButton_Click);
            // 
            // searchText1
            // 
            this.searchText1.Location = new System.Drawing.Point(243, 68);
            this.searchText1.Name = "searchText1";
            this.searchText1.Size = new System.Drawing.Size(237, 20);
            this.searchText1.TabIndex = 14;
            // 
            // searchText2
            // 
            this.searchText2.Location = new System.Drawing.Point(787, 68);
            this.searchText2.Name = "searchText2";
            this.searchText2.Size = new System.Drawing.Size(237, 20);
            this.searchText2.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 581);
            this.Controls.Add(this.searchText2);
            this.Controls.Add(this.searchText1);
            this.Controls.Add(this.searchProductButton);
            this.Controls.Add(this.searchPartButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.deleteProductButton);
            this.Controls.Add(this.modifyProductButton);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.modifyPartButton);
            this.Controls.Add(this.addPartButton);
            this.Controls.Add(this.deletePartButton);
            this.Controls.Add(this.products);
            this.Controls.Add(this.parts);
            this.Name = "MainForm";
            this.Text = "Main Screen";
            ((System.ComponentModel.ISupportInitialize)(this.parts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.products)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button deletePartButton;
        private System.Windows.Forms.Button addPartButton;
        private System.Windows.Forms.Button modifyPartButton;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Button modifyProductButton;
        private System.Windows.Forms.Button deleteProductButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchPartButton;
        private System.Windows.Forms.Button searchProductButton;
        private System.Windows.Forms.TextBox searchText1;
        private System.Windows.Forms.TextBox searchText2;
        public System.Windows.Forms.DataGridView parts;
        public System.Windows.Forms.DataGridView products;
    }
}

