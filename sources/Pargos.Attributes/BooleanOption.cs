using Pargos.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pargos.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BooleanOption : ConvertOption
    {
        private readonly string @false;
        private readonly string @true;

        public BooleanOption(string @true)
        {
            this.@true = @true;
        }

        public BooleanOption(string @true, string @false)
        {
            this.@false = @false;
            this.@true = @true;
        }

        public override object Convert(IEnumerable<Argument> arguments)
        {
            if (arguments.Any() == false)
                return false;

            if (arguments.Any(x => x.Value == @true))
                return true;

            if (arguments.Any(x => x.Value == @false))
                return false;

            return arguments.All(x => x.Value == null);
        }
    }
}