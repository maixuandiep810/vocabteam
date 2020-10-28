using Newtonsoft.Json;

namespace vocabteam.Models.ViewModels
{
    public class RegisterResponse : UserInfoResponse
    {
        public RegisterResponse(UserModel user, BaseResponse baseRes) : base(user, baseRes)
        {
        }
    }
}