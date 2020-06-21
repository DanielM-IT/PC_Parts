using System.Windows.Forms;

namespace PC_Parts
{
    partial class frmCategory
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
            this.lblCategoryDescription = new System.Windows.Forms.Label();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lvCategoryProducts = new System.Windows.Forms.ListView();
            this.IdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.productColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateModifiedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboProductTypeSelection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblCategoryDescription
            // 
            this.lblCategoryDescription.AutoSize = true;
            this.lblCategoryDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryDescription.Location = new System.Drawing.Point(32, 63);
            this.lblCategoryDescription.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCategoryDescription.Name = "lblCategoryDescription";
            this.lblCategoryDescription.Size = new System.Drawing.Size(333, 30);
            this.lblCategoryDescription.TabIndex = 59;
            this.lblCategoryDescription.Text = "These are brand new components sourced directly from the \r\nmanufacturers.";
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryName.Location = new System.Drawing.Point(30, 28);
            this.lblCategoryName.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(160, 26);
            this.lblCategoryName.TabIndex = 58;
            this.lblCategoryName.Text = "New Prodcuts";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.LightGray;
            this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReturn.Location = new System.Drawing.Point(749, 498);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(50, 23);
            this.btnReturn.TabIndex = 57;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.Color.LightGray;
            this.btnDeleteItem.Location = new System.Drawing.Point(702, 464);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(97, 23);
            this.btnDeleteItem.TabIndex = 56;
            this.btnDeleteItem.Text = "Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.BackColor = System.Drawing.Color.LightGray;
            this.btnEditItem.Location = new System.Drawing.Point(599, 464);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(97, 23);
            this.btnEditItem.TabIndex = 55;
            this.btnEditItem.Text = "View/Edit Item";
            this.btnEditItem.UseVisualStyleBackColor = false;
            this.btnEditItem.Click += new System.EventHandler(this.btnEditItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.LightGray;
            this.btnAddItem.Location = new System.Drawing.Point(35, 464);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(97, 23);
            this.btnAddItem.TabIndex = 54;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lvCategoryProducts
            // 
            this.lvCategoryProducts.AllowColumnReorder = true;
            this.lvCategoryProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdColumnHeader,
            this.productColumnHeader,
            this.priceColumnHeader,
            this.quantityColumnHeader,
            this.dateModifiedColumnHeader});
            this.lvCategoryProducts.FullRowSelect = true;
            this.lvCategoryProducts.GridLines = true;
            this.lvCategoryProducts.HideSelection = false;
            this.lvCategoryProducts.Location = new System.Drawing.Point(35, 107);
            this.lvCategoryProducts.Name = "lvCategoryProducts";
            this.lvCategoryProducts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvCategoryProducts.Size = new System.Drawing.Size(764, 349);
            this.lvCategoryProducts.TabIndex = 53;
            this.lvCategoryProducts.UseCompatibleStateImageBehavior = false;
            this.lvCategoryProducts.View = System.Windows.Forms.View.Details;
            this.lvCategoryProducts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCategoryProducts_ColumnClick);
            this.lvCategoryProducts.DoubleClick += new System.EventHandler(this.lvCategoryProducts_DoubleClick);
            // 
            // IdColumnHeader
            // 
            this.IdColumnHeader.Text = "Product ID";
            this.IdColumnHeader.Width = 80;
            // 
            // productColumnHeader
            // 
            this.productColumnHeader.Text = "Product Name";
            this.productColumnHeader.Width = 340;
            // 
            // priceColumnHeader
            // 
            this.priceColumnHeader.Text = "Price";
            this.priceColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.priceColumnHeader.Width = 90;
            // 
            // quantityColumnHeader
            // 
            this.quantityColumnHeader.Text = "Quantity";
            this.quantityColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.quantityColumnHeader.Width = 90;
            // 
            // dateModifiedColumnHeader
            // 
            this.dateModifiedColumnHeader.Text = "Date Modified";
            this.dateModifiedColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dateModifiedColumnHeader.Width = 160;
            // 
            // cboProductTypeSelection
            // 
            this.cboProductTypeSelection.BackColor = System.Drawing.Color.White;
            this.cboProductTypeSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductTypeSelection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboProductTypeSelection.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboProductTypeSelection.FormattingEnabled = true;
            this.cboProductTypeSelection.Items.AddRange(new object[] {
            "New",
            "Used"});
            this.cboProductTypeSelection.Location = new System.Drawing.Point(137, 466);
            this.cboProductTypeSelection.Margin = new System.Windows.Forms.Padding(2);
            this.cboProductTypeSelection.Name = "cboProductTypeSelection";
            this.cboProductTypeSelection.Size = new System.Drawing.Size(97, 21);
            this.cboProductTypeSelection.TabIndex = 60;
            // 
            // frmCategory
            // 
            this.AcceptButton = this.btnAddItem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(238)))));
            this.CancelButton = this.btnReturn;
            this.ClientSize = new System.Drawing.Size(837, 541);
            this.ControlBox = false;
            this.Controls.Add(this.cboProductTypeSelection);
            this.Controls.Add(this.lblCategoryDescription);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnEditItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.lvCategoryProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCategoryDescription;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ListView lvCategoryProducts;
        private System.Windows.Forms.ColumnHeader productColumnHeader;
        private System.Windows.Forms.ColumnHeader priceColumnHeader;
        private System.Windows.Forms.ColumnHeader quantityColumnHeader;
        private System.Windows.Forms.ColumnHeader dateModifiedColumnHeader;
        private System.Windows.Forms.ColumnHeader IdColumnHeader;
        private System.Windows.Forms.ComboBox cboProductTypeSelection;
    }
}