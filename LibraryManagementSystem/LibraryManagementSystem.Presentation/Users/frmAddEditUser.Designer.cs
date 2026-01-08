namespace LibraryManagementSystem.Presentation
{
    partial class frmAddEditUser
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
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblContactInformation = new System.Windows.Forms.Label();
            this.lblLibraryCardNumber = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtContactInformation = new System.Windows.Forms.TextBox();
            this.txtLibraryCardNumber = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblUserID.Location = new System.Drawing.Point(154, 142);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(78, 25);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "UserID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblName.Location = new System.Drawing.Point(154, 183);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblContactInformation
            // 
            this.lblContactInformation.AutoSize = true;
            this.lblContactInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblContactInformation.Location = new System.Drawing.Point(154, 224);
            this.lblContactInformation.Name = "lblContactInformation";
            this.lblContactInformation.Size = new System.Drawing.Size(182, 25);
            this.lblContactInformation.TabIndex = 2;
            this.lblContactInformation.Text = "ContactInformation:";
            // 
            // lblLibraryCardNumber
            // 
            this.lblLibraryCardNumber.AutoSize = true;
            this.lblLibraryCardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLibraryCardNumber.Location = new System.Drawing.Point(154, 265);
            this.lblLibraryCardNumber.Name = "lblLibraryCardNumber";
            this.lblLibraryCardNumber.Size = new System.Drawing.Size(189, 25);
            this.lblLibraryCardNumber.TabIndex = 3;
            this.lblLibraryCardNumber.Text = "LibraryCardNumber:";
            // 
            // txtUserID
            // 
            this.txtUserID.Enabled = false;
            this.txtUserID.Location = new System.Drawing.Point(360, 146);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(196, 22);
            this.txtUserID.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(360, 187);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(196, 22);
            this.txtName.TabIndex = 0;
            // 
            // txtContactInformation
            // 
            this.txtContactInformation.Location = new System.Drawing.Point(360, 228);
            this.txtContactInformation.Name = "txtContactInformation";
            this.txtContactInformation.Size = new System.Drawing.Size(196, 22);
            this.txtContactInformation.TabIndex = 1;
            // 
            // txtLibraryCardNumber
            // 
            this.txtLibraryCardNumber.Location = new System.Drawing.Point(360, 269);
            this.txtLibraryCardNumber.Name = "txtLibraryCardNumber";
            this.txtLibraryCardNumber.Size = new System.Drawing.Size(196, 22);
            this.txtLibraryCardNumber.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblTitle.Location = new System.Drawing.Point(308, 53);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(124, 31);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Add New";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(466, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 47);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtLibraryCardNumber);
            this.Controls.Add(this.txtContactInformation);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lblLibraryCardNumber);
            this.Controls.Add(this.lblContactInformation);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblUserID);
            this.Name = "frmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddNewUser";
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblContactInformation;
        private System.Windows.Forms.Label lblLibraryCardNumber;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtContactInformation;
        private System.Windows.Forms.TextBox txtLibraryCardNumber;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
    }
}