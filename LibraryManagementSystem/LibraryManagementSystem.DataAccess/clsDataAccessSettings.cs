using System;
using System.Configuration;

namespace LibraryManagementSystem.DataAccess
{
    public class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["Library_ConnectionString"].ConnectionString;
    }
}