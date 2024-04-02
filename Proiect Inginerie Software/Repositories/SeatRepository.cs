using System.Collections.Generic;
using Dapper;
using Proiect_Inginerie_Software.Models;

namespace Proiect_Inginerie_Software.Repositories
{
    public class SeatRepository
    {
        private readonly SqlConnectionFactory _connectionFactory;

        public SeatRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Seat> GetAllSeats()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<Seat>("SELECT * FROM Seats");
            }
        }
        public IEnumerable<Seat> GetSeatBySectorValid(int sectorId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<Seat>("SELECT * FROM Seats WHERE IdSector = @IdSector AND IsAvailable = 1", new { IdSector = sectorId });
            }
        }
        public IEnumerable<Seat> GetSeatBySector(int sectorId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.Query<Seat>("SELECT * FROM Seats WHERE IdSector = @IdSector", new { IdSector = sectorId });
            }
        }
        public Seat GetSeatById(int seatId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Seat>("SELECT * FROM Seats WHERE IdLoc = @IdLoc", new { IdLoc = seatId });
            }
        }

        public void AddSeat(Seat seat)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("INSERT INTO Seats (IdSector, Numar, IsAvailable) VALUES (@IdSector, @Numar, @IsAvailable)", seat);
            }
        }

        public void UpdateSeat(Seat seat)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("UPDATE Seats SET IdSector = @IdSector,  Numar = @Numar, IsAvailable = @IsAvailable WHERE IdLoc = @IdLoc", seat);
            }
        }
        public void UpdateSeatID(int seatId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                
                connection.Execute("UPDATE Seats SET IsAvailable = 0 WHERE IdLoc = @IdLoc", new { IdLoc = seatId });
            }
        }

        public void DeleteSeat(int seatId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                connection.Execute("DELETE FROM Seats WHERE IdLoc = @IdLoc", new { IdLoc = seatId });
            }
        }
    }
}
