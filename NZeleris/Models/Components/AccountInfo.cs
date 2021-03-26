namespace NZeleris.Library.Models.Components
{
    public class AccountInfo : CompositeComponent
    {
        public AccountInfo(string user, string pass, string date) : base("INFOCUENTA")
        {
            AddComponent(new NodeComponent("USUARIO", user));
            AddComponent(new NodeComponent("CLAVE", pass));
            AddComponent(new NodeComponent("FECHA", date));
        }
    }
}
