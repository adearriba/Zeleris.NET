using NZeleris.Library.Models.Components.Serializers;

namespace NZeleris.Library.Models.Components
{
    public interface ISerializableComponent
    {
        ISerializableComponent AddComponent(ISerializableComponent component);
        IComponentSerializer Serialize(IComponentSerializer serializer);
    }
}
