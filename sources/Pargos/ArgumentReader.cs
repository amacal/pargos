using System.Collections.Generic;

namespace Pargos
{
    internal static class ArgumentReader
    {
        public static IEnumerable<ArgumentToken> Open(string[] args)
        {
            int index = 0;

            foreach (string value in args)
            {
                yield return new ArgumentToken
                {
                    Index = index++,
                    Type = ArgumentTokenType.Value,
                    Value = value
                };
            }
        }
    }
}