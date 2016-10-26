using System.Linq;

namespace Pargos
{
    public static class ArgumentExtensions
    {
        public static bool HasVerbs(this Argument argument)
        {
            return argument.Verbs.Any();
        }

        public static bool HasVerbs(this Argument argument, int index)
        {
            return argument.Verbs.ElementAtOrDefault(index) != null;
        }

        public static bool HasOptions(this Argument argument)
        {
            return argument.Long.Any() || argument.Short.Any();
        }

        public static bool HasOptions(this Argument argument, string name)
        {
            return argument.Long.Contains(name) || argument.Short.Contains(name);
        }

        public static bool HasOptions(this Argument argument, string name, int index)
        {
            return argument[name].ElementAtOrDefault(index) != null;
        }

        public static bool HasTail(this Argument argument)
        {
            return false;
        }

        public static bool HasTail(this Argument argument, int index)
        {
            return false;
        }

        public static int CountVerbs(this Argument argument)
        {
            return argument.Verbs.Count();
        }

        public static int CountOptions(this Argument argument)
        {
            return argument.Short.Count() + argument.Long.Count();
        }

        public static int CountOptions(this Argument argument, string name)
        {
            return argument[name].Count();
        }

        public static int CountTail(this Argument argument)
        {
            return 0;
        }

        public static string GetVerb(this Argument argument)
        {
            return argument.Verbs.FirstOrDefault();
        }

        public static string GetVerb(this Argument argument, int index)
        {
            return argument.Verbs.ElementAtOrDefault(index);
        }

        public static string GetOption(this Argument argument, string name)
        {
            return argument[name].FirstOrDefault();
        }

        public static string GetOption(this Argument argument, string name, int index)
        {
            return argument[name].ElementAtOrDefault(index);
        }

        public static string GetTail(this Argument argument, int index)
        {
            return null;
        }
    }
}