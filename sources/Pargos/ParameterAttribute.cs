using System;

namespace Pargos
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ParameterAttribute : Attribute
    {
        internal void Apply(ArgumentRoutine routine)
        {
            routine.WithParameter();
        }
    }
}