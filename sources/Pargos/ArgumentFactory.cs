namespace Pargos
{
    public static class ArgumentFactory
    {
        public static ArgumentCollection Parse(string[] args)
        {
            return new ArgumentCollection(args);
        }
    }
}