using Pargos.Core;
using System.Collections.Generic;
using System.Linq;

namespace Pargos.Attributes.Converters
{
    public class DefaultBooleanConverter : OptionConverter
    {
        public object Convert(IEnumerable<Argument> arguments)
        {
            return arguments.Any();
        }
    }
}