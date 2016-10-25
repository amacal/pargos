using System.Collections.Generic;

namespace Pargos
{
    public abstract class Argument
    {
        public abstract IEnumerable<string> Verbs { get; }

        public abstract IEnumerable<string> Short { get; }

        public abstract IEnumerable<string> Long { get; }

        public abstract IEnumerable<string> Tail { get; }

        public abstract IEnumerable<string> this[string name] { get; }

        public static Argument Parse(params string[] args)
        {
            return new ArgumentInstance(args);
        }
    }
}