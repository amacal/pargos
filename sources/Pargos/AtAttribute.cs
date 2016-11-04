using System;

namespace Pargos
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class AtAttribute : Attribute
    {
        private readonly int index;

        public AtAttribute(int index)
        {
            this.index = index;
        }

        internal void Apply(ArgumentRoutine routine)
        {
            routine.WithSelector(source => new ArgumentIndexableRange(source, index, 1));
        }
    }
}