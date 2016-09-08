using Pargos.Core;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pargos.Attributes.Handlers
{
    public class StringArrayHandler : OptionHandler
    {
        public override void Apply(IEnumerable<Argument> arguments, PropertyInfo property, object instance, OptionConverter converter)
        {
            if (arguments.Any())
            {
                property.SetValue(instance, arguments.Select(x => x.Value).ToArray());
            }
        }
    }
}