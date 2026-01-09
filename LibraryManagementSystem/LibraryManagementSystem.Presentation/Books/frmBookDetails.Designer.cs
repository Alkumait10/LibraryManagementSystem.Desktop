namespace LibraryManagementSystem.Presentation
{
    partial class frmBookDetails
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.lblPublicationDate = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBookID = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblAdditionalDetails = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtAdditionalDetails = new System.Windows.Forms.TextBox();
            this.dtpPublicationDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnClose.Location = new System.Drawing.Point(129, 317);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 51);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEdit.Location = new System.Drawing.Point(383, 317);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(143, 51);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(330, 139);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.ReadOnly = true;
            this.txtISBN.Size = new System.Drawing.Size(196, 22);
            this.txtISBN.TabIndex = 16;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(330, 98);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(196, 22);
            this.txtTitle.TabIndex = 14;
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(330, 57);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.ReadOnly = true;
            this.txtBookID.Size = new System.Drawing.Size(196, 22);
            this.txtBookID.TabIndex = 20;
            // 
            // lblPublicationDate
            // 
            this.lblPublicationDate.AutoSize = true;
            this.lblPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPublicationDate.Location = new System.Drawing.Point(124, 180);
            this.lblPublicationDate.Name = "lblPublicationDate";
            this.lblPublicationDate.Size = new System.Drawing.Size(154, 25);
            this.lblPublicationDate.TabIndex = 21;
            this.lblPublicationDate.Text = "PublicationDate:";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblISBN.Location = new System.Drawing.Point(124, 135);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(64, 25);
            this.lblISBN.TabIndex = 19;
            this.lblISBN.Text = "ISBN:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTitle.Location = new System.Drawing.Point(124, 94);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(55, 25);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "Title:";
            // 
            // lblBookID
            // 
            this.lblBookID.AutoSize = true;
            this.lblBookID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBookID.Location = new System.Drawing.Point(124, 53);
            this.lblBookID.Name = "lblBookID";
            this.lblBookID.Size = new System.Drawing.Size(82, 25);
            this.lblBookID.TabIndex = 15;
            this.lblBookID.Text = "BookID:";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblGenre.Location = new System.Drawing.Point(124, 222);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(72, 25);
            this.lblGenre.TabIndex = 23;
            this.lblGenre.Text = "Genre:";
            // 
            // lblAdditionalDetails
            // 
            this.lblAdditionalDetails.AutoSize = true;
            this.lblAdditionalDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAdditionalDetails.Location = new System.Drawing.Point(124, 272);
            this.lblAdditionalDetails.Name = "lblAdditionalDetails";
            this.lblAdditionalDetails.Size = new System.Drawing.Size(163, 25);
            this.lblAdditionalDetails.TabIndex = 24;
            this.lblAdditionalDetails.Text = "AdditionalDetails:";
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(330, 226);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.ReadOnly = true;
            this.txtGenre.Size = new System.Drawing.Size(196, 22);
            this.txtGenre.TabIndex = 25;
            // 
            // txtAdditionalDetails
            // 
            this.txtAdditionalDetails.Location = new System.Drawing.Point(330, 276);
            this.txtAdditionalDetails.Name = "txtAdditionalDetails";
            this.txtAdditionalDetails.ReadOnly = true;
            this.txtAdditionalDetails.Size = new System.Drawing.Size(196, 22);
            this.txtAdditionalDetails.TabIndex = 26;
            // 
            // dtpPublicationDate
            // 
            this.dtpPublicationDate.Location = new System.Drawing.Point(330, 180);
            this.dtpPublicationDate.Name = "dtpPublicationDate";
            this.dtpPublicationDate.Size = new System.Drawing.Size(196, 22);
            this.dtpPublicationDate.TabIndex = 27;
            // 
            // frmBookDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpPublicationDate);
            this.Controls.Add(this.txtAdditionalDetails);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblAdditionalDetails);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.lblPublicationDate);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblBookID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBookDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Book Details";
            this.Load += new System.EventHandler(this.frmBookDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.Label lblPublicationDate;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBookID;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblAdditionalDetails;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtAdditionalDetails;
        private System.Windows.Forms.DateTimePicker dtpPublicationDate;
    }
}