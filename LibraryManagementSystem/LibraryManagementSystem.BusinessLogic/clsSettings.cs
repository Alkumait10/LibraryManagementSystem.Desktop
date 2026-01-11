using System;
using System.Data;
using LibraryManagementSystem.DataAccess;


namespace LibraryManagementSystem.BusinessLogic
{
    public class clsSettings
    {
        public enum enMode { Update = 1 };
        public enMode Mode = enMode.Update;

        public int DefaultBorrowDays { get; set; }
        public int DefaultFinePerDay { get; set; }

        public clsSettings(int DefaultBorrowDays, int DefaultFinePerDay)
        {
            this.DefaultBorrowDays = DefaultBorrowDays;
            this.DefaultFinePerDay = DefaultFinePerDay;

            Mode = enMode.Update;
        }

        private bool _UpdateSettings()
        {
            return clsSettingsData.UpdateSettings(this.DefaultBorrowDays, this.DefaultFinePerDay);
        }

        public static DataTable GetSettings()
        {
            return clsSettingsData.GetSettings();
        }

        public static int GetDefaultBorrowDays()
        {
            return clsSettingsData.GetDefaultBorrowDays();
        }

        public static int GetDefaultFinePerDay()
        {
            return clsSettingsData.GetDefaultFinePerDay();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    return _UpdateSettings();

            }

            return false;
        }

        public static clsSettings GetSetting()
        {
            int DefaultBorrowDays = -1;
            int DefaultFinePerDay = -1;

            bool IsFound = clsSettingsData.GetSettings(ref DefaultBorrowDays, ref DefaultFinePerDay);

            if (IsFound)
                return new clsSettings(DefaultBorrowDays, DefaultFinePerDay);
            else
                return null;
        }

    }
}