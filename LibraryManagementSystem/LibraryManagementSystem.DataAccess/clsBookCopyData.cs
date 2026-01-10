using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.DataAccess
{
    public class clsBookCopyData
    {
        public static DataTable GetAllBookCopies()
        {
            var dt = new DataTable();

            string query = @"select CopyID,Books.BookID,Books.Title,AvailabilityStatus
                             From BookCopies inner join Books on BookCopies.BookID = Books.BookID;";

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

        public static bool GetBookCopyByID(int CopyID, ref int BookID, ref bool AvailabilityStatus)
        {
            bool isFound = false;

            string query = @"Select * From BookCopies
                             Where CopyID = @CopyID;";

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

                            CopyID = (int)reader["CopyID"];
                            BookID = (int)reader["BookID"];
                            AvailabilityStatus = (bool)reader["AvailabilityStatus"];
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

        public static int AddNewBookCopy(int BookID)
        {
            int CopyID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"INSERT INTO BookCopies (BookID,AvailabilityStatus)
                                VALUES(@BookID,1);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookID", BookID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            CopyID = insertedID;
                        }
                    }
                    catch (Exception)
                    {
                        CopyID = -1;
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return CopyID;
                }
            }
        }

        public static bool UpdateBookCopyStatus(int CopyID, bool AvailabilityStatus)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Update BookCopies
                                set
                                AvailabilityStatus = @AvailabilityStatus
                                where CopyID = @CopyID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);
                    command.Parameters.AddWithValue("@CopyID", CopyID);

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

        public static bool DeleteBookCopy(int CopyID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Delete From BookCopies 
                                where CopyID = @CopyID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@CopyID", CopyID);

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

        public static bool IsBookCopyExist(int CopyID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT Found=1 FROM BookCopies WHERE CopyID = @CopyID";

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