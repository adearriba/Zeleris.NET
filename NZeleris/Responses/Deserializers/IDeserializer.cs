namespace NZeleris.Library.Responses.Deserializers
{
    public interface IDeserializer
    {
        public T Deserialize<T>(string data);
    }
}
