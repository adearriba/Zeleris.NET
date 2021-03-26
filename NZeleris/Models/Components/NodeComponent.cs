using System.Collections.Generic;
using NZeleris.Library.Models.Components.Serializers;

namespace NZeleris.Library.Models.Components
{
    public class NodeComponent : ISerializableComponent
    {
        public KeyValuePair<string, string> Data { get; init; }

        public NodeComponent(string key, string value)
        {
            Data = new KeyValuePair<string, string>(key, value);
        }

        public ISerializableComponent AddComponent(ISerializableComponent component)
        {
            var composite = new CompositeComponent(Data.Key);
            composite.AddComponent(component);
            return composite;
        }

        public IComponentSerializer Serialize(IComponentSerializer serializer)
        {
            return serializer.Serialize(this);
        }
    }
}
