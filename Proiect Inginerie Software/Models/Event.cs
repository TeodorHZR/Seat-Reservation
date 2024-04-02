using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proiect_Inginerie_Software.Models;
using Proiect_Inginerie_Software.Repositories;

namespace Proiect_Inginerie_Software.Models
{
    public class Event
    {
        public int IdEveniment { get; set; }
        public string Nume { get; set; }
        public DateTime DataOra { get; set; }
        public string Locatie { get; set; }
        public Stadium Stadium { get; set; }
        public Event()
        {
        }
        public Event( string nume, DateTime dataOra, string locatie)
        {
            IdEveniment = 0;
            Nume = nume;
            DataOra = dataOra;
            Locatie = locatie;
            Stadium = null; 
        }


        public void GetStadiumInfo()
        {
            if (Stadium != null)
            {
                Console.WriteLine($"Stadium Info: Name - {Stadium.Name}, Description - {Stadium.Description}, Capacity - {Stadium.Capacity}");
            }
            else
            {
                Console.WriteLine("Stadium information is not available for this event.");
            }
        }
    }
}
