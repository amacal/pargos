using System;

namespace Pargos
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class AfterAttribute : Attribute
    {
        private readonly int index;

        public AfterAttribute(int index)
        {
            this.index = index;
        }

        internal void Apply(ArgumentRoutine routine)
        {
            routine.WithSelector(source => new ArgumentIndexableRange(source, index, 1));
        }
    }
}