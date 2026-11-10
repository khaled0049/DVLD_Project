
using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsApplicationData
    {
        // READ: Get All Applications
        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Applications";

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


        // READ: Find Application By ID
        public static bool GetApplicationInfoByID(
            int ApplicationID,
            ref int ApplicantPersonID,
            ref DateTime ApplicationDate,
            ref int ApplicationTypeID,
            ref byte ApplicationStatus,
            ref DateTime LastStatusDate,
            ref decimal PaidFees,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT * FROM Applications
                    WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@ApplicationID", ApplicationID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;

                            ApplicantPersonID =
                                (int)reader["ApplicantPersonID"];

                            ApplicationDate =
                                (DateTime)reader["ApplicationDate"];

                            ApplicationTypeID =
                                (int)reader["ApplicationTypeID"];

                            ApplicationStatus =
                                Convert.ToByte(reader["ApplicationStatus"]);

                            LastStatusDate =
                                (DateTime)reader["LastStatusDate"];

                            PaidFees =
                                (decimal)reader["PaidFees"];

                            CreatedByUserID =
                                (int)reader["CreatedByUserID"];
                        }
                    }
                }
            }

            return isFound;
        }


        // READ: Get Applications By Person ID
        public static DataTable GetApplicationsByPersonID(
            int ApplicantPersonID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT * FROM Applications
                    WHERE ApplicantPersonID = @ApplicantPersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@ApplicantPersonID", ApplicantPersonID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }


        // CREATE: Add New Application
        public static int AddNewApplication(
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            byte ApplicationStatus,
            DateTime LastStatusDate,
            decimal PaidFees,
            int CreatedByUserID)
        {
            int ApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    INSERT INTO Applications
                    (
                        ApplicantPersonID,
                        ApplicationDate,
                        ApplicationTypeID,
                        ApplicationStatus,
                        LastStatusDate,
                        PaidFees,
                        CreatedByUserID
                    )
                    VALUES
                    (
                        @ApplicantPersonID,
                        @ApplicationDate,
                        @ApplicationTypeID,
                        @ApplicationStatus,
                        @LastStatusDate,
                        @PaidFees,
                        @CreatedByUserID
                    );

                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@ApplicantPersonID", ApplicantPersonID);

                    command.Parameters.AddWithValue(
                        "@ApplicationDate", ApplicationDate);

                    command.Parameters.AddWithValue(
                        "@ApplicationTypeID", ApplicationTypeID);

                    command.Parameters.AddWithValue(
                        "@ApplicationStatus", ApplicationStatus);

                    command.Parameters.AddWithValue(
                        "@LastStatusDate", LastStatusDate);

                    command.Parameters.AddWithValue(
                        "@PaidFees", PaidFees);

                    command.Parameters.AddWithValue(
                        "@CreatedByUserID", CreatedByUserID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        ApplicationID = Convert.ToInt32(result);
                    }
                }
            }

            return ApplicationID;
        }


        // UPDATE: Update Existing Application
        public static bool UpdateApplication(
            int ApplicationID,
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            byte ApplicationStatus,
            DateTime LastStatusDate,
            decimal PaidFees,
            int CreatedByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    UPDATE Applications
                    SET
                        ApplicantPersonID = @ApplicantPersonID,
                        ApplicationDate = @ApplicationDate,
                        ApplicationTypeID = @ApplicationTypeID,
                        ApplicationStatus = @ApplicationStatus,
                        LastStatusDate = @LastStatusDate,
                        PaidFees = @PaidFees,
                        CreatedByUserID = @CreatedByUserID
                    WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@ApplicationID", ApplicationID);

                    command.Parameters.AddWithValue(
                        "@ApplicantPersonID", ApplicantPersonID);

                    command.Parameters.AddWithValue(
                        "@ApplicationDate", ApplicationDate);

                    command.Parameters.AddWithValue(
                        "@ApplicationTypeID", ApplicationTypeID);

                    command.Parameters.AddWithValue(
                        "@ApplicationStatus", ApplicationStatus);

                    command.Parameters.AddWithValue(
                        "@LastStatusDate", LastStatusDate);

                    command.Parameters.AddWithValue(
                        "@PaidFees", PaidFees);

                    command.Parameters.AddWithValue(
                        "@CreatedByUserID", CreatedByUserID);

                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected > 0;
        }


        // DELETE: Delete Application
        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    DELETE FROM Applications
                    WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@ApplicationID", ApplicationID);

                    connection.Open();

                    rowsAffected = command.ExecuteNonQuery();
                }
            }

            return rowsAffected > 0;
        }


        // Check If Application Exists
        public static bool IsApplicationExist(int ApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString))
            {
                string query = @"
                    SELECT 1 FROM Applications
                    WHERE ApplicationID = @ApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(
                        "@ApplicationID", ApplicationID);

                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
            }
        }
    }
}
