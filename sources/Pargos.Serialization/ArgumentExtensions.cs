using Pargos.Core;

namespace Pargos.Serialization
{
    public static class ArgumentExtensions
    {
        public static TInstance Deserialize<TInstance>(this ArgumentCollection arguments)
            where TInstance : class, new()
        {
            ArgumentSerializer serializer = new ArgumentSerializer();
            TInstance instance = new TInstance();

            serializer.Apply(arguments, instance);
            return instance;
        }
    }
}