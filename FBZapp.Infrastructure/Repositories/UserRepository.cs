using System.Configuration;
using System.Data.SqlClient;
using FBZapp.Application.Interfaces;
using FBZapp.Domain.Entities;

namespace FBZapp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["FBZappDB"]
                .ConnectionString;
        }

        public User GetByUsername(string username)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(
                    "SELECT * FROM Users WHERE Username = @Username",
                    conn);

                cmd.Parameters.AddWithValue("@Username", username);

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new User
                    {
                        Id = (int)reader["Id"],
                        Username = reader["Username"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        Role = reader["Role"].ToString()
                    };
                }
            }
        }

        public void AddUser(User user)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)",
                    conn);

                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                cmd.Parameters.AddWithValue("@Role", user.Role);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
