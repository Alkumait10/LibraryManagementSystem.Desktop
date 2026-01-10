namespace LibraryManagementSystem.Presentation
{
    partial class frmCopyDetails
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
            this.lblCopyID = new System.Windows.Forms.Label();
            this.txtCopyID = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.ctrlBookDetails1 = new LibraryManagementSystem.Presentation.ctrlBookDetails();
            this.SuspendLayout();
            // 
            // lblCopyID
            // 
            this.lblCopyID.AutoSize = true;
            this.lblCopyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCopyID.Location = new System.Drawing.Point(40, 59);
            this.lblCopyID.Name = "lblCopyID";
            this.lblCopyID.Size = new System.Drawing.Size(84, 25);
            this.lblCopyID.TabIndex = 1;
            this.lblCopyID.Text = "CopyID:";
            // 
            // txtCopyID
            // 
            this.txtCopyID.Location = new System.Drawing.Point(244, 59);
            this.txtCopyID.Name = "txtCopyID";
            this.txtCopyID.ReadOnly = true;
            this.txtCopyID.Size = new System.Drawing.Size(197, 22);
            this.txtCopyID.TabIndex = 2;
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbStatus.Location = new System.Drawing.Point(45, 375);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(182, 29);
            this.cbStatus.TabIndex = 0;
            this.cbStatus.Text = "AvailabilityStatus";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // ctrlBookDetails1
            // 
            this.ctrlBookDetails1.Location = new System.Drawing.Point(12, 78);
            this.ctrlBookDetails1.Name = "ctrlBookDetails1";
            this.ctrlBookDetails1.Size = new System.Drawing.Size(470, 302);
            this.ctrlBookDetails1.TabIndex = 0;
            // 
            // frmCopyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 523);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.txtCopyID);
            this.Controls.Add(this.lblCopyID);
            this.Controls.Add(this.ctrlBookDetails1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopyDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copy Details";
            this.Load += new System.EventHandler(this.frmCopyDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlBookDetails ctrlBookDetails1;
        private System.Windows.Forms.Label lblCopyID;
        private System.Windows.Forms.TextBox txtCopyID;
        private System.Windows.Forms.CheckBox cbStatus;
    }
}