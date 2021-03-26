using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZeleris.Library.Models.Components;
using NZeleris.Library.Models.Components.Serializers;
using NZeleris.Library.Requests;

namespace NZeleris.Tests
{
    [TestClass]
    public class XMLSerializationTest
    {
        private ZelerisTestSettings _settings;

        public XMLSerializationTest()
        {
            _settings = ZelerisTestSettings.GetInstance();
        }

        [TestMethod]
        public void AccountInfo_Composite_Serialization()
        {
            ISerializableComponent accountInfo = new CompositeComponent("INFOCUENTA");
            IComponentSerializer serializer = new XmlComponentSerializer();

            accountInfo
                .AddComponent(new NodeComponent("USUARIO", "user"))
                .AddComponent(new NodeComponent("CLAVE", "123"))
                .AddComponent(new NodeComponent("FECHA", "yyyyMMddHHmmss"));

            var result = accountInfo.Serialize(serializer).Build();

            string expectedResult = "<INFOCUENTA><USUARIO>user</USUARIO><CLAVE>123</CLAVE><FECHA>yyyyMMddHHmmss</FECHA></INFOCUENTA>";
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void AccountInfo_Composite_Serialization_with_class()
        {
            IComponentSerializer serializer = new XmlComponentSerializer();

            AccountInfo accountInfo = new AccountInfo("user", "123", "yyyyMMddHHmmss");
            var result = accountInfo.Serialize(serializer).Build();

            string expectedResult = "<INFOCUENTA><USUARIO>user</USUARIO><CLAVE>123</CLAVE><FECHA>yyyyMMddHHmmss</FECHA></INFOCUENTA>";
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void DocumentInformationRequest_Serialization()
        {
            IComponentSerializer serializer = new XmlComponentSerializer();
            DocumentInformationRequest request = new DocumentInformationRequest(serializer);
            
            AccountInfo accountInfo = new AccountInfo("user", "123", "yyyyMMddHHmmss");
            request.AddAccountInfo(accountInfo)
                .AddClientId(_settings.ClientId)
                .AddDocumentNumber("12345");

            var result = request.BuildRequest();

            string expectedResult = "<BODY><INFOCUENTA><USUARIO>user</USUARIO><CLAVE>123</CLAVE><FECHA>yyyyMMddHHmmss</FECHA></INFOCUENTA>" +
                "<DOCUMENTO><REGISTRO><CABECERA><ID_CLIENTE>"+ _settings .ClientId + "</ID_CLIENTE><NUMERO_DOCUMENTO>12345</NUMERO_DOCUMENTO></CABECERA></REGISTRO></DOCUMENTO></BODY>";
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void CancelDocumentRequest_Serialization()
        {
            IComponentSerializer serializer = new XmlComponentSerializer();
            CancelDocumentRequest request = new CancelDocumentRequest(serializer);

            AccountInfo accountInfo = new AccountInfo("user", "123", "yyyyMMddHHmmss");
            request
                .AddAccountInfo(accountInfo)
                .AddDocumentId("123")
                .AddClientId(_settings.ClientId)
                .AddDocumentNumber("456")
                .AddDocumentTypeId("ENT");

            var result = request.BuildRequest();

            string expectedResult = "<BODY><INFOCUENTA><USUARIO>user</USUARIO><CLAVE>123</CLAVE>" +
                "<FECHA>yyyyMMddHHmmss</FECHA></INFOCUENTA><CANCELA><REGISTRO><ID_DOCUMENTO>123</ID_DOCUMENTO>" +
                "<ID_CLIENTE>"+ _settings.ClientId + "</ID_CLIENTE><NUMERO_DOCUMENTO>456</NUMERO_DOCUMENTO>" +
                "<ID_TIPO_DOCUMENTO>ENT</ID_TIPO_DOCUMENTO></REGISTRO></CANCELA></BODY>";

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void ModifyDocumentRequest_Serialization()
        {
            IComponentSerializer serializer = new XmlComponentSerializer();
            ModifyDocumentRequest request = new ModifyDocumentRequest(serializer);

            AccountInfo accountInfo = new AccountInfo("user", "123", "yyyyMMddHHmmss");
            request
                .AddAccountInfo(accountInfo)
                .AddDocumentInfo(new Library.Models.Document
                {
                    ClientId = _settings.ClientId,
                    DocumentNumber = "123",
                    BillingAddress = "Calle Bronce",
                    BillingCity = "Madrid",
                    BillingZipCode = "28050",
                    ShippingAddress = "Ronda de la comunicación",
                    ShippingCity = "Madrid",
                    ShippingClientName = "Jose",
                    ShippingCountry = "ES",
                    ShippingNIF = "93048596k"
                })
                .AddLineItem(new Library.Models.LineItem
                {
                    ClientId = _settings.ClientId,
                    OwnerId = "456",
                    ProductCode = "789",
                    ProductStateId = "1",
                    QCStateId = "2",
                    Quantity = 2
                })
                .AddLineItem(new Library.Models.LineItem
                {
                    ClientId = _settings.ClientId,
                    OwnerId = "456",
                    ProductCode = "789",
                    ProductStateId = "1",
                    QCStateId = "2",
                    Quantity = 4
                });                

            var result = request.BuildRequest();
            string expectedResult = "<BODY><INFOCUENTA><USUARIO>user</USUARIO><CLAVE>123</CLAVE>" +
                "<FECHA>yyyyMMddHHmmss</FECHA></INFOCUENTA><DOCUMENTO><REGISTRO><CABECERA>" +
                "<ID_CLIENTE>"+ _settings.ClientId +"</ID_CLIENTE><NUMERO_DOCUMENTO>123</NUMERO_DOCUMENTO>" +
                "<DIRECCION_SOL>Calle Bronce</DIRECCION_SOL><POBLACION_SOL>Madrid</POBLACION_SOL>" +
                "<COD_POSTAL_SOL>28050</COD_POSTAL_SOL><NOMBRE_CONS>Jose</NOMBRE_CONS><NIF_CONS>93048596k</NIF_CONS>" +
                "<DIRECCION_CONS>Ronda de la comunicación</DIRECCION_CONS><POBLACION_CONS>Madrid</POBLACION_CONS>" +
                "<PAIS_CONS>ES</PAIS_CONS></CABECERA><LINEA><ID_CLIENTE>" + _settings.ClientId + "</ID_CLIENTE><COD_ARTICULO>789</COD_ARTICULO>" +
                "<ID_ESTADO_PRODUCTO>1</ID_ESTADO_PRODUCTO><ID_ESTADO_QC>2</ID_ESTADO_QC>" +
                "<ID_PROPIETARIO>456</ID_PROPIETARIO><CANTIDAD>2</CANTIDAD></LINEA><LINEA><ID_CLIENTE>" + _settings.ClientId + "</ID_CLIENTE>" +
                "<COD_ARTICULO>789</COD_ARTICULO><ID_ESTADO_PRODUCTO>1</ID_ESTADO_PRODUCTO><ID_ESTADO_QC>2</ID_ESTADO_QC>" +
                "<ID_PROPIETARIO>456</ID_PROPIETARIO><CANTIDAD>4</CANTIDAD></LINEA></REGISTRO></DOCUMENTO></BODY>";

            Assert.AreEqual(result, expectedResult);
        }
    }
}
