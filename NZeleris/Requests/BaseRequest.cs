using NZeleris.Library.Models.Components;
using NZeleris.Library.Models.Components.Serializers;

namespace NZeleris.Library.Requests
{
    public abstract class BaseRequest
    {
        protected readonly IComponentSerializer _serializer;
        protected ISerializableComponent _root;

        public BaseRequest(IComponentSerializer serializaer, string rootName = "BODY")
        {
            _serializer = serializaer;
            _root = new CompositeComponent(rootName);
        }

        public virtual BaseRequest AddAccountInfo(AccountInfo accountInfo)
        {
            _root.AddComponent(accountInfo);
            return this;
        }

        public virtual string BuildRequest()
        {
            return _root.Serialize(_serializer).Build();
        }

    }
}
