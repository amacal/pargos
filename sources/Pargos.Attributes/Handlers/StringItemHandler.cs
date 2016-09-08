using Pargos.Core;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pargos.Attributes.Handlers
{
    public class StringItemHandler : OptionHandler
    {
        public override void Apply(IEnumerable<Argument> arguments, PropertyInfo property, object instance, OptionConverter converter)
        {
            property.SetValue(instance, arguments.FirstOrDefault()?.Value);
        }
    }
}