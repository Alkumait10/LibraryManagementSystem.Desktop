using LibraryManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;

namespace LibraryManagementSystem.BusinessLogic
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID {  get; set; }
        public string Name {  get; set; }
        public string ContactInformation { get; set; }
        public string LibraryCardNumber { get; set; }


        public clsUser()
        {
            this.UserID = -1;
            this.Name = "";
            this.ContactInformation = "";
            this.LibraryCardNumber = "";

            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, string Name, string ContactInformation, string LibraryCardNumber)
        {
            this.UserID = UserID;
            this.Name = Name;
            this.ContactInformation = ContactInformation;
            this.LibraryCardNumber = LibraryCardNumber;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.Name, this.ContactInformation, this.LibraryCardNumber);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.Name, this.ContactInformation, this.LibraryCardNumber);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static clsUser FindUserByID(int UserID)
        {
            string Name = "";
            string ContactInformation = "";
            string LibraryCardNumber = "";

            bool IsFound = clsUserData.GetUserByID(UserID, ref Name, ref ContactInformation, ref LibraryCardNumber);

            if (IsFound)
                return new clsUser(UserID, Name, ContactInformation, LibraryCardNumber);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();

            }

            return false;
        }

        public static bool DeleteUser(int ID)
        {
            return clsUserData.DeleteUser(ID);
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }
    }
}