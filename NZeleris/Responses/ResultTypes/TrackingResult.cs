using Newtonsoft.Json;
using System;
using NZeleris.Library.Extensions;

namespace NZeleris.Library.Responses.ResultTypes
{
    public class TrackingResult
    {
        [JsonProperty("ESTADO")]
        public string Status { get; set; }
        [JsonProperty("FECHA")]
        [JsonConverter(typeof(ZelerisDateTimeConverter))]
        public DateTime DateTime { get; set; }
        [JsonProperty("INCIDENCIA")]
        public string Incident { get; set; }
        [JsonProperty("OBSERVACIONES")]
        public string Observations { get; set; }
    }
}
