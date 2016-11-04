using System.Collections.Generic;

namespace Pargos
{
    internal class ArgumentIndexableList : ArgumentIndexable
    {
        private readonly List<string> data;

        public ArgumentIndexableList(List<string> data)
        {
            this.data = data;
        }

        public string this[int index]
        {
            get { return data[index]; }
        }
    }
}