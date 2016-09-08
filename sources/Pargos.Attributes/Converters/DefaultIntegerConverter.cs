using Pargos.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pargos.Attributes.Converters
{
    public class DefaultIntegerConverter : OptionConverter
    {
        public object Convert(IEnumerable<Argument> arguments)
        {
            if (arguments.Any() == false)
                return null;

            if (arguments.Any(x => x.Value != null) == false)
                return null;

            return arguments.Select(x => Int32.Parse(x.Value)).Single();
        }
    }
}