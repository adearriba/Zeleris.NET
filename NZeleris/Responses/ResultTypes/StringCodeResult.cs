using Newtonsoft.Json;

namespace NZeleris.Library.Responses.ResultTypes
{
    public class StringCodeResult
    {
        [JsonProperty("CODIGO")]
        public string Code { get; set; }
        [JsonProperty("DESCRIPCION")]
        public string Description { get; set; }
    }
}
