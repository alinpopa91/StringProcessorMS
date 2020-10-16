using StringProcessing.BLL.Common;
using StringProcessing.BLL.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessing.BLL.Operators
{
    public class RemoveSpaceOperator : IStringOperator
    {
        public Enumerations.Operator Operator => Enumerations.Operator.RemoveSpaces;

        public string Calculate(string input)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : input.Replace(" ", string.Empty).Trim();
        }
    }
}
