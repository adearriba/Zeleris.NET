using Newtonsoft.Json;

namespace NZeleris.Library.Models
{
    public class LineItem : IZelerisModel
    {
        [JsonProperty("ID_CLIENTE")]
        public string ClientId { get; set; }
        [JsonProperty("COD_ARTICULO")]
        public string ProductCode { get; set; }
        [JsonProperty("ID_ESTADO_PRODUCTO")] 
        public string ProductStateId { get; set; }
        [JsonProperty("ID_ESTADO_QC")]
        public string QCStateId { get; set; }
        [JsonProperty("ID_PROPIETARIO")]
        public string OwnerId { get; set; }
        [JsonProperty("CANTIDAD")]
        public int Quantity { get; set; }
    }
}
