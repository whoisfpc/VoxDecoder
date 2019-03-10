using System.IO;

namespace VoxDecoder.Types
{
    public class StringType
    {
        public int bufferSize;
        public char[] buffer;

        public StringType(BinaryReader reader)
        {
            bufferSize = reader.ReadInt32();
            buffer = reader.ReadChars(bufferSize);
        }
    }
}