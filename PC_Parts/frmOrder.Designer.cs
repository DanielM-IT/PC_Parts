using System.Windows.Forms;

namespace PC_Parts
{
    partial class frmOrder
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotalOrderValueTitle = new System.Windows.Forms.Label();
            this.lblTotalOrderValue = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lvOrderList = new System.Windows.Forms.ListView();
            this.orderIdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblOrderDetails = new System.Windows.Forms.Label();
            this.lblOrderIDTitle = new System.Windows.Forms.Label();
            this.lblPriceAtTimeOfOrderTitle = new System.Windows.Forms.Label();
            this.lblProductDescriptionTitle = new System.Windows.Forms.Label();
            this.lblProductNameTitle = new System.Windows.Forms.Label();
            this.lblCustomerEmailTitle = new System.Windows.Forms.Label();
            this.lblCustomerNameTitle = new System.Windows.Forms.Label();
            this.lblQuantityTitle = new System.Windows.Forms.Label();
            this.lblDateTitle = new System.Windows.Forms.Label();
            this.lblSelectedOrderValueTitle = new System.Windows.Forms.Label();
            this.lblSelectedOrderValue = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerEmail = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductDescription = new System.Windows.Forms.Label();
            this.lblPriceAtTimeOfOrder = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightGray;
            this.btnDelete.Location = new System.Drawing.Point(30, 592);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 23);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "Delete Order";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(212, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(177, 25);
            this.lblTitle.TabIndex = 31;
            this.lblTitle.Text = "Customer Orders";
            // 
            // lblTotalOrderValueTitle
            // 
            this.lblTotalOrderValueTitle.AutoSize = true;
            this.lblTotalOrderValueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrderValueTitle.Location = new System.Drawing.Point(183, 597);
            this.lblTotalOrderValueTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTotalOrderValueTitle.Name = "lblTotalOrderValueTitle";
            this.lblTotalOrderValueTitle.Size = new System.Drawing.Size(144, 13);
            this.lblTotalOrderValueTitle.TabIndex = 30;
            this.lblTotalOrderValueTitle.Text = "Value of Current Orders:";
            // 
            // lblTotalOrderValue
            // 
            this.lblTotalOrderValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalOrderValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrderValue.Location = new System.Drawing.Point(330, 589);
            this.lblTotalOrderValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalOrderValue.Name = "lblTotalOrderValue";
            this.lblTotalOrderValue.Size = new System.Drawing.Size(109, 28);
            this.lblTotalOrderValue.TabIndex = 29;
            this.lblTotalOrderValue.Text = "$319.00";
            this.lblTotalOrderValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.LightGray;
            this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReturn.Location = new System.Drawing.Point(515, 592);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(97, 23);
            this.btnReturn.TabIndex = 26;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lvOrderList
            // 
            this.lvOrderList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvOrderList.AllowColumnReorder = true;
            this.lvOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.orderIdColumn});
            this.lvOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvOrderList.FullRowSelect = true;
            this.lvOrderList.GridLines = true;
            this.lvOrderList.HideSelection = false;
            this.lvOrderList.Location = new System.Drawing.Point(30, 60);
            this.lvOrderList.Name = "lvOrderList";
            this.lvOrderList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvOrderList.Size = new System.Drawing.Size(154, 516);
            this.lvOrderList.TabIndex = 54;
            this.lvOrderList.UseCompatibleStateImageBehavior = false;
            this.lvOrderList.View = System.Windows.Forms.View.Details;
            this.lvOrderList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOrderList_ColumnClick);
            this.lvOrderList.ItemActivate += new System.EventHandler(this.lvOrderList_Click);
            // 
            // orderIdColumn
            // 
            this.orderIdColumn.Text = "Order ID";
            this.orderIdColumn.Width = 150;
            // 
            // lblOrderDetails
            // 
            this.lblOrderDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDetails.Location = new System.Drawing.Point(208, 60);
            this.lblOrderDetails.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblOrderDetails.Name = "lblOrderDetails";
            this.lblOrderDetails.Padding = new System.Windows.Forms.Padding(10);
            this.lblOrderDetails.Size = new System.Drawing.Size(404, 516);
            this.lblOrderDetails.TabIndex = 56;
            // 
            // lblOrderIDTitle
            // 
            this.lblOrderIDTitle.AutoSize = true;
            this.lblOrderIDTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblOrderIDTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderIDTitle.Location = new System.Drawing.Point(228, 83);
            this.lblOrderIDTitle.Name = "lblOrderIDTitle";
            this.lblOrderIDTitle.Size = new System.Drawing.Size(70, 16);
            this.lblOrderIDTitle.TabIndex = 57;
            this.lblOrderIDTitle.Text = "Order ID:";
            // 
            // lblPriceAtTimeOfOrderTitle
            // 
            this.lblPriceAtTimeOfOrderTitle.AutoSize = true;
            this.lblPriceAtTimeOfOrderTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblPriceAtTimeOfOrderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceAtTimeOfOrderTitle.Location = new System.Drawing.Point(228, 509);
            this.lblPriceAtTimeOfOrderTitle.Name = "lblPriceAtTimeOfOrderTitle";
            this.lblPriceAtTimeOfOrderTitle.Size = new System.Drawing.Size(105, 16);
            this.lblPriceAtTimeOfOrderTitle.TabIndex = 58;
            this.lblPriceAtTimeOfOrderTitle.Text = "Product Price:";
            // 
            // lblProductDescriptionTitle
            // 
            this.lblProductDescriptionTitle.AutoSize = true;
            this.lblProductDescriptionTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblProductDescriptionTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductDescriptionTitle.Location = new System.Drawing.Point(228, 366);
            this.lblProductDescriptionTitle.Name = "lblProductDescriptionTitle";
            this.lblProductDescriptionTitle.Size = new System.Drawing.Size(148, 16);
            this.lblProductDescriptionTitle.TabIndex = 59;
            this.lblProductDescriptionTitle.Text = "Product Description:";
            // 
            // lblProductNameTitle
            // 
            this.lblProductNameTitle.AutoSize = true;
            this.lblProductNameTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblProductNameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductNameTitle.Location = new System.Drawing.Point(228, 261);
            this.lblProductNameTitle.Name = "lblProductNameTitle";
            this.lblProductNameTitle.Size = new System.Drawing.Size(110, 16);
            this.lblProductNameTitle.TabIndex = 60;
            this.lblProductNameTitle.Text = "Product Name:";
            // 
            // lblCustomerEmailTitle
            // 
            this.lblCustomerEmailTitle.AutoSize = true;
            this.lblCustomerEmailTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblCustomerEmailTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerEmailTitle.Location = new System.Drawing.Point(228, 204);
            this.lblCustomerEmailTitle.Name = "lblCustomerEmailTitle";
            this.lblCustomerEmailTitle.Size = new System.Drawing.Size(120, 16);
            this.lblCustomerEmailTitle.TabIndex = 61;
            this.lblCustomerEmailTitle.Text = "Customer Email:";
            // 
            // lblCustomerNameTitle
            // 
            this.lblCustomerNameTitle.AutoSize = true;
            this.lblCustomerNameTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblCustomerNameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameTitle.Location = new System.Drawing.Point(228, 179);
            this.lblCustomerNameTitle.Name = "lblCustomerNameTitle";
            this.lblCustomerNameTitle.Size = new System.Drawing.Size(122, 16);
            this.lblCustomerNameTitle.TabIndex = 62;
            this.lblCustomerNameTitle.Text = "Customer Name:";
            // 
            // lblQuantityTitle
            // 
            this.lblQuantityTitle.AutoSize = true;
            this.lblQuantityTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblQuantityTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityTitle.Location = new System.Drawing.Point(228, 131);
            this.lblQuantityTitle.Name = "lblQuantityTitle";
            this.lblQuantityTitle.Size = new System.Drawing.Size(68, 16);
            this.lblQuantityTitle.TabIndex = 63;
            this.lblQuantityTitle.Text = "Quantity:";
            // 
            // lblDateTitle
            // 
            this.lblDateTitle.AutoSize = true;
            this.lblDateTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblDateTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTitle.Location = new System.Drawing.Point(228, 107);
            this.lblDateTitle.Name = "lblDateTitle";
            this.lblDateTitle.Size = new System.Drawing.Size(88, 16);
            this.lblDateTitle.TabIndex = 64;
            this.lblDateTitle.Text = "Order Date:";
            // 
            // lblSelectedOrderValueTitle
            // 
            this.lblSelectedOrderValueTitle.AutoSize = true;
            this.lblSelectedOrderValueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedOrderValueTitle.Location = new System.Drawing.Point(228, 539);
            this.lblSelectedOrderValueTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblSelectedOrderValueTitle.Name = "lblSelectedOrderValueTitle";
            this.lblSelectedOrderValueTitle.Size = new System.Drawing.Size(132, 13);
            this.lblSelectedOrderValueTitle.TabIndex = 65;
            this.lblSelectedOrderValueTitle.Text = "Selected Order Value:";
            // 
            // lblSelectedOrderValue
            // 
            this.lblSelectedOrderValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblSelectedOrderValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSelectedOrderValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedOrderValue.Location = new System.Drawing.Point(363, 533);
            this.lblSelectedOrderValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedOrderValue.Name = "lblSelectedOrderValue";
            this.lblSelectedOrderValue.Size = new System.Drawing.Size(109, 27);
            this.lblSelectedOrderValue.TabIndex = 66;
            this.lblSelectedOrderValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(356, 107);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(239, 16);
            this.lblDate.TabIndex = 74;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQuantity
            // 
            this.lblQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(356, 131);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(239, 16);
            this.lblQuantity.TabIndex = 73;
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(356, 179);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(239, 16);
            this.lblCustomerName.TabIndex = 72;
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblCustomerEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerEmail.Location = new System.Drawing.Point(356, 204);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(239, 16);
            this.lblCustomerEmail.TabIndex = 71;
            this.lblCustomerEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(228, 280);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(367, 80);
            this.lblProductName.TabIndex = 70;
            // 
            // lblProductDescription
            // 
            this.lblProductDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblProductDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductDescription.Location = new System.Drawing.Point(228, 386);
            this.lblProductDescription.Name = "lblProductDescription";
            this.lblProductDescription.Size = new System.Drawing.Size(367, 115);
            this.lblProductDescription.TabIndex = 69;
            // 
            // lblPriceAtTimeOfOrder
            // 
            this.lblPriceAtTimeOfOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblPriceAtTimeOfOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceAtTimeOfOrder.Location = new System.Drawing.Point(339, 509);
            this.lblPriceAtTimeOfOrder.Name = "lblPriceAtTimeOfOrder";
            this.lblPriceAtTimeOfOrder.Size = new System.Drawing.Size(256, 16);
            this.lblPriceAtTimeOfOrder.TabIndex = 68;
            this.lblPriceAtTimeOfOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderID
            // 
            this.lblOrderID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(225)))));
            this.lblOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.Location = new System.Drawing.Point(356, 83);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(239, 16);
            this.lblOrderID.TabIndex = 67;
            this.lblOrderID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(238)))));
            this.CancelButton = this.btnReturn;
            this.ClientSize = new System.Drawing.Size(643, 637);
            this.ControlBox = false;
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.lblCustomerEmail);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblProductDescription);
            this.Controls.Add(this.lblPriceAtTimeOfOrder);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.lblSelectedOrderValue);
            this.Controls.Add(this.lblSelectedOrderValueTitle);
            this.Controls.Add(this.lblDateTitle);
            this.Controls.Add(this.lblQuantityTitle);
            this.Controls.Add(this.lblCustomerNameTitle);
            this.Controls.Add(this.lblCustomerEmailTitle);
            this.Controls.Add(this.lblProductNameTitle);
            this.Controls.Add(this.lblProductDescriptionTitle);
            this.Controls.Add(this.lblPriceAtTimeOfOrderTitle);
            this.Controls.Add(this.lblOrderIDTitle);
            this.Controls.Add(this.lblOrderDetails);
            this.Controls.Add(this.lvOrderList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTotalOrderValueTitle);
            this.Controls.Add(this.lblTotalOrderValue);
            this.Controls.Add(this.btnReturn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalOrderValueTitle;
        private System.Windows.Forms.Label lblTotalOrderValue;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.ListView lvOrderList;
        private System.Windows.Forms.ColumnHeader orderIdColumn;
        private System.Windows.Forms.Label lblOrderDetails;
        private System.Windows.Forms.Label lblOrderIDTitle;
        private System.Windows.Forms.Label lblPriceAtTimeOfOrderTitle;
        private System.Windows.Forms.Label lblProductDescriptionTitle;
        private System.Windows.Forms.Label lblProductNameTitle;
        private System.Windows.Forms.Label lblCustomerEmailTitle;
        private System.Windows.Forms.Label lblCustomerNameTitle;
        private System.Windows.Forms.Label lblQuantityTitle;
        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label lblSelectedOrderValueTitle;
        private System.Windows.Forms.Label lblSelectedOrderValue;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerEmail;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductDescription;
        private System.Windows.Forms.Label lblPriceAtTimeOfOrder;
        private System.Windows.Forms.Label lblOrderID;
    }
}