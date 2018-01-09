using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetty.Codecs;
using DotNetty.Handlers.Logging;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;

namespace Tongfang.Simulator
{
    public partial class MainForm : Form
    {
        public const int DefaultPort = 43210;

        private IEventLoopGroup bossGroup;
        private IEventLoopGroup workerGroup;
        private ServerBootstrap bootstrap;
        private IChannel bootstrapChannel;

        // 通道是否准备就绪
        private bool channelIsReady = false;
        MyServerHandler myHandler;

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            textBoxPort.Text = DefaultPort.ToString();
            btnCloseChannel.Enabled = false;
        }

        private void InitBootstrap()
        {
            bossGroup = new MultithreadEventLoopGroup(1);
            workerGroup = new MultithreadEventLoopGroup();
            myHandler = new MyServerHandler();
            myHandler.Received += MyHandler_Received;
            bootstrap = new ServerBootstrap();
            bootstrap.Group(bossGroup, workerGroup)
                    .Channel<TcpServerSocketChannel>()
                    .Option(ChannelOption.SoBacklog, 100)
                    //.Handler(new LoggingHandler("SRV-LSTN"))
                    .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                    {
                        IChannelPipeline pipeline = channel.Pipeline;
                        //if (tlsCertificate != null)
                        //{
                        //    pipeline.AddLast("tls", TlsHandler.Server(tlsCertificate));
                        //}
                        //pipeline.AddLast(new LoggingHandler("SRV-CONN"));
                        pipeline.AddLast("framing-enc", new LengthFieldPrepender(4));
                        pipeline.AddLast("framing-dec", new LengthFieldBasedFrameDecoder(1000, 0, 4, 0, 4));
                        pipeline.AddLast("my-handler", myHandler);
                    }));
        }

        private void MyHandler_Received(object sender, MessageEventArgs e)
        {
            HandleMessage(e.Message);
        }

        private void HandleMessage(MessageData message)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Head: ").Append(message.Head.FirstByte).Append(" ").Append(message.Head.TypeByte).AppendLine();
            builder.Append("BodyLenth: ").Append(message.Body.Length).AppendLine();
            builder.Append(message.Body.ToString(Encoding.UTF8));
            if (richTextBoxReceive.InvokeRequired)
            {
                richTextBoxReceive.Invoke(new Action(() =>
                {
                    AppendTextAndLine(richTextBoxReceive, builder.ToString());
                }));
            }
            else
            {
                AppendTextAndLine(richTextBoxReceive, builder.ToString());
            }
        }

        private void AppendTextAndLine(RichTextBox richTextBox, string text)
        {
            int max = richTextBox.MaxLength - 10;
            if (richTextBox.TextLength + text.Length > max)
            {
                richTextBox.Clear();
            }
            richTextBox.AppendText(text);
            richTextBox.AppendText(Environment.NewLine);
        }

        private void HandleException(Exception ex)
        {
            if (richTextBoxError.InvokeRequired)
            {
                richTextBoxError.Invoke(new Action(() =>
                {
                    AppendTextAndLine(richTextBoxError, ex.ToString());
                }));
            }
            else
            {
                AppendTextAndLine(richTextBoxError, ex.ToString());
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitBootstrap();
        }

        private async void btnStartupChannel_Click(object sender, EventArgs e)
        {
            await StartupAsync();
        }
        private async Task StartupAsync()
        {
            if (bootstrap == null || channelIsReady)
            {
                return;
            }
            try
            {
                int port;
                if (!int.TryParse(textBoxPort.Text, out port))
                {
                    port = DefaultPort;
                }

                IPAddress ip;
                string ipStr = textBoxIP.Text.Trim();
                if (ipStr == "*")
                {
                    ip = IPAddress.Any;
                }
                ip = IPAddress.Parse(textBoxIP.Text);
                bootstrapChannel = await bootstrap.BindAsync(ip, port);
                channelIsReady = true;
                // 修改界面状态
                btnStartupChannel.Enabled = false;
                btnCloseChannel.Enabled = true;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private async Task CloseAsync()
        {
            if (bootstrapChannel == null || !channelIsReady)
            {
                return;
            }
            else
            {
                await bootstrapChannel?.CloseAsync();
                channelIsReady = false;
            }
            // 修改界面状态
            btnStartupChannel.Enabled = true;
            btnCloseChannel.Enabled = false;
        }

        private async void btnCloseChannel_Click(object sender, EventArgs e)
        {
            await CloseAsync();
        }

        private void btnClearReceive_Click(object sender, EventArgs e)
        {
            richTextBoxReceive.Clear();
        }

        private void btnClearError_Click(object sender, EventArgs e)
        {
            richTextBoxError.Clear();
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                List<Task> tasks = new List<Task>();
                if (bossGroup != null)
                {
                    tasks.Add(bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
                }
                if (workerGroup != null)
                {
                    tasks.Add(workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
                }
                if (tasks.Any())
                {
                    Task.WhenAll(tasks);
                }
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await CloseAsync();
        }
    }
}
