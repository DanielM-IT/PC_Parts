namespace PC_Parts
{
    partial class frmProduct
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
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQantity = new System.Windows.Forms.Label();
            this.txtDateModified = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblProductId = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.lblInputDirections = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDateModified = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblProductType = new System.Windows.Forms.Label();
            this.txtProductType = new System.Windows.Forms.TextBox();
            this.lblImageUrl = new System.Windows.Forms.Label();
            this.txtImageUrl = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // numQuantity
            // 
            this.numQuantity.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numQuantity.Location = new System.Drawing.Point(183, 174);
            this.numQuantity.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(153, 20);
            this.numQuantity.TabIndex = 138;
            this.numQuantity.TabStop = false;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQantity
            // 
            this.lblQantity.AutoSize = true;
            this.lblQantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQantity.Location = new System.Drawing.Point(39, 173);
            this.lblQantity.Name = "lblQantity";
            this.lblQantity.Size = new System.Drawing.Size(65, 17);
            this.lblQantity.TabIndex = 145;
            this.lblQantity.Text = "Quantity:";
            // 
            // txtDateModified
            // 
            this.txtDateModified.Enabled = false;
            this.txtDateModified.Location = new System.Drawing.Point(183, 247);
            this.txtDateModified.Name = "txtDateModified";
            this.txtDateModified.Size = new System.Drawing.Size(153, 20);
            this.txtDateModified.TabIndex = 135;
            this.txtDateModified.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(99, 29);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 26);
            this.lblTitle.TabIndex = 135;
            this.lblTitle.Text = "Product Details";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(183, 388);
            this.txtDescription.MaxLength = 250;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(153, 91);
            this.txtDescription.TabIndex = 144;
            this.txtDescription.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(39, 388);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 17);
            this.lblDescription.TabIndex = 141;
            this.lblDescription.Text = "Description:";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(183, 137);
            this.numPrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(153, 20);
            this.numPrice.TabIndex = 137;
            this.numPrice.TabStop = false;
            this.numPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductId.Location = new System.Drawing.Point(39, 319);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(78, 17);
            this.lblProductId.TabIndex = 139;
            this.lblProductId.Text = "Product ID:";
            // 
            // txtProductId
            // 
            this.txtProductId.BackColor = System.Drawing.Color.White;
            this.txtProductId.Enabled = false;
            this.txtProductId.Location = new System.Drawing.Point(183, 318);
            this.txtProductId.MaxLength = 255;
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(153, 20);
            this.txtProductId.TabIndex = 143;
            this.txtProductId.TabStop = false;
            // 
            // lblInputDirections
            // 
            this.lblInputDirections.AutoSize = true;
            this.lblInputDirections.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputDirections.Location = new System.Drawing.Point(49, 65);
            this.lblInputDirections.Name = "lblInputDirections";
            this.lblInputDirections.Size = new System.Drawing.Size(287, 15);
            this.lblInputDirections.TabIndex = 137;
            this.lblInputDirections.Text = "Please enter product details into the provided fields.";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(183, 100);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 20);
            this.txtName.TabIndex = 136;
            this.txtName.TabStop = false;
            // 
            // lblDateModified
            // 
            this.lblDateModified.AutoSize = true;
            this.lblDateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateModified.Location = new System.Drawing.Point(39, 247);
            this.lblDateModified.Name = "lblDateModified";
            this.lblDateModified.Size = new System.Drawing.Size(130, 17);
            this.lblDateModified.TabIndex = 135;
            this.lblDateModified.Text = "Date Last Modified:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(39, 136);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(44, 17);
            this.lblPrice.TabIndex = 134;
            this.lblPrice.Text = "Price:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(39, 100);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 133;
            this.lblName.Text = "Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.Location = new System.Drawing.Point(192, 494);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 24);
            this.btnCancel.TabIndex = 145;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightGray;
            this.btnOk.Location = new System.Drawing.Point(122, 494);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 24);
            this.btnOk.TabIndex = 145;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductType.Location = new System.Drawing.Point(39, 282);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(97, 17);
            this.lblProductType.TabIndex = 147;
            this.lblProductType.Text = "Product Type:";
            // 
            // txtProductType
            // 
            this.txtProductType.Enabled = false;
            this.txtProductType.Location = new System.Drawing.Point(183, 282);
            this.txtProductType.Name = "txtProductType";
            this.txtProductType.Size = new System.Drawing.Size(153, 20);
            this.txtProductType.TabIndex = 142;
            this.txtProductType.TabStop = false;
            // 
            // lblImageUrl
            // 
            this.lblImageUrl.AutoSize = true;
            this.lblImageUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageUrl.Location = new System.Drawing.Point(39, 353);
            this.lblImageUrl.Name = "lblImageUrl";
            this.lblImageUrl.Size = new System.Drawing.Size(72, 17);
            this.lblImageUrl.TabIndex = 148;
            this.lblImageUrl.Text = "Image Url:";
            // 
            // txtImageUrl
            // 
            this.txtImageUrl.BackColor = System.Drawing.Color.White;
            this.txtImageUrl.Location = new System.Drawing.Point(183, 352);
            this.txtImageUrl.MaxLength = 255;
            this.txtImageUrl.Name = "txtImageUrl";
            this.txtImageUrl.Size = new System.Drawing.Size(153, 20);
            this.txtImageUrl.TabIndex = 149;
            this.txtImageUrl.TabStop = false;
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(228)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(368, 552);
            this.ControlBox = false;
            this.Controls.Add(this.txtImageUrl);
            this.Controls.Add(this.lblImageUrl);
            this.Controls.Add(this.txtProductType);
            this.Controls.Add(this.lblProductType);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQantity);
            this.Controls.Add(this.txtDateModified);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblProductId);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.lblInputDirections);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDateModified);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numQuantity;
        protected System.Windows.Forms.Label lblQantity;
        protected System.Windows.Forms.TextBox txtDateModified;
        private System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblProductId;
        protected System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label lblInputDirections;
        protected System.Windows.Forms.TextBox txtName;
        protected System.Windows.Forms.Label lblDateModified;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblName;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnOk;
        protected System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.TextBox txtProductType;
        private System.Windows.Forms.Label lblImageUrl;
        protected System.Windows.Forms.TextBox txtImageUrl;
    }
}