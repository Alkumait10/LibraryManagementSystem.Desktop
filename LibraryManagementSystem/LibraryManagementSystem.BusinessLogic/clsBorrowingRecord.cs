using System;
using System.Data;
using LibraryManagementSystem.DataAccess;


namespace LibraryManagementSystem.BusinessLogic
{
    public class clsBorrowingRecord
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int BorrowingRecordID { get; set; }

        public int UserID { get; set; }
        public clsUser UserInfo { get; set; }


        public int CopyID { get; set; }
        public clsBookCopy CopyInfo { get; set; }


        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }


        public clsBorrowingRecord()
        {
            this.BorrowingRecordID = -1;
            this.UserID = -1;
            this.CopyID = -1;
            this.BorrowingDate = DateTime.Now;
            this.DueDate = DateTime.Now;
            this.ActualReturnDate = null;

            Mode = enMode.AddNew;
        }

        private clsBorrowingRecord(int BorrowingRecordID, int UserID, int CopyID, DateTime BorrowingDate, DateTime DueDate, DateTime? ActualReturnDate)
        {
            this.BorrowingRecordID = BorrowingRecordID;
            this.UserID = UserID;
            this.CopyID = CopyID;
            this.BorrowingDate = BorrowingDate;
            this.DueDate = DueDate;
            this.ActualReturnDate = ActualReturnDate;

            Mode = enMode.Update;
        }

        private bool _AddNewBorrowingRecord()
        {
            this.BorrowingRecordID = clsBorrowingRecordData.AddNewBorrowingRecord(this.UserID, this.CopyID, this.BorrowingDate, this.DueDate);

            return (this.BorrowingRecordID != -1);
        }

        private bool _UpdateBorrowingRecord()
        {
            return clsBorrowingRecordData.ReturnBook(BorrowingRecordID, ActualReturnDate);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBorrowingRecord())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateBorrowingRecord();
            }

            return false;
        }

        public static clsBorrowingRecord Find(int BorrowingRecordID)
        {
            int UserID = -1;
            int CopyID = -1;
            DateTime BorrowingDate = DateTime.Now;
            DateTime DueDate = DateTime.Now;
            DateTime? ActualReturnDate = null;

            bool isFound = clsBorrowingRecordData.GetBorrowingRecordByID(BorrowingRecordID, ref UserID, ref CopyID, ref BorrowingDate, ref DueDate, ref ActualReturnDate);

            if (isFound)
                return new clsBorrowingRecord(BorrowingRecordID, UserID, CopyID, BorrowingDate, DueDate, ActualReturnDate);

            return null;
        }

        public static DataTable GetAllBorrowingRecords()
        {
            return clsBorrowingRecordData.GetAllBorrowingRecords();
        }

        public static DataTable GetAllBorrowingRecords(int UserID)
        {
            return clsBorrowingRecordData.GetAllBorrowingRecords(UserID);
        }


        public static DataTable GetActiveBorrowingRecords()
        {
            return clsBorrowingRecordData.GetActiveBorrowingRecords();
        }

        public static bool BorrowBook(int UserID, int CopyID)
        {
            if (!clsBookCopy.IsBookCopyExist(CopyID))
                return false;

            bool isAvailable = false;
            int bookID = -1;

            if (!clsBookCopyData.GetBookCopyByID(CopyID, ref bookID, ref isAvailable))
                return false;

            if (!isAvailable)
                return false;

            int defaultBorrowDays = clsSettings.GetDefaultBorrowDays();

            DateTime borrowingDate = DateTime.Now;
            DateTime dueDate = borrowingDate.AddDays(defaultBorrowDays);

            int borrowingRecordID = clsBorrowingRecordData.AddNewBorrowingRecord(UserID, CopyID, borrowingDate, dueDate);

            if (borrowingRecordID == -1)
                return false;

            if (!clsBookCopyData.UpdateBookCopyStatus(CopyID, false))
                return false;

            return true;
        }

        public bool ReturnBook()
        {
            if (this.ActualReturnDate != null)
                return false;

            this.ActualReturnDate = DateTime.Now;

            bool returned = clsBorrowingRecordData.ReturnBook(this.BorrowingRecordID, this.ActualReturnDate.Value);

            if (!returned)
                return false;

            clsBookCopyData.UpdateBookCopyStatus(this.CopyID, true);

            int lateDays = (ActualReturnDate.Value - DueDate).Days;

            if (lateDays > 0)
            {
                int finePerDay = clsSettingsData.GetDefaultFinePerDay();
                int fineAmount = lateDays * finePerDay;

                clsFine fine = new clsFine();

                fine.UserID = this.UserID;
                fine.BorrowingRecordID = this.BorrowingRecordID;

                fine.NumberOfLateDays = lateDays;
                fine.FineAmount = fineAmount;

                fine.Save();
            }
            clsReservation reservation = clsReservation.GetFirstReservationByCopyID(this.CopyID);

            if (reservation != null)
            {
                clsBorrowingRecord newBorrow = new clsBorrowingRecord();

                newBorrow.UserID = reservation.UserID;
                newBorrow.CopyID = reservation.CopyID;
                newBorrow.BorrowingDate = DateTime.Now;
                newBorrow.DueDate = DateTime.Now.AddDays(clsSettings.GetDefaultBorrowDays());
                newBorrow.ActualReturnDate = null;

                if (newBorrow.Save())
                {
                    clsBookCopyData.UpdateBookCopyStatus(this.CopyID, false);
                    clsReservation.DeleteReservation(reservation.ReservationID);
                }
            }

            return true;
        }
    }
}