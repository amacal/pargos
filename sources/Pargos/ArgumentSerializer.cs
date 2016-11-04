using System;
using System.Collections.Generic;
using System.Reflection;

namespace Pargos
{
    internal static class ArgumentSerializer
    {
        public static TOptions Deserialize<TOptions>(params string[] data)
            where TOptions : class, new()
        {
            Argument argument = ArgumentParser.Parse(data);
            TOptions options = new TOptions();

            foreach (ArgumentRoutine routine in FindRoutines(typeof(TOptions)))
            {
                routine.Apply(argument, options);
            };

            return options;
        }

        private static IEnumerable<ArgumentRoutine> FindRoutines(Type target)
        {
            foreach (PropertyInfo property in target.GetProperties())
            {
                ArgumentRoutine routine = new ArgumentRoutine(property);

                if (property.IsDefined(typeof(ParameterAttribute)))
                {
                    property.GetCustomAttribute<ParameterAttribute>().Apply(routine);
                }

                if (property.IsDefined(typeof(AtAttribute)))
                {
                    property.GetCustomAttribute<AtAttribute>().Apply(routine);
                }

                if (property.IsDefined(typeof(AfterAttribute)))
                {
                    property.GetCustomAttribute<AfterAttribute>().Apply(routine);
                }

                if (property.IsDefined(typeof(MatchAttribute)))
                {
                    property.GetCustomAttribute<MatchAttribute>().Apply(routine);
                }

                if (property.IsDefined(typeof(PresenceAttribute)))
                {
                    property.GetCustomAttribute<PresenceAttribute>().Apply(routine);
                }

                if (property.IsDefined(typeof(OptionAttribute)))
                {
                    routine.WithFilter(argument =>
                    {
                        bool exists = false;

                        List<string> values = new List<string>();
                        var options = property.GetCustomAttributes<OptionAttribute>();

                        foreach (OptionAttribute option in options)
                        {
                            string[] data = option.Filter(argument);

                            if (data != null)
                            {
                                values.AddRange(data);
                                exists = true;
                            }
                        }

                        if (exists == false)
                        {
                            return null;
                        }

                        return new ArgumentIndexableList(values);
                    });
                }

                if (property.PropertyType.Assembly == target.Assembly)
                {
                    routine.WithDrillDown(FindRoutines);
                }

                if (property.PropertyType.IsArray)
                {
                    routine.WithConverter(value => new[] { value[0] });
                }

                if (property.PropertyType == typeof(string))
                {
                    routine.WithConverter(value => value?[0]);
                }

                if (property.PropertyType == typeof(int?))
                {
                    routine.WithConverter(value => value == null ? default(int?) : Int32.Parse(value[0]));
                }

                yield return routine;
            }
        }
    }
}