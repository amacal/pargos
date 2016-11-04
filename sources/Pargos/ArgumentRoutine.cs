using System;
using System.Collections.Generic;
using System.Reflection;

namespace Pargos
{
    internal class ArgumentRoutine
    {
        private readonly PropertyInfo property;

        private Func<ArgumentIndexable, bool> match;
        private Func<Argument, ArgumentIndexable> filter;
        private Func<ArgumentIndexable, ArgumentIndexable> selector;
        private Func<Argument, ArgumentIndexable, object> drillDown;

        public ArgumentRoutine(PropertyInfo property)
        {
            this.property = property;
            match = value => true;

            filter = argument => new ArgumentToIndexableProperties(argument);
            selector = indexable => indexable;
            drillDown = (argument, value) => value;
        }

        public void WithParameter()
        {
        }

        public void WithFilter(Func<Argument, ArgumentIndexable> filterToUse)
        {
            filter = filterToUse;
        }

        public void WithSelector(Func<ArgumentIndexable, ArgumentIndexable> selectorToUse)
        {
            selector = selectorToUse;
        }

        public void WithMatch(Func<ArgumentIndexable, bool> matchToUse)
        {
            match = matchToUse;
        }

        public void WithDrillDown(Func<Type, IEnumerable<ArgumentRoutine>> find)
        {
            drillDown = (argument, value) =>
            {
                Type type = property.PropertyType;
                object instance = Activator.CreateInstance(type);

                foreach (ArgumentRoutine routine in find.Invoke(type))
                {
                    routine.Apply(argument, instance);
                }

                return instance;
            };
        }

        public void WithConverter(Func<ArgumentIndexable, object> converter)
        {
            drillDown = (argument, value) => converter.Invoke(value);
        }

        public void Apply(Argument argument, object target)
        {
            ArgumentIndexable indexable = filter.Invoke(argument);
            ArgumentIndexable selected = selector.Invoke(indexable);
            bool matches = match.Invoke(selected);

            if (matches)
            {
                property.SetValue(target, drillDown.Invoke(argument, selected));
            }
        }

        private class ArgumentToIndexableProperties : ArgumentIndexable
        {
            private readonly Argument argument;

            public ArgumentToIndexableProperties(Argument argument)
            {
                this.argument = argument;
            }

            public string this[int index]
            {
                get { return argument[index]; }
            }
        }
    }
}