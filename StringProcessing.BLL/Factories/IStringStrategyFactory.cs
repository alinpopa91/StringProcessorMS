using StringProcessing.BLL.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessing.BLL.Factories
{
    public interface IStringStrategyFactory
    {
        IStringOperator[] Create();
    }
}
