using Pargos.Core;
using System;
using System.Collections.Generic;

namespace Pargos.Attributes
{
    public abstract class OptionAttribute : Attribute
    {
        public abstract IEnumerable<Argument> Match(ArgumentCollection arguments);
    }
}