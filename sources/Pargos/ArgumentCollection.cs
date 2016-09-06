using System.Collections.Generic;

namespace Pargos.Core
{
    public class ArgumentCollection
    {
        private readonly string[] args;

        internal ArgumentCollection(string[] args)
        {
            this.args = args;
        }

        public bool Any()
        {
            foreach (ArgumentToken token in ArgumentReader.Open(args))
            {
                switch (token.Type)
                {
                    case ArgumentTokenType.Value:
                    case ArgumentTokenType.Long:
                    case ArgumentTokenType.Short:

                        return true;
                }
            }

            return false;
        }

        public int Count()
        {
            int count = 0;
            bool ignore = false;

            foreach (ArgumentToken token in ArgumentReader.Open(args))
            {
                switch (token.Type)
                {
                    case ArgumentTokenType.Value:

                        if (ignore == false) count++;
                        break;

                    case ArgumentTokenType.Long:
                    case ArgumentTokenType.Short:

                        ignore = true;
                        break;
                }
            }

            return count;
        }

        public int Count(string name)
        {
            int count = 0;
            bool found = false;

            foreach (ArgumentToken token in ArgumentReader.Open(args))
            {
                if (token.Type == ArgumentTokenType.Value && found)
                {
                    count++;
                    continue;
                }

                switch (token.Type)
                {
                    case ArgumentTokenType.Long:
                    case ArgumentTokenType.Short:

                        found = token.Value == name;
                        break;

                    default:
                        found = false;
                        break;
                }
            }

            return count;
        }

        public string[] Names()
        {
            List<string> names = new List<string>();

            foreach (ArgumentToken token in ArgumentReader.Open(args))
            {
                switch (token.Type)
                {
                    case ArgumentTokenType.Long:
                    case ArgumentTokenType.Short:

                        names.Add(token.Value);
                        break;
                }
            }

            return names.ToArray();
        }

        public Argument Value(int index)
        {
            List<Argument> values = new List<Argument>();

            foreach (ArgumentToken token in ArgumentReader.Open(args))
            {
                if (token.Type == ArgumentTokenType.Value)
                {
                    values.Add(new Argument { Value = token.Value });
                }
            }

            if (index >= values.Count)
            {
                return null;
            }

            if (index < -values.Count)
            {
                return null;
            }

            if (index >= 0)
            {
                return values[index];
            }

            return values[values.Count + index];
        }

        public Argument Value(string name)
        {
            bool found = false;

            foreach (ArgumentToken token in ArgumentReader.Open(args))
            {
                if (token.Type == ArgumentTokenType.Value && found)
                {
                    return new Argument { Value = token.Value };
                }

                if (found)
                {
                    return new Argument { };
                }

                switch (token.Type)
                {
                    case ArgumentTokenType.Long:
                    case ArgumentTokenType.Short:

                        found = token.Value == name;
                        break;

                    default:
                        found = false;
                        break;
                }
            }

            if (found)
            {
                return new Argument { };
            }

            return null;
        }

        public Argument Value(string name, int index)
        {
            bool found = false;
            List<Argument> values = new List<Argument>();

            foreach (ArgumentToken token in ArgumentReader.Open(args))
            {
                if (token.Type == ArgumentTokenType.Value && found)
                {
                    values.Add(new Argument { Value = token.Value });
                    continue;
                }

                switch (token.Type)
                {
                    case ArgumentTokenType.Long:
                    case ArgumentTokenType.Short:

                        found = token.Value == name;
                        break;

                    default:
                        found = false;
                        break;
                }
            }

            if (index >= values.Count)
            {
                return null;
            }

            if (index < -values.Count)
            {
                return null;
            }

            if (index >= 0)
            {
                return values[index];
            }

            return values[values.Count + index];
        }

        public ArgumentCollection Scope(string prefix)
        {
            bool found = false;
            int length = prefix.Length;
            List<string> data = new List<string>();

            foreach (ArgumentToken token in ArgumentReader.Open(args))
            {
                if (token.Type == ArgumentTokenType.Value && found)
                {
                    data.Add(token.Value);
                    continue;
                }

                switch (token.Type)
                {
                    case ArgumentTokenType.Long:

                        if (token.Value == prefix)
                        {
                            found = true;
                        }
                        else if (token.Value.StartsWith(prefix + "-"))
                        {
                            found = true;
                            data.Add("-" + token.Value.Substring(length));
                        }
                        else
                        {
                            found = false;
                        }

                        break;

                    default:
                        found = false;
                        break;
                }
            }

            return new ArgumentCollection(data.ToArray());
        }
    }
}