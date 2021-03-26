using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZeleris.Library;
using NZeleris.Library.Models.Components.Serializers;
using NZeleris.Library.Requests;
using System;

namespace NZeleris.Tests
{
    [TestClass]
    public class ClientRequestsTests
    {
        private ZelerisTestSettings _settings;
        private ZelerisClient _client;
        private IComponentSerializer _serializer;

        private const string documentId = "1965840";
        private const string documentNumber = "2248063189124";

        public ClientRequestsTests()
        {
            _settings = ZelerisTestSettings.GetInstance();
            _client = new ZelerisClient(_settings.APIUser, _settings.APIPassword);
            _serializer = new XmlComponentSerializer();
        }

        [TestMethod]
        public void DocumentInformationResquest_doesnt_exists()
        {
            var request = new DocumentInformationRequest(_serializer);
            request.AddClientId(_settings.ClientId)
                .AddDocumentNumber(documentNumber)
                .AddDocumentId(documentId);


            var result = _client.GetDocument(request).GetAwaiter().GetResult();
            Assert.AreEqual(result.Result.Code, "-1");
        }

        [TestMethod]
        public void CancelDocumentRequest_doesnt_exists()
        {
            var request = new CancelDocumentRequest(_serializer);
            request.AddDocumentId(documentId)
                .AddClientId(_settings.ClientId)
                .AddDocumentNumber(documentNumber)
                .AddDocumentTypeId("ENT");

            var result = _client.CancelDocument(request).GetAwaiter().GetResult();
            Assert.AreEqual(result.Result.Code, "-1");
        }

        [TestMethod]
        public void TrackingDocumentRequest_doesnt_exists()
        {
            var request = new DocumentTrackingRequest(_serializer);
            request.AddDocumentId(documentId)
                .AddClientId(_settings.ClientId)
                .AddDocumentNumber(documentNumber);

            var result = _client.GetDocumentTracking(request).GetAwaiter().GetResult();
            Assert.AreEqual(result.Result.Code, "0");
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(0, result.Events.Count);
        }
    }
}
