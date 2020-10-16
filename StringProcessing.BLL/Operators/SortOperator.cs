using StringProcessing.BLL.Common;
using StringProcessing.BLL.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringProcessing.BLL.Operators
{
    public class SortOperator : IStringOperator
    {
        public Enumerations.Operator Operator => Enumerations.Operator.Sort;

        public string Calculate(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);


        }
    }
}
