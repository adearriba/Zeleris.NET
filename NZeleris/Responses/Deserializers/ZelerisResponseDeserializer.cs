using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace NZeleris.Library.Responses.Deserializers
{
    public class ZelerisResponseDeserializer : IDeserializer
    {
        public T Deserialize<T>(string data)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);

            string json = JsonConvert.SerializeXmlNode(doc.DocumentElement);
            return JObject.Parse(json)["BODY"].ToObject<T>();
        }
    }
}
