using System;
using System.Data;
using LibraryManagementSystem.DataAccess;

namespace LibraryManagementSystem.BusinessLogic
{
    public class clsBook
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int BookID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Genre { get; set; }
        public string AdditionalDetails { get; set; }


        public clsBook()
        {
            this.BookID = -1;
            this.Title = "";
            this.ISBN = "";
            this.PublicationDate = DateTime.Now;
            this.Genre = "";
            this.AdditionalDetails = "";

            Mode = enMode.AddNew;
        }

        private clsBook(int BookID, string Title, string ISBN, DateTime PublicationDate, string Genre, string AdditionalDetails)
        {
            this.BookID = BookID;
            this.Title = Title;
            this.ISBN = ISBN;
            this.PublicationDate = PublicationDate;
            this.Genre = Genre;
            this.AdditionalDetails = AdditionalDetails;

            Mode = enMode.Update;
        }

        private bool _AddNewBook()
        {
            this.BookID = clsBookData.AddNewBook(this.Title, this.ISBN, this.PublicationDate, this.Genre, this.AdditionalDetails);

            return (this.BookID != -1);
        }

        private bool _UpdateBook()
        {
            return clsBookData.UpdateBook(this.BookID, this.Title, this.ISBN, this.PublicationDate, this.Genre, this.AdditionalDetails);
        }

        public static DataTable GetAllBooks()
        {
            return clsBookData.GetAllBooks();
        }

        public static clsBook FindBookByID(int BookID)
        {
            string Title = "";
            string ISBN = "";
            DateTime PublicationDate = DateTime.Now;
            string Genre = "";
            string AdditionalDetails = "";

            bool IsFound = clsBookData.GetBookByID(BookID, ref Title, ref ISBN, ref PublicationDate, ref Genre, ref AdditionalDetails);

            if (IsFound)
                return new clsBook(BookID, Title, ISBN, PublicationDate, Genre, AdditionalDetails);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBook())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBook();

            }

            return false;
        }

        public static bool DeleteBook(int ID)
        {
            return clsBookData.DeleteBook(ID);
        }

        public static bool IsBookExist(int BookID)
        {
            return clsBookData.IsBookExist(BookID);
        }
    }
}