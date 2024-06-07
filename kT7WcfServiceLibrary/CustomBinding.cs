using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace kT7WcfServiceLibrary
{
    public class CustomBinding : Binding
    {
        private readonly MessageEncodingBindingElement encodingElement;
        private readonly HttpTransportBindingElement transportElement;

        public CustomBinding()
        {
            encodingElement = new CustomMessageEncodingBindingElement(new TextMessageEncodingBindingElement());
            transportElement = new HttpTransportBindingElement();
        }

        public override BindingElementCollection CreateBindingElements()
        {
            var elements = new BindingElementCollection();
            elements.Add(encodingElement);
            elements.Add(transportElement);
            return elements;
        }

        public override string Scheme => transportElement.Scheme;
    }

}
