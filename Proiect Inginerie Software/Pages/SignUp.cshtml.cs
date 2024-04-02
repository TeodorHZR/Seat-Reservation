using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Inginerie_Software.Models;
using Proiect_Inginerie_Software.Repositories;

namespace Proiect_Inginerie_Software.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly UserRepository _userRepository;
        public SignUpModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void OnGet()
        {
            
        }
        [BindProperty]
        public string UUsername { get; set; }
        [BindProperty]
        public string UPassword { get; set; }
        [BindProperty]
        public string UEmail { get; set; }
        public IActionResult OnPostAddUser()
        {

            var newUser = new User
            {
              Username = UUsername,
              Password = UPassword,
              Email = UEmail


            };

            _userRepository.AddUser(newUser);
            return RedirectToPage("/Index");


        }
    }
}
