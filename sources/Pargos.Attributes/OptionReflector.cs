using Pargos.Attributes.Converters;
using Pargos.Attributes.Handlers;
using System.Collections.Generic;
using System.Reflection;

namespace Pargos.Attributes
{
    public static class OptionReflector
    {
        private static class Handlers
        {
            public static readonly OptionHandler BooleanItem;

            public static readonly OptionHandler StringItem;
            public static readonly OptionHandler StringArray;

            static Handlers()
            {
                BooleanItem = new BooleanItemHandler();
                StringItem = new StringItemHandler();
                StringArray = new StringArrayHandler();
            }
        }

        private static class Converters
        {
            public static readonly OptionConverter BooleanItem;

            static Converters()
            {
                BooleanItem = new DefaultBooleanConverter();
            }
        }

        public static IEnumerable<OptionInstance> All(object instance)
        {
            foreach (PropertyInfo property in instance.GetType().GetProperties())
            {
                foreach (OptionAttribute attribute in property.GetCustomAttributes<OptionAttribute>(true))
                {
                    yield return new OptionInstance
                    {
                        Attribute = attribute,
                        Property = property,
                        Handler = FindHandler(property),
                        Converter = FindConverter(property)
                    };

                    break;
                }
            }
        }

        private static OptionHandler FindHandler(PropertyInfo property)
        {
            if (property.PropertyType == typeof(bool))
                return Handlers.BooleanItem;

            if (property.PropertyType == typeof(string))
                return Handlers.StringItem;

            if (property.PropertyType == typeof(string[]))
                return Handlers.StringArray;

            return null;
        }

        private static OptionConverter FindConverter(PropertyInfo property)
        {
            foreach (ConvertOption attribute in property.GetCustomAttributes<ConvertOption>(true))
            {
                return attribute;
            }

            if (property.PropertyType == typeof(bool))
                return Converters.BooleanItem;

            return null;
        }
    }
}