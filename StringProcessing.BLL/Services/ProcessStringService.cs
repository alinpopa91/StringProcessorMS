using StringProcessing.BLL.Persistence;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using StringProcessing.BLL.Common;

namespace StringProcessing.BLL.Services
{
    public class ProcessStringService : IProcessStringService
    {
        private readonly IStringStrategy _stringStrategy;

        public ProcessStringService(IStringStrategy stringStrategy)
        {
            _stringStrategy = stringStrategy;
        }

        public string Process(string inputVal, Enumerations.Operator op)
        {
            var aux = _stringStrategy.Calculate(inputVal, op).ToString();

            return aux;
        }
    }
}
