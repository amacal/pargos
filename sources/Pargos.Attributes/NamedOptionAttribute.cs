using Pargos.Core;
using System;
using System.Collections.Generic;

namespace Pargos.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NamedOptionAttribute : OptionAttribute
    {
        private readonly string name;

        public NamedOptionAttribute(string name)
        {
            this.name = name;
        }

        public override IEnumerable<Argument> Match(ArgumentCollection arguments)
        {
            if (arguments.Has(name))
            {
                yield return arguments.Value(name);
            }
        }
    }
}