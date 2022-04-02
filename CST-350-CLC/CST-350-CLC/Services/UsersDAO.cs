﻿using CST_350_CLC.Models;
using System;
using System.Data.SqlClient;

namespace CST_350_CLC.Services {
    public class UsersDAO {
        // assume there are no connections
        bool success = false;

        // change to your local database connection. COPY the Connection string property of your database and paste below
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CLC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public bool FindUserByNameAndPassword(UserModel user) {
            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @Username AND password = @password";

            //allows us to generate block of code that will use connection and terminate connection after block is finished
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                //issues command to db. 2 parameters: SQL statement you want to send and the connection being connected to
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.Username;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try {
                    // initiate connection to db
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) {
                        success = true;
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
            // return true if found in db.
            return success;

        }
    }
}
