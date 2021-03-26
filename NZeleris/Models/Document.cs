using Newtonsoft.Json;
using System;

namespace NZeleris.Library.Models
{
    public class Document : IZelerisModel
    {
        [JsonProperty("ID_DOCUMENTO")]
        public string DocumentId { get; set; }
        [JsonProperty("ID_CLIENTE")]
        public string ClientId { get; set; }
        [JsonProperty("ID_TIPO_DOCUMENTO")] 
        public string DocumentTypeId { get; set; }
        [JsonProperty("NUMERO_DOCUMENTO")]
        public string DocumentNumber { get; set; }
        [JsonProperty("FECHA_DOCUMENTO")]
        [JsonConverter(typeof(Extensions.ZelerisDateTimeConverter))]
        public DateTime? DocumentDateTime { get; set; }
        [JsonProperty("FECHA_SERVICIO")]
        [JsonConverter(typeof(Extensions.ZelerisDateTimeConverter))]
        public DateTime? ServiceDateTime { get; set; }
        [JsonProperty("ID_TIPO_SERVICIO")]
        public string ServiceTypeId { get; set; }
        [JsonProperty("ID_TIPO_PORTE")]
        public string PaidTypeId { get; set; }

        [JsonProperty("ID_SOLICITANTE")]
        public string BillingClientId { get; set; }
        [JsonProperty("NOMBRE_SOL")]
        public string BillingClientName { get; set; }
        [JsonProperty("CONTACTO_SOL")]
        public string BillingContactName { get; set; }
        [JsonProperty("NIF_SOL")]
        public string BillingDocumentId { get; set; }
        [JsonProperty("DIRECCION_SOL")]
        public string BillingAddress { get; set; }
        [JsonProperty("POBLACION_SOL")]
        public string BillingCity { get; set; }
        [JsonProperty("PROVINCIA_SOL")]
        public string BillingProvince { get; set; }
        [JsonProperty("COD_POSTAL_SOL")]
        public string BillingZipCode { get; set; }

        [JsonProperty("ID_CONSIGNATARIO")]
        public string ShippingClientId { get; set; }
        [JsonProperty("NOMBRE_CONS")]
        public string ShippingClientName { get; set; }
        [JsonProperty("CONTACTO_CONS")] 
        public string ShippingContactName{ get; set; }
        [JsonProperty("NIF_CONS")]
        public string ShippingNIF { get; set; }
        [JsonProperty("DIRECCION_CONS")]
        public string ShippingAddress { get; set; }
        [JsonProperty("POBLACION_CONS")]
        public string ShippingCity { get; set; }
        [JsonProperty("PROVINCIA_CONS")]
        public string ShippingProvince { get; set; }
        [JsonProperty("CODIGO_POSTAL_CONS")]
        public string ShippingZip { get; set; }
        [JsonProperty("PAIS_CONS")]
        public string ShippingCountry { get; set; }
        [JsonProperty("TELEFONO_CONS")]
        public string ShippingPhoneNumber { get; set; }
        [JsonProperty("EMAIL_CONS")]
        public string ShippingEmail { get; set; }

        [JsonProperty("ID_ALMACEN")]
        public string StorageId { get; set; }
        [JsonProperty("OBSERVACIONES")] 
        public string OrderObservations { get; set; }
        [JsonProperty("TOTAL_BULTOS")]
        public string TotalQuantity { get; set; }
    }
}
