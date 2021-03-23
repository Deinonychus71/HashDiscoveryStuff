using System.Text;

namespace BruteForceHash.Helpers
{
    public class ByteString
    {
        private readonly byte[] _value;

        public byte[] Value { get { return _value; } }

        public int Cursor { get; set; }

        public ByteString(int length)
        {
            _value = new byte[length];
        }

        public void Append(string value, int position)
        {
            var bytes = Encoding.ASCII.GetBytes(value);
            Append(bytes, position);
        }

        public void Append(string value)
        {
            var bytes = Encoding.ASCII.GetBytes(value);
            Append(bytes);
        }

        public void Append(byte[] value, int position)
        {
            value.CopyTo(_value, position);
            Cursor += value.Length;
        }

        public void Append(byte[] value)
        {
            value.CopyTo(_value, Cursor);
            Cursor += value.Length;
        }

        public void Append(byte value, int position)
        {
            _value[position] = value;
            Cursor++;
        }

        public void Append(byte value)
        {
            _value[Cursor] = value;
            Cursor++;
        }

        public override string ToString()
        {
            return Encoding.ASCII.GetString(_value);
        }
    }
}
