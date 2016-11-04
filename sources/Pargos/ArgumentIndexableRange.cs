namespace Pargos
{
    internal class ArgumentIndexableRange : ArgumentIndexable
    {
        private readonly ArgumentIndexable source;
        private readonly int offset;
        private readonly int count;

        public ArgumentIndexableRange(ArgumentIndexable source, int offset, int count)
        {
            this.source = source;
            this.offset = offset;
            this.count = count;
        }

        public string this[int index]
        {
            get { return source[offset + index]; }
        }
    }
}