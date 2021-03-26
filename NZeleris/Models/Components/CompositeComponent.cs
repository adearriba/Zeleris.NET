using System.Collections.Generic;
using NZeleris.Library.Models.Components.Serializers;

namespace NZeleris.Library.Models.Components
{
    public class CompositeComponent : ISerializableComponent
    {
        public string Name { get; init; }
        public List<ISerializableComponent> Children { get; init; }

        public CompositeComponent(string name)
        {
            Name = name;
            Children = new List<ISerializableComponent>();
        }

        public ISerializableComponent AddComponent(ISerializableComponent component)
        {
            Children.Add(component);
            return this;
        }

        public CompositeComponent AddValue(string key, string value)
        {
            AddComponent(new NodeComponent(key, value));
            return this;
        }

        public IComponentSerializer Serialize(IComponentSerializer serializer)
        {
            return serializer.Serialize(this);
        }
    }
}
