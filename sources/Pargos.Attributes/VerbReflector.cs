using System.Reflection;

namespace Pargos.Attributes
{
    public static class VerbReflector
    {
        public static PropertyInfo GetByName(object instance, string verb)
        {
            foreach (PropertyInfo property in instance.GetType().GetProperties())
            {
                foreach (VerbAttribute attribute in property.GetCustomAttributes<VerbAttribute>())
                {
                    if (attribute.Name == verb)
                    {
                        return property;
                    }
                }
            }

            return null;
        }
    }
}