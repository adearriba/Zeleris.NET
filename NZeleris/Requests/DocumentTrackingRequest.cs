using NZeleris.Library.Models.Components;
using NZeleris.Library.Models.Components.Serializers;

namespace NZeleris.Library.Requests
{
    public class DocumentTrackingRequest : BaseRequest
    {
        private readonly CompositeComponent _document;
        private readonly CompositeComponent _registry;

        public DocumentTrackingRequest(IComponentSerializer serializaer) : base(serializaer)
        {
            _document = new CompositeComponent("DOCUMENTO");
            _registry = new CompositeComponent("REGISTRO");

            _document.AddComponent(_registry);
        }

        public override DocumentTrackingRequest AddAccountInfo(AccountInfo accountInfo)
        {
            _root.AddComponent(accountInfo);
            return this;
        }

        public DocumentTrackingRequest AddDocumentId(string documentId)
        {
            _registry.AddValue("ID_DOCUMENTO", documentId);
            return this;
        }

        public DocumentTrackingRequest AddClientId(string clientId)
        {
            _registry.AddValue("ID_CLIENTE", clientId);
            return this;
        }

        public DocumentTrackingRequest AddDocumentNumber(string documentNumber)
        {
            _registry.AddValue("NUMERO_DOCUMENTO", documentNumber);
            return this;
        }

        public override string BuildRequest()
        {
            _root.AddComponent(_document);
            return base.BuildRequest();
        }
    }
}
