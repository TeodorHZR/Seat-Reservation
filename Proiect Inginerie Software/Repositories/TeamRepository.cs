using System.Collections.Generic;
using Dapper;
using Proiect_Inginerie_Software.Models;

namespace Proiect_Inginerie_Software.Repositories
{
    public class TeamRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public TeamRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<Team>("SELECT * FROM Teams");
            }
        }

        public Team GetTeamById(int teamId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Team>("SELECT * FROM Teams WHERE TeamId = @TeamId", new { TeamId = teamId });
            }
        }

        public void AddTeam(Team team)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("INSERT INTO Teams (Name, Country, YearFounded, Coach) VALUES (@Name, @Country, @YearFounded, @Coach)", team);
            }
        }

        public void UpdateTeam(Team team)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("UPDATE Teams SET Name = @Name, Country = @Country, YearFounded = @YearFounded, Coach = @Coach WHERE TeamId = @TeamId", team);
            }
        }

        public void DeleteTeam(int teamId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("DELETE FROM Teams WHERE TeamId = @TeamId", new { TeamId = teamId });
            }
        }
    }
}
