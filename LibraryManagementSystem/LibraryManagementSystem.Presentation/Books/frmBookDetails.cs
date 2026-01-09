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
using System.Xml.Linq;

namespace LibraryManagementSystem.Presentation
{
    public partial class frmBookDetails : Form
    {
        private int _BookID;
        private clsBook _Book;
        public frmBookDetails(int BookID)
        {
            InitializeComponent();

            _BookID = BookID;
        }

        private void frmBookDetails_Load(object sender, EventArgs e)
        {
            _Book = clsBook.FindBookByID(_BookID);

            txtBookID.Text = _BookID.ToString();
            txtTitle.Text = _Book.Title.ToString();
            txtISBN.Text = _Book.ISBN.ToString();
            dtpPublicationDate.Value = _Book.PublicationDate;
            txtGenre.Text = _Book.Genre.ToString();
            txtAdditionalDetails.Text = _Book.AdditionalDetails.ToString();

            btnEdit.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int BookID = Convert.ToInt32(txtBookID.Text);

            frmAddEditBook frm = new frmAddEditBook(BookID);
            frm.ShowDialog();

            frmBookDetails_Load(null, null);

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
