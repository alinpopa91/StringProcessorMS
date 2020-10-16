using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static StringProcessing.BLL.Common.Enumerations;

namespace StringProcessing.BLL.Persistence
{
    public class StringStrategy : IStringStrategy
    {
        private readonly IEnumerable<IStringOperator> _operators;

        public StringStrategy(IEnumerable<IStringOperator> operators)
        {
            _operators = operators;
        }

        public string Calculate(string input, Operator op)
        {
            return _operators.FirstOrDefault(x => x.Operator == op)?.Calculate(input) ?? throw new ArgumentNullException(nameof(op));
        }
    }
}
