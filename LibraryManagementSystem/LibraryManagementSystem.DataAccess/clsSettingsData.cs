using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;


namespace LibraryManagementSystem.DataAccess
{
    public class clsSettingsData
    {
        public static DataTable GetSettings()
        {
            var dt = new DataTable();

            string query = @"Select * From Settings;";

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

        public static bool UpdateSettings(int DefaultBorrowDays,int DefaultFinePerDay)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                string query = @"Update Settings
                                 Set 
                                 DefaultBorrowDays = @DefaultBorrowDays,
                                 DefaultFinePerDay = @DefaultFinePerDay;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DefaultBorrowDays", DefaultBorrowDays);
                    command.Parameters.AddWithValue("@DefaultFinePerDay", DefaultFinePerDay);


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

        public static int GetDefaultBorrowDays()
        {
            int num = -1;

            string query = @"Select DefaultBorrowDays From Settings;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        num = Convert.ToInt32(result);
                }

                return num;
            }

        }

        public static int GetDefaultFinePerDay()
        {
            int num = -1;

            string query = @"Select DefaultFinePerDay From Settings;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        num = Convert.ToInt32(result);
                }

                return num;
            }

        }

        public static bool GetSettings(ref int DefaultBorrowDays, ref int DefaultFinePerDay)
        {
            bool isFound = false;

            DefaultBorrowDays = GetDefaultBorrowDays();
            DefaultFinePerDay = GetDefaultFinePerDay();

            if (DefaultBorrowDays != -1 && DefaultFinePerDay != -1)
                isFound = true;


            return isFound;
        }

    }
}