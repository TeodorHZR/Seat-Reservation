using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Inginerie_Software.Models;
using Proiect_Inginerie_Software.Repositories;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Proiect_Inginerie_Software.Pages
{
    public class AdminPageModel : PageModel
    {
        private readonly EventRepository _eventRepository;
        private readonly PlayerRepository _playerRepository;
        private readonly TeamRepository _teamRepository;

        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public IEnumerable <Team> Teams { get; set; }

        public AdminPageModel(EventRepository eventRepository, PlayerRepository playerRepository, TeamRepository teamRepository)
        {
            _eventRepository = eventRepository;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }
        public void OnGet()
        {
            Events = (List<Event>)_eventRepository.GetAllEvents();
            Players = (List<Player>)_playerRepository.GetAllPlayers();
            Teams = (List<Team>)_teamRepository.GetAllTeams();

        }
        [BindProperty]
        public string EventName { get; set; }

        [BindProperty]
        public DateTime EventDate { get; set; }

        [BindProperty]
        public string EventLocation { get; set; }
        public IActionResult OnPostDeleteEvent(int eventId)
        {

            _eventRepository.DeleteEvent(eventId);
            return RedirectToPage("/AdminPage");
        }
        public IActionResult OnPostDeleteTeam(int teamId)
        {

            _teamRepository.DeleteTeam(teamId);
            return RedirectToPage("/AdminPage");
        }
        public IActionResult OnPostDeletePlayer(int playerId)
        {

            _playerRepository.DeletePlayer(playerId);
            return RedirectToPage("/AdminPage");
        }
        public IActionResult OnPostAddEvent()
        {
           
                var newEvent = new Event(EventName, EventDate, EventLocation);
                _eventRepository.AddEvent(newEvent);
                return RedirectToPage("/AdminPage");
            
         
        }
       
        [BindProperty]
        public string PlayerName { get; set; }

        [BindProperty]
        public int PlayerAge { get; set; }

        [BindProperty]
        public string PlayerPosition { get; set; }
        [BindProperty]
        public int TeamId { get; set; }

        public IActionResult OnPostAddPlayer()
        {
           
                var newPlayer = new Player
                {
                    Name = PlayerName,
                    Age = PlayerAge,
                    Position = PlayerPosition,
                    TeamId = TeamId
                };

                _playerRepository.AddPlayer(newPlayer);
                return RedirectToPage("/AdminPage");
            
        }

       
        [BindProperty]
        public string TeamName { get; set; }

        [BindProperty]
        public string TeamCoach { get; set; }

        [BindProperty]
        public string TeamCountry { get; set; }

        [BindProperty]
        public int TeamYearFounded { get; set; }
       

        public IActionResult OnPostAddTeam()
        {

                var newTeam = new Team
                {
                    Name = TeamName,
                    Coach = TeamCoach,
                    Country = TeamCountry,
                    YearFounded = TeamYearFounded
                };

                _teamRepository.AddTeam(newTeam);
                return RedirectToPage("/AdminPage");
            

        }

    }
}
