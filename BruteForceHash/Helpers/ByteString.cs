using Force.Crc32;
using System.Text;

namespace BruteForceHash.Helpers
{
    public class ByteString
    {
        private readonly int _leadPrefixOffset;
        private readonly int _leadSuffixOffset;
        private string _prefix;
        private string _suffix;
        private bool _canBeOptimized;
        private bool _wasOptimized;
        private uint _hexToFind;
        private byte[] _value;

        public byte[] Value { get { return _value; } }

        public int Cursor { get; set; }

        public ByteString(int length, uint hexToFind, string prefix, string suffix)
        {
            _leadPrefixOffset = prefix.Length;
            _leadSuffixOffset = suffix.Length;
            _prefix = prefix;
            _suffix = suffix;
            _canBeOptimized = _leadPrefixOffset != 0 || _leadSuffixOffset != 0;
            _hexToFind = hexToFind;
            _value = new byte[length];
            if (!string.IsNullOrEmpty(suffix))
            {
                Append(suffix, length - _leadSuffixOffset);
                Cursor = 0;
            }
            if (!string.IsNullOrEmpty(prefix))
            {
                Append(prefix, 0);
            }
        }

        #region Append
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
        #endregion

        #region Crc
        public bool CRC32Check()
        {
            var testValue = Crc32Algorithm.Compute(_value);
            if (testValue == _hexToFind)
            {
                if (_canBeOptimized)
                {
                    var temp = _value;
                    var newLength = _value.Length - _leadPrefixOffset - _leadSuffixOffset;
                    _value = new byte[newLength];
                    int j = 0;
                    for (var i = _leadPrefixOffset; i < temp.Length - _leadSuffixOffset; i++)
                    {
                        _value[j] = temp[i];
                        j++;
                    }
                    _hexToFind = Crc32Algorithm.Compute(_value);
                    Cursor = newLength;
                    _canBeOptimized = false;
                    _wasOptimized = true;
                }
                return true;
            }
            return false;
        }
        #endregion

        public override string ToString()
        {
            if (_wasOptimized)
                return $"{_prefix}{Encoding.ASCII.GetString(_value)}{_suffix}";
            return Encoding.ASCII.GetString(_value);
        }
    }
}
