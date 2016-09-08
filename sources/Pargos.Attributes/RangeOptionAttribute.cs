using Pargos.Core;
using System;
using System.Collections.Generic;

namespace Pargos.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RangeOptionAttribute : OptionAttribute
    {
        private readonly int min;
        private readonly int max;

        public RangeOptionAttribute(int min)
        {
            this.min = min;
            this.max = Int32.MaxValue;
        }

        public RangeOptionAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override IEnumerable<Argument> Match(ArgumentCollection arguments)
        {
            for (int i = min; i <= max; i++)
            {
                if (arguments.Has(i) == false)
                {
                    break;
                }

                yield return arguments.Value(i);
            }
        }
    }
}