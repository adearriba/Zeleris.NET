using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;
using NZeleris.Library.Responses;
using NZeleris.Library.Responses.Deserializers;

namespace NZeleris.Tests
{
    [TestClass]
    public class DocumentInformationResponseTests
    {
        private ZelerisTestSettings _settings;
        private IDeserializer _deserializer;

        public DocumentInformationResponseTests()
        {
            _settings = ZelerisTestSettings.GetInstance();
            _deserializer = new ZelerisResponseDeserializer();
        }

        [TestMethod]
        public void DocumentInformationResponse_from_XML()
        {
            var response = File.ReadAllText($"{_settings.XMLTestDirectory}\\ZelerisDocumentInformationResponse.xml");
            var result = _deserializer.Deserialize<DocumentInformationResponse>(response);

            Assert.IsTrue(result.IsSuccessful);
            Assert.IsTrue(result.LineItems.Count == 2);
            Assert.IsTrue(result.Document.DocumentId == "CAMPO1");

            var firstDate = DateTime.ParseExact("20120420121310", "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            Assert.AreEqual(firstDate, result.Document.DocumentDateTime);
            Assert.AreEqual(firstDate, result.Document.ServiceDateTime);
        }
    }
}
