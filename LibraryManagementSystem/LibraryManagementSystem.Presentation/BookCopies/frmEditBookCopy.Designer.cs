namespace LibraryManagementSystem.Presentation
{
    partial class frmEditBookCopy
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
            this.txtCopyID = new System.Windows.Forms.TextBox();
            this.lblCopyID = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrlBookDetails1 = new LibraryManagementSystem.Presentation.ctrlBookDetails();
            this.SuspendLayout();
            // 
            // txtCopyID
            // 
            this.txtCopyID.Location = new System.Drawing.Point(243, 106);
            this.txtCopyID.Name = "txtCopyID";
            this.txtCopyID.ReadOnly = true;
            this.txtCopyID.Size = new System.Drawing.Size(197, 22);
            this.txtCopyID.TabIndex = 4;
            // 
            // lblCopyID
            // 
            this.lblCopyID.AutoSize = true;
            this.lblCopyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCopyID.Location = new System.Drawing.Point(37, 102);
            this.lblCopyID.Name = "lblCopyID";
            this.lblCopyID.Size = new System.Drawing.Size(84, 25);
            this.lblCopyID.TabIndex = 3;
            this.lblCopyID.Text = "CopyID:";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbStatus.Location = new System.Drawing.Point(42, 406);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(182, 29);
            this.cbStatus.TabIndex = 5;
            this.cbStatus.Text = "AvailabilityStatus";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(334, 469);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 43);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClose.Location = new System.Drawing.Point(42, 469);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 43);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(179, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(159, 36);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Edit Status";
            // 
            // ctrlBookDetails1
            // 
            this.ctrlBookDetails1.Location = new System.Drawing.Point(12, 122);
            this.ctrlBookDetails1.Name = "ctrlBookDetails1";
            this.ctrlBookDetails1.Size = new System.Drawing.Size(470, 302);
            this.ctrlBookDetails1.TabIndex = 0;
            // 
            // frmEditBookCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 552);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.txtCopyID);
            this.Controls.Add(this.lblCopyID);
            this.Controls.Add(this.ctrlBookDetails1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditBookCopy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditCopyStatus";
            this.Load += new System.EventHandler(this.frmEditBookCopy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlBookDetails ctrlBookDetails1;
        private System.Windows.Forms.TextBox txtCopyID;
        private System.Windows.Forms.Label lblCopyID;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
    }
}