using NZeleris.Library.Models.Components;
using NZeleris.Library.Models.Components.Serializers;

namespace NZeleris.Library.Requests
{
    public class DocumentInformationRequest : BaseRequest
    {
        private readonly CompositeComponent _document;
        private readonly CompositeComponent _registry;
        private readonly CompositeComponent _header;

        public DocumentInformationRequest(IComponentSerializer serializaer) : base(serializaer)
        {
            _document = new CompositeComponent("DOCUMENTO");
            _registry = new CompositeComponent("REGISTRO");
            _header = new CompositeComponent("CABECERA");

            _registry.AddComponent(_header);
            _document.AddComponent(_registry);
        }

        public override DocumentInformationRequest AddAccountInfo(AccountInfo accountInfo)
        {
            _root.AddComponent(accountInfo);
            return this;
        }

        public DocumentInformationRequest AddClientId(string clientId)
        {
            _header.AddValue("ID_CLIENTE", clientId);
            return this;
        }

        public DocumentInformationRequest AddDocumentNumber(string documentNumber)
        {
            _header.AddValue("NUMERO_DOCUMENTO", documentNumber);
            return this;
        }

        public DocumentInformationRequest AddDocumentId(string documentId)
        {
            _header.AddValue("ID_DOCUMENTO", documentId);
            return this;
        }

        public override string BuildRequest()
        {
            _root.AddComponent(_document);
            return base.BuildRequest();
        }
    }
}
