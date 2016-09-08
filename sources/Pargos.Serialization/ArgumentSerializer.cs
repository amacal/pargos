using Pargos.Attributes;
using Pargos.Core;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Pargos.Serialization
{
    public class ArgumentSerializer
    {
        public void Apply(ArgumentCollection arguments, object instance)
        {
            ApplyVerb(arguments, instance);
            ApplyOptions(arguments, instance);
        }

        private void ApplyVerb(ArgumentCollection arguments, object instance)
        {
            string verb = arguments.GetString(0);
            PropertyInfo property = VerbReflector.GetByName(instance, verb);

            if (property != null)
            {
                object value = Activator.CreateInstance(property.PropertyType);

                property.SetValue(instance, value);
                ApplyOptions(arguments, value);
            }
        }

        private void ApplyOptions(ArgumentCollection arguments, object instance)
        {
            foreach (OptionInstance item in OptionReflector.All(instance))
            {
                OptionHandler handler = item.Handler;
                OptionConverter converter = item.Converter;

                IEnumerable<Argument> matched = item.Attribute.Match(arguments);
                handler?.Apply(matched, item.Property, instance, converter);
            }
        }
    }
}