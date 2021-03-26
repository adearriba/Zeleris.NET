using Newtonsoft.Json.Converters;

namespace NZeleris.Library.Extensions
{
    public class ZelerisDateTimeConverter : IsoDateTimeConverter
    {
        public ZelerisDateTimeConverter()
        {
            base.DateTimeFormat = "yyyyMMddHHmmss";
        }
    }
}
