using System;
using System.Collections.Generic;
using System.Text;
using wsphuoc.Exceptions;

namespace wsphuoc.Api
{
    public class ApiTokenResult:ApiResult
    {
        public string Token { get; set; }
        public ApiTokenResult()
        {
            throw new wsphuocException("Error token");
        }
        public ApiTokenResult(string token)
        {
            IsSuccessed = true;
            Token = token;
        }
        public ApiTokenResult(string token, string message)
        {
            IsSuccessed = true;
            Token = token;
            Message = message;
        }
    }
}
