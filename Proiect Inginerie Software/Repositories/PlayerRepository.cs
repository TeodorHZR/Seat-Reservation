using System.Collections.Generic;
using Dapper;
using Proiect_Inginerie_Software.Models;

namespace Proiect_Inginerie_Software.Repositories
{
    public class PlayerRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public PlayerRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<Player>("SELECT * FROM Players");
            }
        }

        public Player GetPlayerById(int playerId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Player>("SELECT * FROM Players WHERE PlayerId = @PlayerId", new { PlayerId = playerId });
            }
        }
        public List<Player> GetPlayersByTeamId(int teamId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var players = connection.Query<Player>("SELECT * FROM Players WHERE TeamId = @TeamId", new { TeamId = teamId });
                return players.ToList();
            }
        }


        public void AddPlayer(Player player)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("INSERT INTO Players (Name, Age, Position, TeamId) VALUES (@Name, @Age, @Position, @TeamId)", player);
            }
        }

        public void UpdatePlayer(Player player)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("UPDATE Players SET Name = @Name, Age = @Age, Position = @Position, TeamId = @TeamId WHERE PlayerId = @PlayerId", player);
            }
        }

        public void DeletePlayer(int playerId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("DELETE FROM Players WHERE PlayerId = @PlayerId", new { PlayerId = playerId });
            }
        }
    }
}
