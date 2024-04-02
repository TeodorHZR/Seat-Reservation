using System.Collections.Generic;
using Dapper;
using Proiect_Inginerie_Software.Models;

namespace Proiect_Inginerie_Software.Repositories
{
    public class SectorRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public SectorRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Sector> GetAllSectors()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<Sector>("SELECT * FROM Sectors");
            }
        }

        public IEnumerable<Sector> GetSectorById(int evenimentId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<Sector>("SELECT * FROM Sectors WHERE IdEveniment = @IdEveniment", new { IdEveniment = evenimentId });
            }
        }

        public Sector GetSectorByIdEveniment(int sectorId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Sector>("SELECT * FROM Sectors WHERE IdSector = @IdSector", new { IdSector = sectorId });
            }
        }

        public void AddSector(Sector sector)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("INSERT INTO Sectors (IdEveniment, Nume, Capacity) VALUES (@IdEveniment, @Nume, @Capacity)", sector);
            }
        }

        public void UpdateSector(Sector sector)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("UPDATE Sectors SET EventId = @EventId, Name = @Name, Capacity = @Capacity WHERE SectorId = @SectorId", sector);
            }
        }

        public void DeleteSector(int sectorId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("DELETE FROM Sectors WHERE SectorId = @SectorId", new { SectorId = sectorId });
            }
        }
    }
}
