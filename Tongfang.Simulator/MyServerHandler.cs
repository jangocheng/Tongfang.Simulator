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
    public class MyServerHandler : ChannelHandlerAdapter
    {
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var buffer = message as IByteBuffer;
            int length = buffer.ReadableBytes;
            byte[] data = new byte[length];
            buffer.ReadBytes(data);
            if (buffer != null)
            {
                string msg = Encoding.UTF8.GetString(data);
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            context.Flush();
        }
    }
}
