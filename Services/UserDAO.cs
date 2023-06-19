using Microsoft.Data.SqlClient;
using ProjektZawody.Models;

namespace ProjektZawody.Services
{
    public class UserDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjektZawodyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        
        public bool FindUserByNameAndPassword(UserModel user)
        {
            bool success = false;
            string sqlStatement = "SELECT * FROM dbo.AllUsers WHERE username = @username AND password = @password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return success;
        }

        public string GetUserRole(UserModel user)
        {
            string role = string.Empty;
            string sqlStatement = "SELECT role FROM dbo.AllUsers WHERE username = @username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        role = reader["role"].ToString();
                        Console.WriteLine("odczytano: " + role);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return role;
        }
        public void AddUser(NewUser user)
        {
            string sqlStatement = "INSERT INTO dbo.AllUsers VALUES (@username, @password, @role)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", System.Data.SqlDbType.VarChar, 40).Value = user.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;
                command.Parameters.Add("@role", System.Data.SqlDbType.VarChar, 40).Value = user.Role;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }
        public List<UserModel> GetAllUsers()
        {
            List<UserModel> userList = new List<UserModel>();

            string sqlStatement = "SELECT * FROM dbo.AllUsers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        UserModel user = new UserModel
                        {
                            Id = (int)reader["Id"],
                            UserName = reader["username"].ToString(),
                            Password = reader["password"].ToString(),
                            Role = reader["role"].ToString()
                        };
                        userList.Add(user);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return userList;
        }

        public UserModel GetUser(int id)
        {
            UserModel user = null;
            //string sqlStatement = "SELECT * FROM dbo.AllUsers WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("getUserById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        user = new UserModel
                        {
                            Id= (int)reader["Id"],
                            UserName = reader["username"].ToString(),
                            Password = reader["password"].ToString(),
                            Role = reader["role"].ToString()
                        };
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return user;

        }


        public void DeleteUser(int id)
        {
            //string sqlStatement = "DELETE FROM dbo.AllUsers WHERE Id = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("deleteUserById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

