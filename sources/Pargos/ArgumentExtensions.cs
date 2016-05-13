using System;

namespace Pargos
{
    public static class ArgumentExtensions
    {
        public static bool Has(this ArgumentCollection collection, int index)
        {
            return collection.Value(index).SelectOrDefault(x => true);
        }

        public static bool Has(this ArgumentCollection collection, string name)
        {
            return collection.Value(name).SelectOrDefault(x => x != null);
        }

        public static bool Has(this ArgumentCollection collection, string name, int index)
        {
            return collection.Value(name, index).SelectOrDefault(x => x.Value != null);
        }

        public static string GetString(this ArgumentCollection collection, int index)
        {
            return collection.Value(index).SelectOrDefault(x => x.Value);
        }

        public static string GetString(this ArgumentCollection collection, string name)
        {
            return collection.Value(name).SelectOrDefault(x => x.Value);
        }

        public static string GetString(this ArgumentCollection collection, string name, int index)
        {
            return collection.Value(name, index).SelectOrDefault(x => x.Value);
        }

        private static T SelectOrDefault<T>(this Argument argument, Func<Argument, T> selector)
        {
            return argument != null ? selector.Invoke(argument) : default(T);
        }
    }
}