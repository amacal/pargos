using System;

namespace Pargos
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MatchAttribute : Attribute
    {
        private readonly string value;

        public MatchAttribute(string value)
        {
            this.value = value;
        }

        internal void Apply(ArgumentRoutine routine)
        {
            routine.WithMatch(source => source[0] == value);
        }
    }
}