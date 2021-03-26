using Newtonsoft.Json;
using System.Collections.Generic;
using NZeleris.Library.Models;
using NZeleris.Library.Responses.ResultTypes;

namespace NZeleris.Library.Responses
{
    public class DocumentInformationResponse : BaseResponse
    {
        private Document _document = null;
        private List<LineItem> _lineItems = null;

        public override bool IsSuccessful { get => int.Parse(Result.Code) == 0; }

        [JsonProperty("ERROR")]
        public StringCodeResult Error { get; set; }

        [JsonProperty("RESULTADO")]
        public virtual DynamicCodeResult Result { get; set; }

        public Document Document
        {
            get
            {
                if (_document != null) return _document;

                var json = Result.Description["DOCUMENTO"]["CABECERA"];
                _document = json.ToObject<Document>();
                return _document;
            } 
        }

        public List<LineItem> LineItems
        {
            get
            {
                if (_lineItems != null) return _lineItems;
                _lineItems = Result.Description["DOCUMENTO"]["LINEA"].ToObject<List<LineItem>>();

                return _lineItems;
            }
        }
    }
}
