using Microsoft.VisualStudio.TestTools.UnitTesting;
using NZeleris.Library.Models;
using NZeleris.Library.Models.Components;
using NZeleris.Library.Models.Components.Extensions;
using System;

namespace NZeleris.Tests
{
    [TestClass]
    public class ComponentExtensionsTests
    {
        [TestMethod]
        public void Create_Component_From_Document_Object()
        {
            Document document = new Document();
            document.DocumentDateTime = DateTime.Now;
            document.ServiceDateTime = DateTime.Now;
            document.BillingAddress = "Calle Bronce";
            document.BillingCity = "Madrid";
            document.BillingClientName = "Alejandro";

            CompositeComponent component = (CompositeComponent) document.ToSerializableComponent("CABECERA");

            Assert.IsNotNull(component);
            Assert.AreEqual("CABECERA", component.Name);
            Assert.AreEqual(5, component.Children.Count);
        }

        [TestMethod]
        public void Create_Component_From_Lineitem_Object()
        {
            LineItem item = new LineItem
            {
                ClientId = "123",
                OwnerId = "456",
                ProductCode = "789",
                ProductStateId = "1",
                QCStateId = "2",
                Quantity = 2
            };

            CompositeComponent component = (CompositeComponent)item.ToSerializableComponent("LINEA");

            Assert.IsNotNull(component);
            Assert.AreEqual("LINEA", component.Name);
            Assert.AreEqual(6, component.Children.Count);
        }
    }
}
