using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;


namespace LibraryManagementSystem.DataAccess
{
    public class clsReservationData
    {
        public static int AddNewReservation(int UserID, int CopyID, DateTime ReservationDate)
        {
            int ReservationID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Insert into Reservations (UserID,CopyID,ReservationDate)
                                 Values (@UserID,@CopyID,@ReservationDate);
                                 Select SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@CopyID", CopyID);
                    command.Parameters.AddWithValue("@ReservationDate", ReservationDate);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            ReservationID = insertedID;
                        }
                    }
                    catch (Exception)
                    {
                        ReservationID = -1;
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return ReservationID;
                }
            }
        }

        public static bool GetFirstReservationByCopyID(int CopyID, ref int ReservationID, ref int UserID, ref DateTime ReservationDate)
        {
            bool isFound = false;

            string query = @"Select Top 1 * From Reservations
                             Where CopyID  = @CopyID
                             Order By ReservationDate asc;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CopyID", CopyID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            UserID = (int)reader["UserID"];
                            CopyID = (int)reader["CopyID"];
                            ReservationID = (int)reader["ReservationID"];
                            ReservationDate = (DateTime)reader["ReservationDate"];

                        }
                        else
                            isFound = false;

                        reader.Close();
                    }
                    catch (Exception)
                    {
                        isFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return isFound;
        }

        public static bool DeleteReservation(int ReservationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Delete From Reservations 
                                where ReservationID = @ReservationID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ReservationID", ReservationID);

                    try
                    {
                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsAffected = 0;
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return (rowsAffected > 0);
                }
            }
        }

        public static DataTable GetReservationsByUserID(int UserID)
        {
            var dt = new DataTable();

            string query = @"Select * From Reservations
                             Where UserID = @UserID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }

                return dt;
            }
        }

        public static DataTable GetAllReservations()
        {
            var dt = new DataTable();

            string query = @"Select * from Reservations_View;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                    }
                }

                return dt;
            }
        }
    
        public static bool IsReservationExists(int CopyID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT Found=1 FROM Reservations WHERE CopyID = @CopyID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@CopyID", CopyID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        isFound = reader.HasRows;

                        reader.Close();
                    }
                    catch (Exception)
                    {
                        isFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return isFound;
                }
            }
        }
    }
}