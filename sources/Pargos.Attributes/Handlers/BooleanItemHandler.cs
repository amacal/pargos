using Pargos.Core;
using System.Collections.Generic;
using System.Reflection;

namespace Pargos.Attributes.Handlers
{
    public class BooleanItemHandler : OptionHandler
    {
        public override void Apply(IEnumerable<Argument> arguments, PropertyInfo property, object instance, OptionConverter converter)
        {
            property.SetValue(instance, converter.Convert(arguments));
        }
    }
}