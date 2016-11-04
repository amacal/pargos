using System;

namespace Pargos
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class OptionAttribute : Attribute
    {
        private readonly string names;

        public OptionAttribute(string name)
        {
            this.names = name;
        }

        public string[] Filter(Argument argument)
        {
            return argument[names];
        }
    }
}