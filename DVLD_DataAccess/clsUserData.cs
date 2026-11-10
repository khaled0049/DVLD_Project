
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsUserData
    {
        // READ: Get All Users
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT UserID, PersonID, UserName, IsActive
                    FROM Users";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }


        // READ: Find User By ID
        public static bool GetUserInfoByID(
            int UserID,
            ref int PersonID,
            ref string UserName,
            ref string Password,
            ref bool IsActive)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT * FROM Users
                    WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            PersonID = (int)reader["PersonID"];
                            UserName = (string)reader["UserName"];
                            Password = (string)reader["Password"];
                            IsActive = (bool)reader["IsActive"];
                        }
                    }
                }
            }

            return isFound;
        }


        // READ: Find User By UserName
        public static bool GetUserInfoByUserName(
            string UserName,
            ref int UserID,
            ref int PersonID,
            ref string Password,
            ref bool IsActive)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT TOP (1) * FROM Users
                    WHERE UserName = @UserName
                    ORDER BY UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            UserID = (int)reader["UserID"];
                            PersonID = (int)reader["PersonID"];
                            Password = (string)reader["Password"];
                            IsActive = (bool)reader["IsActive"];
                        }
                    }
                }
            }

            return isFound;
        }


        // CREATE: Add New User
        public static int AddNewUser(
            int PersonID,
            string UserName,
            string Password,
            bool IsActive)
        {
            int UserID = -1;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    INSERT INTO Users
                    (PersonID, UserName, Password, IsActive)
                    VALUES
                    (@PersonID, @UserName, @Password, @IsActive);

                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        UserID = Convert.ToInt32(result);
                    }
                }
            }

            return UserID;
        }


        // UPDATE: Update Existing User
        public static bool UpdateUser(
            int UserID,
            int PersonID,
            string UserName,
            string Password,
            bool IsActive)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    UPDATE Users
                    SET
                        PersonID = @PersonID,
                        UserName = @UserName,
                        Password = @Password,
                        IsActive = @IsActive
                    WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected > 0;
        }


        // DELETE: Delete User
        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    DELETE FROM Users
                    WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected > 0;
        }


        // Check If User Exists By ID
        public static bool IsUserExist(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT 1 FROM Users
                    WHERE UserID = @UserID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);

                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
            }
        }


        // Check If User Exists By UserName
        public static bool IsUserExistByUserName(string UserName)
        {
            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT 1 FROM Users
                    WHERE UserName = @UserName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", UserName);

                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
            }
        }
    }
}
