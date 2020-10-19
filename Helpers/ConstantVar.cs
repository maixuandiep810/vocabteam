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
            PATH_DOESNOT_EXIST = 23,
            PERMISSION_DENIED = 24,
            TOKEN_VALIDATION_ERROR = 25,
            REQUEST_DOESNOT_EXIST = 26,
            HAVE_LOGGED_OUT = 27,
            USERNAME_PASSWORD_INCORRECT = 28,

            VOCABULARY_EXSITED = 40,
            CREATE_VOCABULARY_SUCCESSFULLY = 41,

            FAIL = 50,
            SYSTEM_ERROR = 51,
            REPOSITORY_ERROR = 52
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
                case ResponseCode.PATH_DOESNOT_EXIST:
                    return "the specified path does not exist";
                case ResponseCode.PERMISSION_DENIED:
                    return "you does not have permission to perform this action";
                case ResponseCode.TOKEN_VALIDATION_ERROR:
                    return "access token could not be verified";
                case ResponseCode.REQUEST_DOESNOT_EXIST:
                    return "request does not exist";
                case ResponseCode.HAVE_LOGGED_OUT:
                    return "you have logged out";
                case ResponseCode.USERNAME_PASSWORD_INCORRECT:
                return "username or password is incorrect";

                case ResponseCode.VOCABULARY_EXSITED:
                return "vocabulary exsited";
                case ResponseCode.CREATE_VOCABULARY_SUCCESSFULLY:
                return "vocabulary have been successfully created ";

                case ResponseCode.FAIL:
                    return "fail";
                case ResponseCode.REPOSITORY_ERROR:
                case ResponseCode.SYSTEM_ERROR:
                    return "system error";

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
        
        public static string RoleString(Role role)
        {
            switch (role)
            {
                case Role.guest:
                    return "guest";
                default:
                    return "guest";
            }
        }

    }
}