using LibraryManagementSystem.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BusinessLogic
{
    public class clsReservation
    {
        public int ReservationID { get; set; }
        public int UserID { get; set; }
        public int CopyID { get; set; }
        public DateTime ReservationDate { get; set; }


        private clsReservation(int ReservationID, int UserID, int CopyID, DateTime ReservationDate)
        {
            this.ReservationID = ReservationID;
            this.UserID = UserID;
            this.CopyID = CopyID;
            this.ReservationDate = ReservationDate;
        }

        public static bool AddNewReservation(int UserID, int CopyID)
        {
            if (clsReservationData.IsReservationExists(CopyID))
                return false;

            int reservationID = clsReservationData.AddNewReservation(UserID, CopyID, DateTime.Now);

            return (reservationID != -1);
        }

        public static clsReservation GetFirstReservationByCopyID(int copyID)
        {
            int reservationID = -1;
            int userID = -1;
            DateTime reservationDate = DateTime.Now;

            bool found = clsReservationData.GetFirstReservationByCopyID(copyID, ref reservationID, ref userID, ref reservationDate);

            if (!found)
                return null;

            return new clsReservation(reservationID, userID, copyID, reservationDate);
        }

        public static bool DeleteReservation(int reservationID)
        {
            return clsReservationData.DeleteReservation(reservationID);
        }

        public static DataTable GetReservationsByUserID(int userID)
        {
            return clsReservationData.GetReservationsByUserID(userID);
        }

        public static DataTable GetAllReservations()
        {
            return clsReservationData.GetAllReservations();
        }

        public static bool IsReservationExist(int copyID)
        {
            return clsReservationData.IsReservationExists(copyID);
        }

    }
}