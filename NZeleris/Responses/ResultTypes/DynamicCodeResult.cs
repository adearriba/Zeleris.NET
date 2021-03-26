using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NZeleris.Library.Responses.ResultTypes
{
    public class DynamicCodeResult
    {
        [JsonProperty("CODIGO")]
        public string Code { get; set; }
        [JsonProperty("DESCRIPCION")]
        public JToken Description { get; set; }
    }
}
