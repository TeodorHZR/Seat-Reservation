using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Proiect_Inginerie_Software.Models; 
using Proiect_Inginerie_Software.Repositories;
using System.Diagnostics; 

namespace Proiect_Inginerie_Software.Pages
{
    public class ErrorModel : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;
        private readonly EventRepository _eventRepository;
        private readonly SectorRepository _sectorRepository;
        private readonly SeatRepository _seatRepository;

        public List<Event> Events { get; set; } 

        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public ErrorModel(ILogger<ErrorModel> logger, EventRepository eventRepository, SectorRepository sectorRepository, SeatRepository seatRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _sectorRepository = sectorRepository;
            _seatRepository = seatRepository;

        }
        public IActionResult ReserveTicket(int seatId)
        {

            _seatRepository.UpdateSeatID(seatId);
            return RedirectToPage("/Error");
        }
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            Events = (List<Event>)_eventRepository.GetAllEvents(); 
        }
        public JsonResult OnGetSectors(int eventId)
        {
            var sectors = _sectorRepository.GetSectorById(eventId);
            return new JsonResult(sectors);
        }
        public JsonResult OnGetSeats(int sectorId)
        {
            var seats = _seatRepository.GetSeatBySectorValid(sectorId);
            return new JsonResult(seats);
        }
       

    }
}
