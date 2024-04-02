using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Inginerie_Software.Models;
using Proiect_Inginerie_Software.Repositories;

namespace Proiect_Inginerie_Software.Pages
{
    public class PlayersModel : PageModel
    {
        private readonly PlayerRepository _playerRepository;

        public List<Player> Players { get; set; }

        public PlayersModel(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void OnGet(int teamId)
        {
            Players = _playerRepository.GetPlayersByTeamId(teamId);
        }
    }
}
