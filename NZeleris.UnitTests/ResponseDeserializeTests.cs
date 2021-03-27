using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using NZeleris.Library.Responses;
using NZeleris.Library.Responses.Deserializers;

namespace NZeleris.Tests
{
    [TestClass]
    public class ResponseDeserializeTests
    {
        private ZelerisTestSettings _settings;
        private IDeserializer _deserializer;

        public ResponseDeserializeTests()
        {
            _settings = ZelerisTestSettings.GetInstance();
            _deserializer = new ZelerisResponseDeserializer();
        }

        [TestMethod]
        public void Deserialize_Tracking_Result()
        {
            var response = File.ReadAllText($"{_settings.XMLTestDirectory}/TrackingResult.xml");
            var result = _deserializer.Deserialize<DocumentTrackingResponse>(response);

            Assert.AreEqual("0", result.Result.Code);
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(4, result.Events.Count);

            var firstDate = DateTime.ParseExact("20120420121310", "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            Assert.AreEqual(firstDate, result.Events.First().DateTime);
        }
    }
}
