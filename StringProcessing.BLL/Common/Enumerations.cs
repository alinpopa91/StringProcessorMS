using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StringProcessing.BLL.Common
{
    public static class Enumerations
    {
        public enum Operator
        {
            [Description("lowercase")]
            Lowercase,
            [Description("uppercase")]
            Uppercase,
            [Description("sort")]
            Sort,
            [Description("invert")]
            Invert,
            [Description("removespaces")]
            RemoveSpaces
        }
    }
}
