using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class AuthenticateResponse
    {
        public bool isActive { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Username = user.Username;
            isActive = user.Active;
            Token = token;
        }
    }
}