using Pargos.Core;
using System.Collections.Generic;
using System.Reflection;

namespace Pargos.Attributes
{
    public abstract class OptionHandler
    {
        public abstract void Apply(IEnumerable<Argument> arguments, PropertyInfo property, object instance, OptionConverter converter);
    }
}