using System.Collections.Generic;
using Dapper;
using Proiect_Inginerie_Software.Models;

namespace Proiect_Inginerie_Software.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public UserRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<User>("SELECT * FROM Users");
            }
        }

        public User GetUserById(int userId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE UserId = @UserId", new { UserId = userId });
            }
        }

        public bool IsAdmin(string Nume)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var user = connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Username = @Nume AND IsAdmin = 1", new { Nume = Nume });
                return user != null;
            }
        }
        public void AddUser(User user)
        {
            user.isAdmin = 0;
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("INSERT INTO Users (Username, Password, isAdmin, Email ) VALUES (@Username, @Password, @IsAdmin, @Email)", user);
            }
        }
        public bool Authenticate(string username, string password)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var user = connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Username = @Username AND Password = @Password", new { Username = username, Password = password });
                return user != null;
            }
        }
    }
}
