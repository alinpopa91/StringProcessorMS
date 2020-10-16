using StringProcessing.BLL.Operators;
using StringProcessing.BLL.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessing.BLL.Factories
{
    public class StringStrategyFactory : IStringStrategyFactory
    {
        private readonly InvertOperator _invertOperator;
        private readonly LowercaseOperator _lowercaseOperator;
        private readonly UppercaseOperator _upperOperator;
        private readonly SortOperator _sortOperator;
        private readonly RemoveSpaceOperator _removeSpacesOperator;

        public StringStrategyFactory(InvertOperator invertOperator, LowercaseOperator lowercaseOperator, SortOperator sortOperator,
            UppercaseOperator uppercaseOperator, RemoveSpaceOperator removeSpacesOperator)
        {
            _invertOperator = invertOperator;
            _lowercaseOperator = lowercaseOperator;
            _sortOperator = sortOperator;
            _upperOperator = uppercaseOperator;
            _removeSpacesOperator = removeSpacesOperator;
        }

        public IStringOperator[] Create() => new IStringOperator[] { _invertOperator, _lowercaseOperator, _sortOperator, _upperOperator, _removeSpacesOperator };
    }
}
