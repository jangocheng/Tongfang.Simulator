using System;
using System.Text;

namespace Tongfang.Simulator
{
    public class MessageHead
    {
        public byte FirstByte { get; set; }
        public byte TypeByte { get; set; }
    }
    public class MessageBody
    {
        private byte[] _array;
        public MessageBody(byte[] array)
        {
            _array = array;
        }
        public byte[] Array
        {
            get { return _array; }
        }

        public int Length
        {
            get { return _array.Length; }
        }

        public string ToString(Encoding encoding)
        {
            return encoding.GetString(_array);
        }

        public string ToString(Encoding encoding, int index, int count)
        {
            return encoding.GetString(_array, index, count);
        }
    }
    public class MessageData
    {
        private MessageHead _head;
        private MessageBody _body;

        public MessageData(MessageHead head, MessageBody body)
        {
            _head = head ?? throw new ArgumentNullException(nameof(head));
            _body = body ?? throw new ArgumentNullException(nameof(body));
        }

        public MessageHead Head { get => _head; set => _head = value; }
        public MessageBody Body { get => _body; set => _body = value; }
    }
}
