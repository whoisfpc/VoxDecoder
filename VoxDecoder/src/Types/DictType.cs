using System;
using System.IO;

namespace VoxDecoder.Types
{
    public class DictType
    {
        public int count;
        public Tuple<StringType, StringType>[] pairs;

        public DictType(BinaryReader reader)
        {
            count = reader.ReadInt32();
            pairs = new Tuple<StringType, StringType>[count];
            for (int i = 0; i < count; i++)
            {
                var key = new StringType(reader);
                var value = new StringType(reader);
                pairs[i] = Tuple.Create(key, value);
            }
        }
    }
}