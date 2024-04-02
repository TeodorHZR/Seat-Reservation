namespace Proiect_Inginerie_Software.Models
{
    public class User
    {
        public int IdUtilizator { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int isAdmin { get; set; }
    }

}
