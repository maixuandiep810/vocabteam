using System.Collections.Generic;

namespace vocabteam.Helpers
{
    public static class ConstantVar
    {
        public enum ResponseCode 
        {
            SUCCESS = 1,
            FAIL = 99,
        }
        public static string ResponseString(ResponseCode code) {
            switch (code)
            {
                case ResponseCode.SUCCESS:
                    return "susscess";
                case ResponseCode.FAIL:
                    return "fail";
                default:
                    return "";
            }
        }
    }
}