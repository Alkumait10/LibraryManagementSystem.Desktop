using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.DataAccess
{
    public class clsBookData
    {
        public static DataTable GetAllBooks()
        {
            var dt = new DataTable();

            string query = @"Select * From Books;";

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

        public static bool GetBookByID(int BookID, ref string Title, ref string ISBN, ref DateTime PublicationDate, ref string Genre, ref string AdditionalDetails)
        {
            bool isFound = false;

            string query = @"Select * From Books
                             Where BookID = @BookID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@BookID", BookID);

                    try
                    {
                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            BookID = (int)reader["BookID"];
                            Title = (string)reader["Title"];
                            ISBN = (string)reader["ISBN"];
                            PublicationDate = (DateTime)reader["PublicationDate"];
                            Genre = (string)reader["Genre"];
                            AdditionalDetails = (string)reader["AdditionalDetails"];
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

        public static int AddNewBook(string Title, string ISBN, DateTime PublicationDate, string Genre, string AdditionalDetails)
        {
            int BookID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"INSERT INTO Books (Title,ISBN,PublicationDate,Genre,AdditionalDetails)
                                VALUES(@Title,@ISBN,@PublicationDate,@Genre,@AdditionalDetails);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@ISBN", ISBN);
                    command.Parameters.AddWithValue("@PublicationDate", PublicationDate);
                    command.Parameters.AddWithValue("@Genre", Genre);
                    command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            BookID = insertedID;
                        }
                    }
                    catch (Exception)
                    {
                        BookID = -1;
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return BookID;
                }
            }
        }

        public static bool UpdateBook(int BookID, string Title, string ISBN, DateTime PublicationDate, string Genre, string AdditionalDetails)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Update Books
                                set
                                Title = @Title,
                                ISBN = @ISBN,
                                PublicationDate = @PublicationDate,
                                Genre = @Genre,
                                AdditionalDetails = @AdditionalDetails
                                where BookID = @BookID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@ISBN", ISBN);
                    command.Parameters.AddWithValue("@PublicationDate", PublicationDate);
                    command.Parameters.AddWithValue("@Genre", Genre);
                    command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails);
                    command.Parameters.AddWithValue("@BookID", BookID);

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

        public static bool DeleteBook(int BookID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Delete From Books 
                                where BookID = @BookID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@BookID", BookID);

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

        public static bool IsBookExist(int BookID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = "SELECT Found=1 FROM Books WHERE BookID = @BookID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@BookID", BookID);

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