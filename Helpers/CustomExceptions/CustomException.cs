using System;
using static vocabteam.Helpers.ConstantVar;

namespace vocabteam.Helpers.CustomExceptions
{
    public class CustomException : Exception
    {
        public ResponseCode Response_Code { get; set;}

        public CustomException()
        {
        }

        public CustomException(ResponseCode code) 
        {
            Response_Code = code;
        }

        public CustomException(string message)
            : base(message)
        {
        }

        public CustomException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}