using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotNettyConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RunClientAsync().Wait();
        }

        static async Task RunClientAsync()
        {
            string rIP = "192.168.207.31";
            try
            {
                IPEndPoint ep1 = new IPEndPoint(IPAddress.Parse(rIP), 43500);
                IPEndPoint ep2 = new IPEndPoint(IPAddress.Parse(rIP), 43502);
                List<IPEndPoint> endPoints = new List<IPEndPoint>() { ep1, ep2 };
                SimulatorClient client = new SimulatorClient(endPoints);
                IList<IChannel> channels = await client.ConnectAsync();
                for (; ; )
                {
                    string line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    try
                    {
                        Parallel.ForEach(channels, async (c) =>
                        {
                            await c.WriteAndFlushAsync(line + "    ");
                        });
                        //await channel.WriteAndFlushAsync(line);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if (string.Equals(line, "bye", StringComparison.OrdinalIgnoreCase))
                    {
                        Parallel.ForEach(channels, async (c) =>
                        {
                            await c.CloseAsync();
                        });
                        break;
                    }
                }
                //foreach (var c in client.Channels)
                //{
                //    await c.WriteAndFlushAsync("aabbccddeeffgg");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        //    static async Task RunClientAsync()
        //    {
        //        var group = new MultithreadEventLoopGroup();
        //        try
        //        {
        //            var bootstrap = new Bootstrap();
        //            bootstrap
        //                .Group(group)
        //                .Channel<TcpSocketChannel>()
        //                .Option(ChannelOption.TcpNodelay, true)
        //                .Handler(new ActionChannelInitializer<ISocketChannel>(channel =>
        //                {
        //                    IChannelPipeline pipeline = channel.Pipeline;
        //                    pipeline.AddLast("framing-enc", new LengthFieldPrepender(4));
        //                    pipeline.AddLast("framing-dec", new LengthFieldBasedFrameDecoder(ushort.MaxValue, 0, 4, 0, 4));
        //                    pipeline.AddLast("echo", new EchoClientHandler());
        //                }));
        //            string rIP = "192.168.207.31";
        //            IPEndPoint ep1 = new IPEndPoint(IPAddress.Parse(rIP), 43500);
        //            IChannel clientChannel = await bootstrap.ConnectAsync(ep1);

        //            Console.ReadLine();

        //            await clientChannel.CloseAsync();
        //        }
        //        finally
        //        {
        //            await group.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
        //        }
        //    }

        //    static void Main() => RunClientAsync().Wait();
        //}

        //public class EchoClientHandler : ChannelHandlerAdapter
        //{
        //    readonly IByteBuffer initialMessage;

        //    public EchoClientHandler()
        //    {
        //        this.initialMessage = Unpooled.Buffer(256);
        //        byte[] messageBytes = Encoding.UTF8.GetBytes("Hello world");
        //        this.initialMessage.WriteBytes(messageBytes);
        //    }

        //    public override void ChannelActive(IChannelHandlerContext context) => context.WriteAndFlushAsync(this.initialMessage);

        //    public override void ChannelRead(IChannelHandlerContext context, object message)
        //    {
        //        var byteBuffer = message as IByteBuffer;
        //        if (byteBuffer != null)
        //        {
        //            Console.WriteLine("Received from server: " + byteBuffer.ToString(Encoding.UTF8));
        //        }
        //        context.WriteAsync(message);
        //    }

        //    public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        //    public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        //    {
        //        Console.WriteLine("Exception: " + exception);
        //        context.CloseAsync();
        //    }
        //}
    }
}
