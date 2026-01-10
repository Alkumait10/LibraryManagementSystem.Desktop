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
    public partial class frmCopyDetails : Form
    {
        private int _CopyID;
        public clsBookCopy _bookcopy;

        public frmCopyDetails(int CopyID)
        {
            InitializeComponent();

            _CopyID = CopyID;
        }

        private void frmCopyDetails_Load(object sender, EventArgs e)
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

            cbStatus.Focus();
        }
    }
}
