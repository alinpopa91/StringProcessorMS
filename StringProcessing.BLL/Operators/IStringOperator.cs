using System;
using System.Collections.Generic;
using System.Text;
using static StringProcessing.BLL.Common.Enumerations;

namespace StringProcessing.BLL.Persistence
{
    public interface IStringOperator
    {
        Operator Operator { get; }

        string Calculate(string input);
    }
}
