using NZeleris.Library.Responses;
using System.Threading.Tasks;
using NZeleris.Library.CancelaDocumento;
using NZeleris.Library.EnvioPedido;
using NZeleris.Library.InfoDocumento;
using NZeleris.Library.ModificaDocumento;
using NZeleris.Library.Requests;
using NZeleris.Library.Responses.Deserializers;
using NZeleris.Library.TrackingDocumento;

namespace NZeleris.Library
{
    public class ZelerisClient
    {
        private readonly AuthorizationService _auth;
        private readonly IDeserializer _deserializer;

        public ZelerisClient(string apiUser, string apiSecret)
        {
            _auth = new AuthorizationService(apiUser, apiSecret);
            _deserializer = new ZelerisResponseDeserializer();
        }

        public ZelerisClient(string apiUser, string apiSecret, IDeserializer deserializer)
        {
            _auth = new AuthorizationService(apiUser, apiSecret);
            _deserializer = deserializer;
        }

        public async Task<DocumentInformationResponse> GetDocument(DocumentInformationRequest request)
        {
            var accountInfo = _auth.GenerateSecurityInformation();
            request.AddAccountInfo(accountInfo);

            InfoDocumentoClient client = new InfoDocumentoClient();
            var result = await client.infoDocumentoXMLAsync(request.BuildRequest());

            return _deserializer.Deserialize<DocumentInformationResponse>(result);
        }

        public async Task<CreateDocumentResponse> CreateDocument(CreateDocumentRequest request)
        {
            var accountInfo = _auth.GenerateSecurityInformation();
            request.AddAccountInfo(accountInfo);

            EnvioPedidoClient client = new EnvioPedidoClient();
            var result = await client.orderPedidoXMLAsync(request.BuildRequest());

            return _deserializer.Deserialize<CreateDocumentResponse>(result);
        }

        public async Task<ModifyDocumentResponse> ModifyDocument(ModifyDocumentRequest request)
        {
            var accountInfo = _auth.GenerateSecurityInformation();
            request.AddAccountInfo(accountInfo);

            ModificaDocumentoClient client = new ModificaDocumentoClient();
            var result = await client.modificaDocumentoXMLAsync(request.BuildRequest());

            return _deserializer.Deserialize<ModifyDocumentResponse>(result);
        }

        public async Task<CancelDocumentResponse> CancelDocument(CancelDocumentRequest request)
        {
            var accountInfo = _auth.GenerateSecurityInformation();
            request.AddAccountInfo(accountInfo);

            CancelaDocumentoClient client = new CancelaDocumentoClient();
            var result = await client.cancelaDocumentoXMLAsync(request.BuildRequest());

            return _deserializer.Deserialize<CancelDocumentResponse>(result);
        }

        public async Task<DocumentTrackingResponse> GetDocumentTracking(DocumentTrackingRequest request)
        {
            var accountInfo = _auth.GenerateSecurityInformation();
            request.AddAccountInfo(accountInfo);

            TrackingDocumentoXMLClient client = new TrackingDocumentoXMLClient();
            var result = await client.getTrackingDocumentoXMLAsync(request.BuildRequest());

            return _deserializer.Deserialize<DocumentTrackingResponse>(result);
        }
    }
}
