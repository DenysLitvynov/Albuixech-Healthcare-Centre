using AlbuixechHealthcareCentre.models;
using AlbuixechHealthcareCentre.repository;
using System;
using System.Linq;

namespace AlbuixechHealthcareCentre.services
{
    public class UserService
    {
        private Repository<User> userRepo;

        public UserService()
        {
            userRepo = new Repository<User>();
        }

        public User AuthUser(string username, string hashPassword)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";

            var users = userRepo.GetAll(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", hashPassword);
            }, reader => new User
            {
                UserId = Convert.ToInt32(reader["UserID"]),
                UserName = reader["Username"].ToString(),
                Password = reader["Password"].ToString(),
                Role = reader["Role"].ToString()
            });

            return users.FirstOrDefault();
        }

        public User AuthUserById(int userId)
        {
            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            var users = userRepo.GetAll(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
            }, reader => new User
            {
                UserId = Convert.ToInt32(reader["UserID"]),
                UserName = reader["Username"].ToString(),
                Password = reader["Password"].ToString(),
                Role = reader["Role"].ToString()
            });

            return users.FirstOrDefault();
        }

        public int RegisterUser(User user)
        {
            string insertQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role);";
            string getLastIdQuery = "SELECT last_insert_rowid();";

            return userRepo.ExecuteTransaction(command =>
            {
                // Ejecutar el comando de inserción
                command.CommandText = insertQuery;
                command.Parameters.AddWithValue("@Username", user.UserName);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.ExecuteNonQuery();

                // Limpiar parámetros y obtener el último ID
                command.Parameters.Clear();
                command.CommandText = getLastIdQuery;
                return Convert.ToInt32(command.ExecuteScalar());
            });
        }


        public void UpdateUser(User user)
        {
            string query = "UPDATE Users SET Username = @Username, Password = @Password, Role = @Role WHERE UserID = @UserID";
            userRepo.ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@Username", user.UserName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@UserID", user.UserId);
            });
        }

        public void DeleteUser(int userID)
        {
            string query = "DELETE FROM Users WHERE UserID = @UserID";
            userRepo.ExecuteCommand(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@UserID", userID);
            });
        }
    }
}
