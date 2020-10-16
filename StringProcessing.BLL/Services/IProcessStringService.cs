using StringProcessing.BLL.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessing.BLL.Services
{
    public interface IProcessStringService
    {
        string Process(string inputVal, Enumerations.Operator op);
    }
}
