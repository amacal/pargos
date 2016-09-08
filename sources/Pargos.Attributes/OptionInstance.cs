using System.Reflection;

namespace Pargos.Attributes
{
    public class OptionInstance
    {
        public OptionAttribute Attribute { get; set; }

        public OptionConverter Converter { get; set; }

        public OptionHandler Handler { get; set; }

        public PropertyInfo Property { get; set; }
    }
}