using System.IO;

namespace VoxDecoder.Chunks
{
    public abstract class Chunk
    {
        public int contentSize;
        public int childContentSize;

        public Chunk(BinaryReader reader)
        {
            contentSize = reader.ReadInt32();
            childContentSize = reader.ReadInt32();
        }
    }
}