using Pargos.Core;
using System;
using System.Collections.Generic;

namespace Pargos.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IndexOptionAttribute : OptionAttribute
    {
        private readonly int index;

        public IndexOptionAttribute(int index)
        {
            this.index = index;
        }

        public override IEnumerable<Argument> Match(ArgumentCollection arguments)
        {
            yield return arguments.Value(index);
        }
    }
}