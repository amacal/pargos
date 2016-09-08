using System;

namespace Pargos.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class VerbAttribute : Attribute
    {
        private readonly string name;

        public VerbAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}