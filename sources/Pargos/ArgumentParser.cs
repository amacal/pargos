using System.Collections.Generic;

namespace Pargos
{
    internal static class ArgumentParser
    {
        public static Argument Parse(string[] data)
        {
            List<string> parameters = new List<string>();
            List<string> tail = new List<string>();

            List<string> values = new List<string>();
            Dictionary<string, string[]> options = new Dictionary<string, string[]>();

            string option = null;
            bool separated = false;

            foreach (string item in data)
            {
                if (separated)
                {
                    tail.Add(item);
                }
                else if (option == null && IsParameter(item))
                {
                    parameters.Add(item);
                }
                else if (option != null && IsParameter(item))
                {
                    values.Add(item);
                }
                else if (IsOption(item))
                {
                    string value = item;

                    if (IsShort(value))
                    {
                        for (int i = 1; i < item.Length; i++)
                        {
                            value = $"-{item[i]}";
                            options.Add(value, new string[0]);
                        }
                    }

                    if (option == null)
                    {
                        options[value] = null;
                    }
                    else
                    {
                        options[option] = values.ToArray();
                        options.Add(value, null);
                        values.Clear();
                    }

                    option = value;
                }
                else if (option != null && IsSeparator(item))
                {
                    options[item] = values.ToArray();
                    values.Clear();

                    option = null;
                    separated = true;
                }
                else if (option == null && IsSeparator(item))
                {
                    separated = true;
                }
            }

            if (option != null)
            {
                options[option] = values.ToArray();
                values.Clear();

                option = null;
            }

            return new ArgumentInstance(parameters, options, tail);
        }

        private static bool IsParameter(string value)
        {
            return value.StartsWith("-") == false;
        }

        private static bool IsOption(string value)
        {
            return IsLong(value) || IsShort(value);
        }

        private static bool IsLong(string value)
        {
            return value.Length > 2 && value.StartsWith("--") && value[2] != '-';
        }

        private static bool IsShort(string value)
        {
            return value.Length > 1 && value.StartsWith("-") && value[1] != '-';
        }

        private static bool IsSeparator(string value)
        {
            return value == "--";
        }
    }
}