namespace LibraryManagementSystem.Presentation
{
    partial class frmAddEditBook
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.lblPublicationDate = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblBookTitle = new System.Windows.Forms.Label();
            this.lblBookID = new System.Windows.Forms.Label();
            this.dtpPublicationDate = new System.Windows.Forms.DateTimePicker();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblAdditionalDetails = new System.Windows.Forms.Label();
            this.txtAdditionalDetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(455, 458);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 47);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblTitle.Location = new System.Drawing.Point(297, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(124, 31);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "Add New";
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(349, 289);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(196, 22);
            this.txtGenre.TabIndex = 11;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(349, 203);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(196, 22);
            this.txtISBN.TabIndex = 9;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Location = new System.Drawing.Point(349, 162);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(196, 22);
            this.txtBookTitle.TabIndex = 7;
            // 
            // txtBookID
            // 
            this.txtBookID.Enabled = false;
            this.txtBookID.Location = new System.Drawing.Point(349, 121);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.ReadOnly = true;
            this.txtBookID.Size = new System.Drawing.Size(196, 22);
            this.txtBookID.TabIndex = 13;
            // 
            // lblPublicationDate
            // 
            this.lblPublicationDate.AutoSize = true;
            this.lblPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPublicationDate.Location = new System.Drawing.Point(143, 240);
            this.lblPublicationDate.Name = "lblPublicationDate";
            this.lblPublicationDate.Size = new System.Drawing.Size(154, 25);
            this.lblPublicationDate.TabIndex = 14;
            this.lblPublicationDate.Text = "PublicationDate:";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblISBN.Location = new System.Drawing.Point(143, 199);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(64, 25);
            this.lblISBN.TabIndex = 12;
            this.lblISBN.Text = "ISBN:";
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.AutoSize = true;
            this.lblBookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBookTitle.Location = new System.Drawing.Point(143, 158);
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Size = new System.Drawing.Size(55, 25);
            this.lblBookTitle.TabIndex = 10;
            this.lblBookTitle.Text = "Title:";
            // 
            // lblBookID
            // 
            this.lblBookID.AutoSize = true;
            this.lblBookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBookID.Location = new System.Drawing.Point(143, 117);
            this.lblBookID.Name = "lblBookID";
            this.lblBookID.Size = new System.Drawing.Size(82, 25);
            this.lblBookID.TabIndex = 8;
            this.lblBookID.Text = "BookID:";
            // 
            // dtpPublicationDate
            // 
            this.dtpPublicationDate.Location = new System.Drawing.Point(349, 243);
            this.dtpPublicationDate.Name = "dtpPublicationDate";
            this.dtpPublicationDate.Size = new System.Drawing.Size(196, 22);
            this.dtpPublicationDate.TabIndex = 17;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGenre.Location = new System.Drawing.Point(143, 286);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(72, 25);
            this.lblGenre.TabIndex = 18;
            this.lblGenre.Text = "Genre:";
            // 
            // lblAdditionalDetails
            // 
            this.lblAdditionalDetails.AutoSize = true;
            this.lblAdditionalDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAdditionalDetails.Location = new System.Drawing.Point(143, 331);
            this.lblAdditionalDetails.Name = "lblAdditionalDetails";
            this.lblAdditionalDetails.Size = new System.Drawing.Size(163, 25);
            this.lblAdditionalDetails.TabIndex = 19;
            this.lblAdditionalDetails.Text = "AdditionalDetails:";
            // 
            // txtAdditionalDetails
            // 
            this.txtAdditionalDetails.Location = new System.Drawing.Point(349, 334);
            this.txtAdditionalDetails.Multiline = true;
            this.txtAdditionalDetails.Name = "txtAdditionalDetails";
            this.txtAdditionalDetails.Size = new System.Drawing.Size(196, 108);
            this.txtAdditionalDetails.TabIndex = 20;
            // 
            // frmAddEditBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 546);
            this.Controls.Add(this.txtAdditionalDetails);
            this.Controls.Add(this.lblAdditionalDetails);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.dtpPublicationDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtBookTitle);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.lblPublicationDate);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.lblBookTitle);
            this.Controls.Add(this.lblBookID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddEditBook";
            this.Load += new System.EventHandler(this.frmAddEditBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.Label lblPublicationDate;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblBookTitle;
        private System.Windows.Forms.Label lblBookID;
        private System.Windows.Forms.DateTimePicker dtpPublicationDate;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblAdditionalDetails;
        private System.Windows.Forms.TextBox txtAdditionalDetails;
    }
}