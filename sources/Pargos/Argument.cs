using System.Collections.Generic;
using System.Linq;

namespace Pargos
{
    public class Argument
    {
        private readonly string[] data;

        public Argument(params string[] data)
        {
            this.data = data;
        }

        public IEnumerable<string> Verbs
        {
            get { return data.TakeWhile(IsVerb); }
        }

        public IEnumerable<string> Short
        {
            get { return data.Where(IsShort).SelectMany(ToShort); }
        }

        public IEnumerable<string> Long
        {
            get { return data.Where(IsLong).Select(ToLong); }
        }

        public IEnumerable<string> Tail
        {
            get { return data.SkipWhile(IsNotTailSeparator).Skip(1); }
        }

        public IEnumerable<string> this[string name]
        {
            get
            {
                bool inside = false;

                foreach (string value in data)
                {
                    if (IsVerb(value) == false)
                    {
                        inside = false;
                    }

                    if (inside)
                    {
                        yield return value;
                    }

                    if (IsLong(value) && ToLong(value) == name)
                    {
                        inside = true;
                    }

                    if (IsShort(value) && ToShort(value).LastOrDefault() == name)
                    {
                        inside = true;
                    }
                }
            }
        }

        private static bool IsVerb(string value)
        {
            return value.StartsWith("-") == false;
        }

        private static bool IsShort(string value)
        {
            return value.StartsWith("-") && value.StartsWith("--") == false;
        }

        private static bool IsLong(string value)
        {
            return value.StartsWith("--") && value.Length > 2;
        }

        private static bool IsNotTailSeparator(string value)
        {
            return value != "--";
        }

        private static IEnumerable<string> ToShort(string value)
        {
            return value.Skip(1).Select(ToShort);
        }

        private static string ToShort(char value)
        {
            return value.ToString();
        }

        private static string ToLong(string value)
        {
            return value.Substring(2);
        }
    }
}