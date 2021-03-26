using Newtonsoft.Json;
using NZeleris.Library.Responses;
using NZeleris.Library.Responses.ResultTypes;

namespace NZeleris.Library.Responses
{
    public class ModifyDocumentResponse : BaseResponse
    {
        public override bool IsSuccessful { get => int.Parse(Result.Code) == 0; }

        [JsonProperty("ERROR")]
        public StringCodeResult Error { get; set; }

        [JsonProperty("RESULTADO")]
        public StringCodeResult Result { get; set; }
    }
}
