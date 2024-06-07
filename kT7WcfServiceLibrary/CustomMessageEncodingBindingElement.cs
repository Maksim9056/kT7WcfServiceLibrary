using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace kT7WcfServiceLibrary
{
    public class CustomMessageEncodingBindingElement : MessageEncodingBindingElement
    {
        private readonly MessageEncodingBindingElement innerBindingElement;

        public CustomMessageEncodingBindingElement(MessageEncodingBindingElement innerBindingElement)
        {
            this.innerBindingElement = innerBindingElement;
        }

        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new CustomMessageEncoderFactory(innerBindingElement.CreateMessageEncoderFactory());
        }

        public override BindingElement Clone()
        {
            return new CustomMessageEncodingBindingElement((MessageEncodingBindingElement)innerBindingElement.Clone());
        }

        public override MessageVersion MessageVersion
        {
            get => innerBindingElement.MessageVersion;
            set => innerBindingElement.MessageVersion = value;
        }
    }

}
