using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Inginerie_Software.Models;
using Proiect_Inginerie_Software.Repositories;

namespace Proiect_Inginerie_Software.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly EventRepository _eventRepository;

        public IEnumerable<Event> Events { get; set; }

        public PrivacyModel(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void OnGet()
        {
            Events = _eventRepository.GetAllEvents();
        }
    }
}
