using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;


namespace LibraryManagementSystem.DataAccess
{
    public class clsBorrowingRecordData
    {
        public static int AddNewBorrowingRecord(int UserID, int CopyID, DateTime BorrowingDate, DateTime DueDate)
        {
            int BorrowingRecordID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Insert into BorrowingRecords (UserID,CopyID,BorrowingDate,DueDate)
                                 Values (@UserID,@CopyID,@BorrowingDate,@DueDate);
                                 Select SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@CopyID", CopyID);
                    command.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);
                    command.Parameters.AddWithValue("@DueDate", DueDate);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            BorrowingRecordID = insertedID;
                        }
                    }
                    catch (Exception)
                    {
                        BorrowingRecordID = -1;
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return BorrowingRecordID;
                }
            }
        }

        public static DataTable GetAllBorrowingRecords()
        {
            var dt = new DataTable();

            string query = @"Select * From BorrowingRecords_View;";

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

        public static DataTable GetAllBorrowingRecords(int UserID)
        {
            var dt = new DataTable();

            string query = @"Select * From BorrowingRecords_View
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


        public static bool GetBorrowingRecordByID(int BorrowingRecordID, ref int UserID, ref int CopyID, ref DateTime BorrowingDate, ref DateTime DueDate, ref DateTime? ActualReturnDate)
        {
            bool isFound = false;

            string query = @"Select * From BorrowingRecords
                             Where BorrowingRecordID = @BorrowingRecordID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            BorrowingRecordID = (int)reader["BorrowingRecordID"];
                            UserID = (int)reader["UserID"];
                            CopyID = (int)reader["CopyID"];
                            BorrowingDate = (DateTime)reader["BorrowingDate"];
                            DueDate = (DateTime)reader["DueDate"];

                            if (reader["ActualReturnDate"] != DBNull.Value)
                                ActualReturnDate = (DateTime)reader["ActualReturnDate"];
                            else
                                ActualReturnDate = null;
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

        public static bool ReturnBook(int BorrowingRecordID, DateTime? ActualReturnDate)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Update BorrowingRecords
                                 Set ActualReturnDate = @ActualReturnDate
                                 Where BorrowingRecordID = @BorrowingRecordID And ActualReturnDate is null;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
                    command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);


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

        public static DataTable GetActiveBorrowingRecords()
        {
            var dt = new DataTable();

            string query = @"Select * From BorrowingRecords_View
                             where ActualReturnDate is null;";

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

        public static bool IsBorrowingRecordExist(int BorrowingRecordID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT Found=1 FROM BorrowingRecords WHERE BorrowingRecordID = @BorrowingRecordID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

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