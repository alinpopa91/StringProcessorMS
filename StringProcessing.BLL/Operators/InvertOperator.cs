using System;
using System.Collections.Generic;
using System.Text;
using StringProcessing.BLL.Common;
using StringProcessing.BLL.Persistence;

namespace StringProcessing.BLL.Operators
{
    public class InvertOperator : IStringOperator
    {
        public Enumerations.Operator Operator => Enumerations.Operator.Invert;

        public string Calculate(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
