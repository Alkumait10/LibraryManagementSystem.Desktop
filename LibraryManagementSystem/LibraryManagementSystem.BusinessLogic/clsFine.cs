using LibraryManagementSystem.DataAccess;
using System;
using System.Data;
using System.Data.SqlClient;


namespace LibraryManagementSystem.BusinessLogic
{
    public class clsFine
    {
        public enum enMode { AddNew = 0 }
        public enMode Mode = enMode.AddNew;

        public int FineID { get; private set; }
        public int UserID { get; set; }
        public int BorrowingRecordID { get; set; }
        public int NumberOfLateDays { get; set; }
        public decimal FineAmount { get; set; }
        public bool PaymentStatus { get; private set; }


        public clsFine()
        {
            this.FineID = -1;
            this.UserID = -1;
            this.BorrowingRecordID = -1;
            this.NumberOfLateDays = 0;
            this.FineAmount = 0;
            this.PaymentStatus = false;

            Mode = enMode.AddNew;
        }

        private clsFine(int FineID, int UserID, int BorrowingRecordID, int NumberOfLateDays, decimal FineAmount, bool PaymentStatus)
        {
            this.FineID = FineID;
            this.UserID = UserID;
            this.BorrowingRecordID = BorrowingRecordID;
            this.NumberOfLateDays = NumberOfLateDays;
            this.FineAmount = FineAmount;
            this.PaymentStatus = PaymentStatus;

            Mode = enMode.AddNew;
        }

        private bool _AddNewFine()
        {
            this.FineID = clsFineData.AddNewFine(this.UserID, this.BorrowingRecordID, this.NumberOfLateDays, this.FineAmount);

            return (this.FineID != -1);
        }

        public bool Save()
        {
            if (Mode == enMode.AddNew)
                return _AddNewFine();

            return false;
        }

        public bool PayFine()
        {
            if (FineID == -1 || PaymentStatus)
                return false;

            bool isPaid = clsFineData.PayFine(this.FineID);

            if (isPaid)
                this.PaymentStatus = true;

            return isPaid;
        }

        public static DataTable GetAllFines()
        {
            return clsFineData.GetAllFines();
        }

        public static DataTable GetFinesByUserID(int UserID)
        {
            return clsFineData.GetFinesByUserID(UserID);
        }

        public static DataTable GetUnpaidFines()
        {
            return clsFineData.GetUnpaidFines();
        }

        public static clsFine Find(int fineID)
        {
            int userID = -1;
            int borrowingRecordID = -1;
            int numberOfLateDays = 0;
            decimal fineAmount = 0;
            bool paymentStatus = false;

            bool isFound = clsFineData.GetFineByID(fineID, ref userID, ref borrowingRecordID, ref numberOfLateDays, ref fineAmount, ref paymentStatus);

            if (isFound)
            {
                return new clsFine(fineID, userID, borrowingRecordID, numberOfLateDays, fineAmount, paymentStatus);
            }

            return null;
        }

        public static bool IsFineExist(int FineID)
        {
            return clsFineData.IsFineExist(FineID);
        }
    }
}