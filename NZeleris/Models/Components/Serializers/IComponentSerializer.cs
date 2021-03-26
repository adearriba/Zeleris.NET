namespace NZeleris.Library.Models.Components.Serializers
{
    public interface IComponentSerializer
    {
        IComponentSerializer Serialize(CompositeComponent component);
        IComponentSerializer Serialize(NodeComponent component);
        string Build();
    }
}
