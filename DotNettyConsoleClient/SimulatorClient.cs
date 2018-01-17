using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNettyConsoleClient
{
    public class TestClientHandler : ChannelHandlerAdapter
    {
        readonly IByteBuffer initialMessage;

        public TestClientHandler()
        {
            this.initialMessage = Unpooled.Buffer(256);
            byte[] messageBytes = Encoding.UTF8.GetBytes("Hello world");
            List<byte> datas = new List<byte>() { 0x55, 21 };
            datas.AddRange(messageBytes);
            this.initialMessage.WriteBytes(datas.ToArray());
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            context.WriteAndFlushAsync(this.initialMessage);
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var byteBuffer = message as IByteBuffer;
            if (byteBuffer != null)
            {
                Console.WriteLine("Received from server: " + byteBuffer.ToString(Encoding.UTF8));
            }
            context.WriteAsync(message);
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            context.Flush();
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine("Exception: " + exception);
            context.ConnectAsync(context.Channel.RemoteAddress);
        }
    }

    public class SimulatorClient : IDisposable
    {
        private IEventLoopGroup group;
        private Bootstrap bootstrap;
        private ICollection<IPEndPoint> _endPoints;
        private List<IChannel> _channels;

        public SimulatorClient(ICollection<IPEndPoint> endPoints)
        {
            _channels = new List<IChannel>();
            _endPoints = endPoints ?? throw new ArgumentNullException(nameof(endPoints));
            InitBootstrap();
        }

        private void InitBootstrap()
        {
            group = new MultithreadEventLoopGroup();
            bootstrap = new Bootstrap();
            bootstrap
                .Group(group)
                .Channel<TcpSocketChannel>()
                .Option(ChannelOption.TcpNodelay, true)
                .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
                {
                    IChannelPipeline pipeline = channel.Pipeline;
                    pipeline.AddLast("framing-enc", new LengthFieldPrepender(4));
                    pipeline.AddLast("framing-dec", new LengthFieldBasedFrameDecoder(1000, 0, 4, 0, 4));
                    pipeline.AddLast(new StringEncoder(), new StringDecoder(), new TestClientHandler());
                }));
        }

        private bool _isStart = false;

        public List<IChannel> Channels
        {
            get { return _channels; }
        }

        public async Task<List<IChannel>> ConnectAsync()
        {
            List<IChannel> list = new List<IChannel>();
            if (_isStart || !_endPoints.Any())
            {
                return await Task.FromResult(list);
            }
            //return await bootstrap.ConnectAsync(_endPoints.FirstOrDefault());
            //List<Task<IChannel>> tasks = new List<Task<IChannel>>();
            foreach (EndPoint endPoint in _endPoints)
            {
                IChannel c = await bootstrap.ConnectAsync(endPoint);
                list.Add(c);
                //Task<IChannel> t = bootstrap.ConnectAsync(endPoint);
                //tasks.Add(t);
            }
            return await Task.FromResult(list);
            //Task tr = Task.Factory.ContinueWhenAll(tasks.ToArray(), completedTasks =>
            //{
            //    foreach (Task<IChannel> ti in completedTasks)
            //    {
            //        _channels.Add(ti.Result);
            //    }
            //});
            //await tr;
            _isStart = true;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_channels.Any())
                    {
                        foreach (IChannel channel in _channels)
                        {
                            channel.CloseAsync().Wait(1000);
                        }
                    }
                    group.ShutdownGracefullyAsync().Wait(1000);
                }
                disposedValue = true;
            }
        }
        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
