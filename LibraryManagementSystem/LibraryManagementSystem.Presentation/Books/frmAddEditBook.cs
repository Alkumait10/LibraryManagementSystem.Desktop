using LibraryManagementSystem.BusinessLogic;
using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.Presentation
{
    public partial class frmAddEditBook : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _BookID = -1;
        clsBook _book;

        public frmAddEditBook()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditBook(int BookID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _BookID = BookID;
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Book";
                this.Text = "Add New Book";
                _book = new clsBook();
            }
            else
            {
                lblTitle.Text = "Update Book";
                this.Text = "Update Book";
            }

            txtBookTitle.Text = "";
            txtISBN.Text = "";
            txtGenre.Text = "";
            txtAdditionalDetails.Text = "";
        }

        private void _LoadData()
        {
            _book = clsBook.FindBookByID(_BookID);


            if (_book == null)
            {
                MessageBox.Show("No Book with ID = " + _BookID, "Book Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();

                return;
            }

            txtBookID.Text = _book.BookID.ToString();
            txtBookTitle.Text = _book.Title;
            txtISBN.Text = _book.ISBN;
            dtpPublicationDate.Value = _book.PublicationDate;
            txtGenre.Text = _book.Genre;
            txtAdditionalDetails.Text = _book.AdditionalDetails;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _book.Title = txtBookTitle.Text;
            _book.ISBN = txtISBN.Text;
            _book.PublicationDate = dtpPublicationDate.Value;
            _book.Genre = txtGenre.Text;
            _book.AdditionalDetails = txtAdditionalDetails.Text;

            if (_book.Save())
            {
                txtBookID.Text = _book.BookID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Book";
                this.Text = "Update Book";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmAddEditBook_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }
    }
}
