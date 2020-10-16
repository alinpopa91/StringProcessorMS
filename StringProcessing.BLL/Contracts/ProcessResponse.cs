using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessing.BLL.Contracts
{
    public class ProcessResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorType { get; set; }

        public ProcessResponse()
        {
            Success = true;
            Message = string.Empty;
            ErrorType = string.Empty;
        }
    }
}
