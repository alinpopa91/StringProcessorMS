using System;
using System.Collections.Generic;
using System.Text;
using static StringProcessing.BLL.Common.Enumerations;

namespace StringProcessing.BLL.Persistence
{
    public interface IStringStrategy
    {
        string Calculate(string input, Operator op);
    }
}
