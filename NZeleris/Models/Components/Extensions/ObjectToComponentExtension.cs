using Newtonsoft.Json;
using System.Linq;

namespace NZeleris.Library.Models.Components.Extensions
{
    public static class ObjectToComponentExtension
    {
        public static ISerializableComponent ToSerializableComponent(this IZelerisModel obj, string rootName)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            ISerializableComponent _root = new CompositeComponent(rootName);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(obj);
                if (value == null) continue;

                var jsonProperty = prop.GetCustomAttributes(true).Where(c => c.GetType() == typeof(JsonPropertyAttribute)).FirstOrDefault() as JsonPropertyAttribute;
                if (jsonProperty == null) continue;
                
                var name = jsonProperty.PropertyName;
                ISerializableComponent node = new NodeComponent(name, value.ToString());
                _root.AddComponent(node);
            }

            return _root;
        }
    }
}
