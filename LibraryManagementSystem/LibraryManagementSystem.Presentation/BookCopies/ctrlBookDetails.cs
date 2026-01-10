using LibraryManagementSystem.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.Presentation
{
    public partial class ctrlBookDetails : UserControl
    {
        private int _BookID;
        private clsBook _Book;

        public int BookID
        {
            get
            {
                return _BookID;
            }
        }
        public clsBook Book
        {
            get
            {
                return _Book;
            }
        }

        public ctrlBookDetails()
        {
            InitializeComponent();
        }

        public void LoadBookInfo(int BookID)
        {
            _BookID = BookID;
            _Book = clsBook.FindBookByID(_BookID);

            txtBookID.Text = _BookID.ToString();
            txtTitle.Text = _Book.Title.ToString();
            txtISBN.Text = _Book.ISBN.ToString();
            dtpPublicationDate.Value = _Book.PublicationDate;
            txtGenre.Text = _Book.Genre.ToString();
            txtAdditionalDetails.Text = _Book.AdditionalDetails.ToString();
        }
    }
}
