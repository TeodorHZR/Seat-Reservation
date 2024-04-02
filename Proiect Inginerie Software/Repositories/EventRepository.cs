using System.Collections.Generic;
using Dapper;
using Proiect_Inginerie_Software.Models;

namespace Proiect_Inginerie_Software.Repositories
{
    public class EventRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public EventRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<Event>("SELECT * FROM Events");
            }
        }

        public Event GetEventById(int eventId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Event>("SELECT * FROM Events WHERE IdEveniment = @IdEveniment", new { IdEveniment = eventId });
            }
        }

        public void AddEvent(Event @event)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("INSERT INTO Events (Nume, DataOra, Locatie) VALUES (@Nume, @DataOra, @Locatie)", @event);
            }
        }

        public void UpdateEvent(Event @event)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("UPDATE Events SET Nume = @Nume, DataOra = @DataOra, Locatie = @Locatie WHERE IdEveniment = @IdEveniment", @event);
            }
        }

        public void DeleteEvent(int eventId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("DELETE FROM Events WHERE IdEveniment = @IdEveniment", new { IdEveniment = eventId });
            }
        }
    }
}
