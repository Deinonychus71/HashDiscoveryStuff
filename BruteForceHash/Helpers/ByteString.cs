using Force.Crc32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BruteForceHash.Helpers
{
    public class ByteString
    {
        public static ConcurrentDictionary<string, uint> _optimizedValues = new ConcurrentDictionary<string, uint>();

        private readonly int _leadPrefixOffset;
        private readonly int _leadSuffixOffset;
        private readonly byte[] _prefix;
        private readonly byte[] _suffix;
        private string _prefixStr;
        private string _suffixStr;
        private bool _canBeOptimized;
        private bool _wasOptimized;
        private uint _hexToFind;
        private byte[] _value;

        public byte[] Value { get { return _value; } }

        public uint HexSearchValue { get { return _hexToFind; } }

        public int Cursor { get; set; }

        public ByteString(int length, uint hexToFind, string prefix, string suffix, bool useGlobalOptimization = false)
        {
            _prefix = Encoding.UTF8.GetBytes(prefix);
            _suffix = Encoding.UTF8.GetBytes(suffix);
            _prefixStr = prefix;
            _suffixStr = suffix;
            _leadPrefixOffset = _prefix.Length;
            _leadSuffixOffset = _suffix.Length;
            Init(length, hexToFind, useGlobalOptimization);
        }

        public ByteString(int length, uint hexToFind, byte[] prefix, byte[] suffix, bool useGlobalOptimization = false)
        {
            _prefix = prefix;
            _suffix = suffix;
            _prefixStr = Encoding.UTF8.GetString(prefix);
            _suffixStr = Encoding.UTF8.GetString(suffix);
            _leadPrefixOffset = prefix.Length;
            _leadSuffixOffset = suffix.Length;
            Init(length, hexToFind, useGlobalOptimization);
        }

        private void Init(int length, uint hexToFind, bool useGlobalOptimization = false)
        {
            _canBeOptimized = _leadPrefixOffset != 0 || _leadSuffixOffset != 0;

            if (_canBeOptimized && useGlobalOptimization)
            {
                string key = $"{_prefixStr}||{_suffixStr}";
                if (_optimizedValues.ContainsKey(key) && _optimizedValues.TryGetValue(key, out uint value))
                {
                    _hexToFind = value;
                    _canBeOptimized = false;
                    _wasOptimized = true;
                    _value = new byte[length - _leadPrefixOffset - _leadSuffixOffset];
                    return;
                }
            }

            _hexToFind = hexToFind;
            _value = new byte[length];
            if (_suffix != null && _suffix.Length > 0)
            {
                Append(_suffix, length - _leadSuffixOffset);
                Cursor = 0;
            }
            if (_prefix != null && _prefix.Length > 0)
            {
                Append(_prefix, 0);
            }
        }

        #region Append
        public void Append(string value, int position)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            Append(bytes, position);
        }

        public void Append(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            Append(bytes);
        }

        public void Append(byte[] value, int position)
        {
            value.CopyTo(_value, position);
            Cursor += value.Length;
        }

        public void Append(byte[] srcArray, int srcPosition, int length)
        {
            Buffer.BlockCopy(srcArray, srcPosition, _value, Cursor, length);
            Cursor += length;
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

        public void Replace(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            bytes.CopyTo(_value, Cursor);
        }

        public void Replace(string value, int position)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            bytes.CopyTo(_value, position);
        }

        public void Replace(byte[] bytes)
        {
            bytes.CopyTo(_value, Cursor);
        }

        public void Replace(byte[] bytes, int position)
        {
            bytes.CopyTo(_value, position);
        }

        public void Replace(byte[] srcArray, int srcPosition, int length)
        {
            Buffer.BlockCopy(srcArray, srcPosition, _value, Cursor, length);
        }

        public void Replace(byte value)
        {
            _value[Cursor] = value;
        }

        public void Replace(byte value, int position)
        {
            _value[position] = value;
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
                    Cursor = newLength - (temp.Length - Cursor) + _leadSuffixOffset;
                    _canBeOptimized = false;
                    _wasOptimized = true;
                    _optimizedValues.TryAdd($"{_prefixStr}||{_suffixStr}", _hexToFind);
                }
                return true;
            }
            return false;
        }
        #endregion

        public override string ToString()
        {
            if (_wasOptimized)
                return $"{_prefixStr}{Encoding.UTF8.GetString(_value)}{_suffixStr}";
            return Encoding.UTF8.GetString(_value);
        }
    }
}
