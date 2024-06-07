using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace kT7WcfServiceLibrary
{
    public class CustomMessageEncoder : MessageEncoder
    {
        private readonly MessageEncoder innerEncoder;

        public CustomMessageEncoder(MessageEncoder innerEncoder)
        {
            this.innerEncoder = innerEncoder;
        }

        public override string ContentType => innerEncoder.ContentType;

        public override string MediaType => innerEncoder.MediaType;

        public override MessageVersion MessageVersion => innerEncoder.MessageVersion;

        public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
        {
            Console.WriteLine("Reading message from stream...");
            return innerEncoder.ReadMessage(stream, maxSizeOfHeaders, contentType);
        }

        public override void WriteMessage(Message message, Stream stream)
        {
            Console.WriteLine("Writing message to stream...");
            innerEncoder.WriteMessage(message, stream);
        }

        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {
            byte[] msgContents = buffer.Array.Skip(buffer.Offset).Take(buffer.Count).ToArray();
            Console.WriteLine($"Reading message: {Encoding.Default.GetString(msgContents)}");
            return innerEncoder.ReadMessage(buffer, bufferManager, contentType);
        }

        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            var buffer = innerEncoder.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
            Console.WriteLine($"Writing message: {Encoding.Default.GetString(buffer.Array, buffer.Offset, buffer.Count)}");
            return buffer;
        }
    }

}
