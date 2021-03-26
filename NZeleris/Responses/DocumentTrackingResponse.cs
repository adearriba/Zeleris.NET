using Newtonsoft.Json;
using System.Collections.Generic;
using NZeleris.Library.Responses.ResultTypes;

namespace NZeleris.Library.Responses
{
    public class DocumentTrackingResponse : BaseResponse
    {
        public override bool IsSuccessful { get => int.Parse(Result.Code) == 0; }

        [JsonProperty("RESULTADO")]
        public StringCodeResult Result { get; set; }

        [JsonProperty("REGISTRO")]
        public List<TrackingResult> Events { get; set; }

        public DocumentTrackingResponse()
        {
            Events = new List<TrackingResult>();
        }
    }
}
