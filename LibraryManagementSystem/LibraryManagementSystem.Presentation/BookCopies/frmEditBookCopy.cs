using LibraryManagementSystem.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.Presentation
{
    public partial class frmEditBookCopy : Form
    {
        private int _CopyID;
        private clsBookCopy _bookcopy;
        public enum enMode { Update = 1 };
        private enMode _Mode;

        public frmEditBookCopy(int CopyID)
        {
            InitializeComponent();

            _CopyID = CopyID;
            _Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditBookCopy_Load(object sender, EventArgs e)
        {
            _bookcopy = clsBookCopy.FindBookCopyByID(_CopyID);
            int _BookID = _bookcopy.BookID;

            txtCopyID.Text = _CopyID.ToString();

            ctrlBookDetails1.LoadBookInfo(_BookID);

            if (_bookcopy.AvailabilityStatus == true)
            {
                cbStatus.Checked = true;
            }
            else
            {
                cbStatus.Checked = false;
            }

            btnSave.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _bookcopy.AvailabilityStatus = (cbStatus.Checked) ? true : false;

            if (_bookcopy.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
