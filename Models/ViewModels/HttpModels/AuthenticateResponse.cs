using vocabteam.Models.Entities;

namespace vocabteam.Models.ViewModels
{
    public class AuthenticateResponse : UserInfoResponse
    {
        public AuthenticateResponse(UserModel user, BaseResponse baseRes) : base(user, baseRes)
        {
        }
    }
}