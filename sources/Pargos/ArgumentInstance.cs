using System.Collections.Generic;

namespace Pargos
{
    internal sealed class ArgumentInstance : Argument
    {
        private readonly List<string> parameters;
        private readonly Dictionary<string, string[]> options;
        private readonly List<string> tail;

        public ArgumentInstance(List<string> parameters, Dictionary<string, string[]> options, List<string> tail)
        {
            this.parameters = parameters;
            this.options = options;
            this.tail = tail;
        }

        public override int Parameters
        {
            get { return parameters.Count; }
        }

        public override int Tail
        {
            get { return tail.Count; }
        }

        public override int Options
        {
            get { return options.Count; }
        }

        public override string this[int index]
        {
            get
            {
                if (index >= 0 && index < parameters.Count)
                    return parameters[index];

                if (index < 0 && -index <= tail.Count)
                    return tail[-index - 1];

                return null;
            }
        }

        public override string[] this[string index]
        {
            get
            {
                string[] found;

                if (options.TryGetValue(index, out found))
                    return found;

                return null;
            }
        }
    }
}