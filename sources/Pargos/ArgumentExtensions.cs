using System;

namespace Pargos
{
    public static class ArgumentExtensions
    {
        public static string GetString(this ArgumentCollection collection, int index)
        {
            return collection.Value(index).SelectOrDefault(x => x.Value);
        }

        private static T SelectOrDefault<T>(this Argument argument, Func<Argument, T> selector)
        {
            return argument != null ? selector.Invoke(argument) : default(T);
        }
    }
}