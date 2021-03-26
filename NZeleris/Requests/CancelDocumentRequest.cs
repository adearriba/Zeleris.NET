using NZeleris.Library.Models.Components;
using NZeleris.Library.Models.Components.Serializers;

namespace NZeleris.Library.Requests
{
    public class CancelDocumentRequest : BaseRequest
    {
        private CompositeComponent _cancelNode;
        private CompositeComponent _registryNode;
        public CancelDocumentRequest(IComponentSerializer serializaer) : base(serializaer)
        {
            _cancelNode = new CompositeComponent("CANCELA");
            _registryNode = new CompositeComponent("REGISTRO");

            _cancelNode.AddComponent(_registryNode);
        }

        public override CancelDocumentRequest AddAccountInfo(AccountInfo accountInfo)
        {
            _root.AddComponent(accountInfo);
            return this;
        }

        public CancelDocumentRequest AddClientId(string clientId)
        {
            _registryNode.AddComponent(new NodeComponent("ID_CLIENTE", clientId));
            return this;
        }
        public CancelDocumentRequest AddDocumentNumber(string documentNumber)
        {
            _registryNode.AddComponent(new NodeComponent("NUMERO_DOCUMENTO", documentNumber));
            return this;
        }
        public CancelDocumentRequest AddDocumentId(string documentId)
        {
            _registryNode.AddComponent(new NodeComponent("ID_DOCUMENTO", documentId));
            return this;
        }
        public CancelDocumentRequest AddDocumentTypeId(string documentTypeId)
        {
            _registryNode.AddComponent(new NodeComponent("ID_TIPO_DOCUMENTO", documentTypeId));
            return this;
        }

        public override string BuildRequest()
        {
            _root.AddComponent(_cancelNode);
            return base.BuildRequest();
        }
    }


}
