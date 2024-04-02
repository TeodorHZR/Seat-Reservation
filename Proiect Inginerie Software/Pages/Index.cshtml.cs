using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Proiect_Inginerie_Software.Repositories;
using System.Data.SqlClient;

namespace Proiect_Inginerie_Software.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserRepository _userRepository;

        public IndexModel(ILogger<IndexModel> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnPostLogin()
        {

            try
            {
                if (_userRepository.Authenticate(Username, Password))
                {
                    if (_userRepository.IsAdmin(Username))
                    {
                        return RedirectToPage("/AdminPage");
                    }
                    else
                    {
                        return RedirectToPage("/Error");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Date incorecte.";
                    return RedirectToPage("/Index");
                }
            }
            catch (SqlException ex)
            {
               
                TempData["ErrorMessage"] = "A aparut o eroare! Va rugam incercati mai tarziu!";
                return RedirectToPage("/Index");
            }
        }

    }
}
