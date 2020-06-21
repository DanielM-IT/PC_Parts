using System.Windows.Forms;

namespace PC_Parts
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnManageOrders = new System.Windows.Forms.Button();
            this.btnViewCategory = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvCategoryList = new System.Windows.Forms.ListView();
            this.categoriesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightGray;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(337, 320);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(38, 23);
            this.btnExit.TabIndex = 78;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnManageOrders
            // 
            this.btnManageOrders.BackColor = System.Drawing.Color.LightGray;
            this.btnManageOrders.Location = new System.Drawing.Point(240, 155);
            this.btnManageOrders.Name = "btnManageOrders";
            this.btnManageOrders.Size = new System.Drawing.Size(109, 32);
            this.btnManageOrders.TabIndex = 77;
            this.btnManageOrders.Text = "Manage Orders";
            this.btnManageOrders.UseVisualStyleBackColor = false;
            this.btnManageOrders.Click += new System.EventHandler(this.btnManageOrders_Click);
            // 
            // btnViewCategory
            // 
            this.btnViewCategory.BackColor = System.Drawing.Color.LightGray;
            this.btnViewCategory.Location = new System.Drawing.Point(240, 193);
            this.btnViewCategory.Name = "btnViewCategory";
            this.btnViewCategory.Size = new System.Drawing.Size(109, 34);
            this.btnViewCategory.TabIndex = 76;
            this.btnViewCategory.Text = "View Category";
            this.btnViewCategory.UseVisualStyleBackColor = false;
            this.btnViewCategory.Click += new System.EventHandler(this.btnViewCategory_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(46, 35);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(303, 26);
            this.lblTitle.TabIndex = 73;
            this.lblTitle.Text = "Product Administration App";
            // 
            // lvCategoryList
            // 
            this.lvCategoryList.AllowColumnReorder = true;
            this.lvCategoryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.categoriesColumn});
            this.lvCategoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCategoryList.FullRowSelect = true;
            this.lvCategoryList.GridLines = true;
            this.lvCategoryList.HideSelection = false;
            this.lvCategoryList.Location = new System.Drawing.Point(51, 74);
            this.lvCategoryList.Name = "lvCategoryList";
            this.lvCategoryList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvCategoryList.Size = new System.Drawing.Size(164, 250);
            this.lvCategoryList.TabIndex = 80;
            this.lvCategoryList.UseCompatibleStateImageBehavior = false;
            this.lvCategoryList.View = System.Windows.Forms.View.Details;
            this.lvCategoryList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCategoryList_ColumnClick);
            this.lvCategoryList.DoubleClick += new System.EventHandler(this.lvCategoryList_DoubleClick);
            // 
            // categoriesColumn
            // 
            this.categoriesColumn.Text = "- Product Categories -";
            this.categoriesColumn.Width = 160;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnViewCategory;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(238)))));
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(387, 355);
            this.ControlBox = false;
            this.Controls.Add(this.lvCategoryList);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnManageOrders);
            this.Controls.Add(this.btnViewCategory);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnManageOrders;
        private System.Windows.Forms.Button btnViewCategory;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListView lvCategoryList;
        private System.Windows.Forms.ColumnHeader categoriesColumn;
    }
}