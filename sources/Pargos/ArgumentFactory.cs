namespace Pargos.Core
{
    public static class ArgumentFactory
    {
        public static ArgumentCollection Parse(params string[] args)
        {
            return new ArgumentCollection(args);
        }
    }
}