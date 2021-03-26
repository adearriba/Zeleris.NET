using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZeleris.Library;
using System.Linq;
using NZeleris.Library.Models.Components;

namespace NZeleris.Tests
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        [TestMethod]
        public void Generate_AccountInfo_Correctly()
        {
            AuthorizationService auth = new AuthorizationService("PEPE", "SECRETO_COMPARTIDO");
            var accountInfo = auth.GenerateSecurityInformation("20130212175030");

            NodeComponent password = (NodeComponent) accountInfo.Children
                                .Where(c => c is NodeComponent)
                                .Where(node => (node as NodeComponent).Data.Key == "CLAVE")
                                .FirstOrDefault();

            var expectedPassword = "W0JSaCajcobQAUMU7LOT9wS/zs8eGIGikf8A6a1ruYw=";

            Assert.AreEqual(password.Data.Value, expectedPassword);
        }
    }
}
