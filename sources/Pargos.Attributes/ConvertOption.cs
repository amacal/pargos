using Pargos.Core;
using System;
using System.Collections.Generic;

namespace Pargos.Attributes
{
    public abstract class ConvertOption : Attribute, OptionConverter
    {
        public abstract object Convert(IEnumerable<Argument> arguments);
    }
}