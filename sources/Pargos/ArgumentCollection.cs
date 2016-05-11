using System;
using System.Collections.Generic;

namespace Pargos
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
            return false;
        }

        public int Count()
        {
            return 0;
        }

        public bool Has(int index)
        {
            return false;
        }

        public bool Has(string name)
        {
            return false;
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

        public string GetString(string name)
        {
            return null;
        }

        public string GetString(string name, int index)
        {
            return null;
        }

        public int GetInt32(int index)
        {
            return 0;
        }

        public int GetInt32(int index, IFormatProvider provider)
        {
            return 0;
        }

        public int GetInt32(string name)
        {
            return 0;
        }
    }
}