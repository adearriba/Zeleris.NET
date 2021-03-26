using System.Text;

namespace NZeleris.Library.Models.Components.Serializers
{
    public class XmlComponentSerializer : IComponentSerializer
    {
        private readonly StringBuilder _builder;

        public XmlComponentSerializer()
        {
            _builder = new StringBuilder();
        }

        public string Build()
        {
            return _builder.ToString();
        }

        public IComponentSerializer Serialize(CompositeComponent component)
        {
            _builder.Append($"<{component.Name}>");
            foreach (var child in component.Children)
            {
                child.Serialize(this);
            }
            _builder.Append($"</{component.Name}>");

            return this;
        }

        public IComponentSerializer Serialize(NodeComponent component)
        {
            _builder.Append($"<{component.Data.Key}>{component.Data.Value}</{component.Data.Key}>");
            return this;
        }
    }
}
