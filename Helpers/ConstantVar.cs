using System.Collections.Generic;

namespace vocabteam.Helpers
{
    public static class ConstantVar
    {


        ///
        ///     RESPONSE
        ///
        public enum ResponseCode
        {
            SUCCESS = 1,

            HAVE_LOGGED = 20,
            HAVE_LOGGED_DONT_NEED_TO_REGISTER = 21,
            EXISTED_USERNAME = 22,

            FAIL = 90,
        }
        public static string ResponseString(ResponseCode code)
        {
            switch (code)
            {
                case ResponseCode.SUCCESS:
                    return "susscess";

                case ResponseCode.HAVE_LOGGED:
                    return "you have logged in system";
                case ResponseCode.HAVE_LOGGED_DONT_NEED_TO_REGISTER:
                    return "you have logged in system, you don't need to register.";
                case ResponseCode.EXISTED_USERNAME:
                    return "username already exists";

                case ResponseCode.FAIL:
                    return "fail";
                default:
                    return "";
            }
        }


        ///
        ///     ROLE
        ///
        public enum Role
        {
            admin = 1,
            guest = 3
        }

    }
}