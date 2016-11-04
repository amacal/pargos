using System;

namespace Pargos
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PresenceAttribute : Attribute
    {
        internal void Apply(ArgumentRoutine routine)
        {
            routine.WithSelector(indexable => indexable);
            routine.WithConverter(indexable => indexable != null);
        }
    }
}