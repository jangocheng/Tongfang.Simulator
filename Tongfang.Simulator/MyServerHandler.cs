using DotNetty.Buffers;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tongfang.Simulator
{
    public class MessageEventArgs : EventArgs
    {
        private MessageData _message;

        public MessageEventArgs(MessageData message)
        {
            _message = message;
        }

        public MessageData Message
        {
            get { return _message; }
        }
    }

    public class MyServerHandler : ChannelHandlerAdapter
    {
        public event EventHandler<MessageEventArgs> Received;

        public override bool IsSharable => true;

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var buffer = message as IByteBuffer;
            if (buffer == null)
            {
                return;
            }
            int length = buffer.ReadableBytes;
            byte[] sourceArray = new byte[length];
            buffer.ReadBytes(sourceArray);
            ArraySegment<byte> body = new ArraySegment<byte>(sourceArray, 2, length - 6);
            MessageData md = new MessageData(
                new MessageHead() { FirstByte = sourceArray[0], TypeByte = sourceArray[1] },
                new MessageBody(body.ToArray())
                );
            OnReceived(new MessageEventArgs(md));
            if (md.Head.TypeByte == 100)
            {                
                byte[] responseHead = new byte[] { md.Head.FirstByte, md.Head.TypeByte };
                byte[] responseBody = Encoding.UTF8.GetBytes("{\"state\":9,\"deviceIds\":[]}");
                List<byte> list = new List<byte>(256);
                list.AddRange(responseHead);
                list.AddRange(responseBody);
                IByteBuffer response = Unpooled.Buffer(list.Capacity);
                response.WriteBytes(list.ToArray());
                context.WriteAndFlushAsync(response);
            }
        }

        protected void OnReceived(MessageEventArgs e)
        {
            Received?.Invoke(this, e);
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            context.Flush();
        }
    }
}
