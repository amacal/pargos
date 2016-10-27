using System.Linq;

namespace Pargos
{
    public class ArgumentView
    {
        private readonly Argument argument;

        public ArgumentView(Argument argument)
        {
            this.argument = argument;
        }

        public bool HasVerbs()
        {
            return argument.Verbs.Any();
        }

        public bool HasVerbs(int index)
        {
            return argument.Verbs.ElementAtOrDefault(index) != null;
        }

        public bool HasOptions()
        {
            return argument.Long.Any() || argument.Short.Any();
        }

        public bool HasOptions(string name)
        {
            return argument.Long.Contains(name) || argument.Short.Contains(name);
        }

        public bool HasOptions(string name, int index)
        {
            return argument[name].ElementAtOrDefault(index) != null;
        }

        public bool HasTail()
        {
            return false;
        }

        public bool HasTail(int index)
        {
            return false;
        }

        public int CountVerbs()
        {
            return argument.Verbs.Count();
        }

        public int CountOptions()
        {
            return argument.Short.Count() + argument.Long.Count();
        }

        public int CountOptions(string name)
        {
            return argument[name].Count();
        }

        public int CountTail()
        {
            return 0;
        }

        public string GetVerb()
        {
            return argument.Verbs.FirstOrDefault();
        }

        public string GetVerb(int index)
        {
            return argument.Verbs.ElementAtOrDefault(index);
        }

        public string GetOption(string name)
        {
            return argument[name].FirstOrDefault();
        }

        public string GetOption(string name, int index)
        {
            return argument[name].ElementAtOrDefault(index);
        }

        public string GetTail(int index)
        {
            return null;
        }
    }
}