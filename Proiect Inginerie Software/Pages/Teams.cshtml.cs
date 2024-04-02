using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Proiect_Inginerie_Software.Models;
using Proiect_Inginerie_Software.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Proiect_Inginerie_Software.Pages
{
    public class TeamsModel : PageModel
    {
        private readonly ILogger<TeamsModel> _logger;
        private readonly TeamRepository _teamRepository;

        public Dictionary<string, List<Team>> TeamsByCountry { get; set; }

        public TeamsModel(ILogger<TeamsModel> logger, TeamRepository teamRepository)
        {
            _logger = logger;
            _teamRepository = teamRepository;
        }

        public void OnGet()
        {
            var allTeams = _teamRepository.GetAllTeams();
            TeamsByCountry = allTeams.GroupBy(t => t.Country).ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
