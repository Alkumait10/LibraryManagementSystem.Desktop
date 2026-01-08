namespace LibraryManagementSystem.Presentation
{
    partial class frmUserDetails
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
            this.txtLibraryCardNumber = new System.Windows.Forms.TextBox();
            this.txtContactInformation = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblLibraryCardNumber = new System.Windows.Forms.Label();
            this.lblContactInformation = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLibraryCardNumber
            // 
            this.txtLibraryCardNumber.Location = new System.Drawing.Point(304, 217);
            this.txtLibraryCardNumber.Name = "txtLibraryCardNumber";
            this.txtLibraryCardNumber.ReadOnly = true;
            this.txtLibraryCardNumber.Size = new System.Drawing.Size(196, 22);
            this.txtLibraryCardNumber.TabIndex = 8;
            // 
            // txtContactInformation
            // 
            this.txtContactInformation.Location = new System.Drawing.Point(304, 176);
            this.txtContactInformation.Name = "txtContactInformation";
            this.txtContactInformation.ReadOnly = true;
            this.txtContactInformation.Size = new System.Drawing.Size(196, 22);
            this.txtContactInformation.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(304, 135);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(196, 22);
            this.txtName.TabIndex = 4;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(304, 94);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(196, 22);
            this.txtUserID.TabIndex = 10;
            // 
            // lblLibraryCardNumber
            // 
            this.lblLibraryCardNumber.AutoSize = true;
            this.lblLibraryCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLibraryCardNumber.Location = new System.Drawing.Point(98, 213);
            this.lblLibraryCardNumber.Name = "lblLibraryCardNumber";
            this.lblLibraryCardNumber.Size = new System.Drawing.Size(189, 25);
            this.lblLibraryCardNumber.TabIndex = 11;
            this.lblLibraryCardNumber.Text = "LibraryCardNumber:";
            // 
            // lblContactInformation
            // 
            this.lblContactInformation.AutoSize = true;
            this.lblContactInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblContactInformation.Location = new System.Drawing.Point(98, 172);
            this.lblContactInformation.Name = "lblContactInformation";
            this.lblContactInformation.Size = new System.Drawing.Size(182, 25);
            this.lblContactInformation.TabIndex = 9;
            this.lblContactInformation.Text = "ContactInformation:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblName.Location = new System.Drawing.Point(98, 131);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 25);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblUserID.Location = new System.Drawing.Point(98, 90);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(78, 25);
            this.lblUserID.TabIndex = 5;
            this.lblUserID.Text = "UserID:";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEdit.Location = new System.Drawing.Point(357, 267);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(143, 51);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClose.Location = new System.Drawing.Point(103, 267);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 51);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtLibraryCardNumber);
            this.Controls.Add(this.txtContactInformation);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lblLibraryCardNumber);
            this.Controls.Add(this.lblContactInformation);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblUserID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserDetails";
            this.Load += new System.EventHandler(this.frmUserDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLibraryCardNumber;
        private System.Windows.Forms.TextBox txtContactInformation;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblLibraryCardNumber;
        private System.Windows.Forms.Label lblContactInformation;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
    }
}