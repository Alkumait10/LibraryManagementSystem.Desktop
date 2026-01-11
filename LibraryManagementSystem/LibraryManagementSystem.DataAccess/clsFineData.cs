using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;


namespace LibraryManagementSystem.DataAccess
{
    public class clsFineData
    {
        public static int AddNewFine(int UserID, int BorrowingRecordID, int NumberOfLateDays, decimal FineAmount)
        {
            int FineID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Insert into Fines (UserID,BorrowingRecordID,NumberOfLateDays,FineAmount,PaymentStatus)
                                 Values (@UserID,@BorrowingRecordID,@NumberOfLateDays,@FineAmount,0);
                                 Select SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
                    command.Parameters.AddWithValue("@NumberOfLateDays", NumberOfLateDays);
                    command.Parameters.AddWithValue("@FineAmount", FineAmount);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            FineID = insertedID;
                        }
                    }
                    catch (Exception)
                    {
                        FineID = -1;
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return FineID;
                }
            }
        }

        public static DataTable GetAllFines()
        {
            var dt = new DataTable();

            string query = @"Select * From Fines_View;";

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

        public static DataTable GetFinesByUserID(int UserID)
        {
            var dt = new DataTable();

            string query = @"Select * From Fines_View
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

        public static bool GetFineByID(int FineID, ref int UserID, ref int BorrowingRecordID, ref int NumberOfLateDays, ref decimal FineAmount, ref bool PaymentStatus)
        {
            bool isFound = false;

            string query = @"Select * From Fines
                             Where FineID = @FineID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FineID", FineID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            FineID = (int)reader["FineID"];
                            UserID = (int)reader["UserID"];
                            BorrowingRecordID = (int)reader["BorrowingRecordID"];
                            NumberOfLateDays = Convert.ToInt32((short)reader["NumberOfLateDays"]);
                            FineAmount = (decimal)reader["FineAmount"];
                            PaymentStatus = (bool)reader["PaymentStatus"];
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

        public static DataTable GetUnpaidFines()
        {
            var dt = new DataTable();

            string query = @"Select * From Fines_View
                             Where PaymentStatus = 0;";

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

        public static bool PayFine(int FineID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Update Fines
                                set
                                PaymentStatus = 1                             
                                where FineID = @FineID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FineID", FineID);

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

        public static bool IsFineExist(int FineID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT Found=1 FROM Fines WHERE FineID = @FineID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@FineID", FineID);

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