using System.Collections.Generic;

namespace Pargos.Core
{
    internal static class ArgumentReader
    {
        public static IEnumerable<ArgumentToken> Open(string[] args)
        {
            int index = 0, offset = 0;
            ArgumentTokenType type;

            foreach (string value in args)
            {
                if (value.StartsWith("--"))
                {
                    type = ArgumentTokenType.Long;
                    offset = 2;
                }
                else if (value.StartsWith("-"))
                {
                    foreach (char option in value.Substring(1))
                    {
                        yield return new ArgumentToken
                        {
                            Index = index++,
                            Type = ArgumentTokenType.Short,
                            Value = option.ToString()
                        };
                    }

                    continue;
                }
                else
                {
                    type = ArgumentTokenType.Value;
                    offset = 0;
                }

                yield return new ArgumentToken
                {
                    Index = index++,
                    Type = type,
                    Value = value.Substring(offset)
                };
            }
        }
    }
}