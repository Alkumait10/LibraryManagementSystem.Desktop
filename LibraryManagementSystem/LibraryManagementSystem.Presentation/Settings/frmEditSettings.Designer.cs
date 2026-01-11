namespace LibraryManagementSystem.Presentation
{
    partial class frmEditSettings
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
            this.txtDefaultBorrowDays = new System.Windows.Forms.TextBox();
            this.lblDefaultBorrowDays = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtDefaultFinePerDay = new System.Windows.Forms.TextBox();
            this.lblDefaultFinePerDay = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDefaultBorrowDays
            // 
            this.txtDefaultBorrowDays.Location = new System.Drawing.Point(265, 134);
            this.txtDefaultBorrowDays.Name = "txtDefaultBorrowDays";
            this.txtDefaultBorrowDays.Size = new System.Drawing.Size(197, 22);
            this.txtDefaultBorrowDays.TabIndex = 6;
            // 
            // lblDefaultBorrowDays
            // 
            this.lblDefaultBorrowDays.AutoSize = true;
            this.lblDefaultBorrowDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDefaultBorrowDays.Location = new System.Drawing.Point(69, 134);
            this.lblDefaultBorrowDays.Name = "lblDefaultBorrowDays";
            this.lblDefaultBorrowDays.Size = new System.Drawing.Size(185, 25);
            this.lblDefaultBorrowDays.TabIndex = 5;
            this.lblDefaultBorrowDays.Text = "DefaultBorrowDays:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(149, 43);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 36);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Edit Settings";
            // 
            // txtDefaultFinePerDay
            // 
            this.txtDefaultFinePerDay.Location = new System.Drawing.Point(265, 180);
            this.txtDefaultFinePerDay.Name = "txtDefaultFinePerDay";
            this.txtDefaultFinePerDay.Size = new System.Drawing.Size(197, 22);
            this.txtDefaultFinePerDay.TabIndex = 11;
            // 
            // lblDefaultFinePerDay
            // 
            this.lblDefaultFinePerDay.AutoSize = true;
            this.lblDefaultFinePerDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDefaultFinePerDay.Location = new System.Drawing.Point(69, 180);
            this.lblDefaultFinePerDay.Name = "lblDefaultFinePerDay";
            this.lblDefaultFinePerDay.Size = new System.Drawing.Size(182, 25);
            this.lblDefaultFinePerDay.TabIndex = 10;
            this.lblDefaultFinePerDay.Text = "DefaultFinePerDay:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClose.Location = new System.Drawing.Point(74, 229);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 43);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSave.Location = new System.Drawing.Point(356, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 43);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEditSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 338);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDefaultFinePerDay);
            this.Controls.Add(this.lblDefaultFinePerDay);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtDefaultBorrowDays);
            this.Controls.Add(this.lblDefaultBorrowDays);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Settings";
            this.Load += new System.EventHandler(this.frmEditSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDefaultBorrowDays;
        private System.Windows.Forms.Label lblDefaultBorrowDays;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtDefaultFinePerDay;
        private System.Windows.Forms.Label lblDefaultFinePerDay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}