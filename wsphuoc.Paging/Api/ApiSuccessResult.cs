using System;
using System.Collections.Generic;
using System.Text;

namespace wsphuoc.Api
{
    public class ApiSuccessResult<T> : ApiResult
    {
        public T ResultObj { get; set; }
        public ApiSuccessResult()
        {
            IsSuccessed = true;
        }
        public ApiSuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }
        public ApiSuccessResult(T resultObj, string message)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
            Message = message;
        }
    }
}
