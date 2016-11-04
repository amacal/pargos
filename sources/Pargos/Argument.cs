namespace Pargos
{
    public abstract class Argument
    {
        public abstract int Parameters { get; }

        public abstract int Tail { get; }

        public abstract int Options { get; }

        public abstract string this[int index] { get; }

        public abstract string[] this[string index] { get; }

        public static Argument Parse(params string[] data)
        {
            return ArgumentParser.Parse(data);
        }

        public static TOptions Parse<TOptions>(params string[] data)
            where TOptions : class, new()
        {
            return ArgumentSerializer.Deserialize<TOptions>(data);
        }
    }
}