using System;
using System.Data;
using LibraryManagementSystem.DataAccess;

namespace LibraryManagementSystem.BusinessLogic
{
    public class clsBookCopy
    {
        public enum enMode { Update = 1 };
        public enMode Mode = enMode.Update;

        public int CopyID { get; set; }

        public int BookID { get; set; }
        public clsBook BookInfo { get; set; }

        public bool AvailabilityStatus { get; set; }


        public clsBookCopy()
        {
            this.CopyID = -1;
            this.BookID = -1;
            this.AvailabilityStatus = false;

        }

        private clsBookCopy(int CopyID, int BookID, bool AvailabilityStatus)
        {
            this.CopyID = CopyID;

            this.BookID = BookID;
            this.BookInfo = clsBook.FindBookByID(BookID);

            this.AvailabilityStatus = AvailabilityStatus;

            Mode = enMode.Update;
        }

        private bool _UpdateBookCopyStatus()
        {
            return clsBookCopyData.UpdateBookCopyStatus(this.CopyID, this.AvailabilityStatus);
        }

        public static DataTable GetAllBookCopies()
        {
            return clsBookCopyData.GetAllBookCopies();
        }

        public static clsBookCopy FindBookCopyByID(int CopyID)
        {
            int BookID = -1;
            bool AvailabilityStatus = false;

            bool IsFound = clsBookCopyData.GetBookCopyByID(CopyID, ref BookID, ref AvailabilityStatus);

            if (IsFound)
                return new clsBookCopy(CopyID, BookID, AvailabilityStatus);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    return _UpdateBookCopyStatus();

            }

            return false;
        }

        public static bool DeleteBookCopy(int ID)
        {
            return clsBookCopyData.DeleteBookCopy(ID);
        }

        public static bool IsBookCopyExist(int CopyID)
        {
            return clsBookCopyData.IsBookCopyExist(CopyID);
        }

        public static bool AddNewCopy(int BookID)
        {
            if (!clsBook.IsBookExist(BookID))
                return false;

            return (clsBookCopyData.AddNewBookCopy(BookID) != -1);
        }
    }
}