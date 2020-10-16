using StringProcessing.BLL.Common;
using StringProcessing.BLL.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessing.BLL.Operators
{
    public class UppercaseOperator : IStringOperator
    {
        public Enumerations.Operator Operator => Enumerations.Operator.Uppercase;

        public string Calculate(string input)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : input.ToUpperInvariant();
        }
    }
}
