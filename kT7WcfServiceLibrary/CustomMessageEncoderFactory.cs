using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace kT7WcfServiceLibrary
{
    public class CustomMessageEncoderFactory : MessageEncoderFactory
    {
        private readonly MessageEncoderFactory innerFactory;
        private readonly MessageEncoder encoder;

        public CustomMessageEncoderFactory(MessageEncoderFactory innerFactory)
        {
            this.innerFactory = innerFactory;
            encoder = new CustomMessageEncoder(innerFactory.Encoder);
        }

        public override MessageEncoder Encoder => encoder;

        public override MessageVersion MessageVersion => innerFactory.MessageVersion;
    }

}
