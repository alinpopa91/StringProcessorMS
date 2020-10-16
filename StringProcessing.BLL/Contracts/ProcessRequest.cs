using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessing.BLL.Contracts
{
    public class ProcessRequest
    {
        public string PathToInput { get; set; }
        public string PathToOutput { get; set; }
        public List<string> Operations { get; set; }
    }
}
