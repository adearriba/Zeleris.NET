using System;
using System.Collections.Generic;
using System.Linq;
using NZeleris.Library.Models;
using NZeleris.Library.Models.Components;
using NZeleris.Library.Models.Components.Extensions;
using NZeleris.Library.Models.Components.Serializers;

namespace NZeleris.Library.Requests
{
    public class CreateDocumentRequest : BaseRequest
    {
        private readonly CompositeComponent _document;
        private readonly CompositeComponent _registry;

        public CreateDocumentRequest(IComponentSerializer serializaer) : base(serializaer)
        {
            _document = new CompositeComponent("DOCUMENTO");
            _registry = new CompositeComponent("REGISTRO");

            _document.AddComponent(_registry);
        }

        public override CreateDocumentRequest AddAccountInfo(AccountInfo accountInfo)
        {
            _root.AddComponent(accountInfo);
            return this;
        }

        public CreateDocumentRequest AddLineItem(LineItem item)
        {
            _registry.AddComponent(item.ToSerializableComponent("LINEA"));
            return this;
        }

        public CreateDocumentRequest AddDocumentInfo(Document documentInfo)
        {
            var composites = _registry.Children.Where(c => c.GetType() == typeof(CompositeComponent)) as IEnumerable<CompositeComponent>;
            var exists = composites == null ? false : composites.Count(c => c.Name == "CABECERA") == 1;

            if (exists)
            {
                throw new ArgumentException("Document information already existis in request.");
            }

            var component = documentInfo.ToSerializableComponent("CABECERA");
            _registry.AddComponent(component);
            return this;
        }

        public override string BuildRequest()
        {
            _root.AddComponent(_document);
            return base.BuildRequest();
        }
    }
}
