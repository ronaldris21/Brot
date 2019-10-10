namespace DLL.ResponseModels
{
    using System;
    public class ResponseModel
    {
        public bool isSuccess { get; set; }
        public String Message { get; set; }
        public Object Result { get; set; }
    }
}
