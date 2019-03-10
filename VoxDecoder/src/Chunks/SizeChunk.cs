using System.IO;

namespace VoxDecoder.Chunks
{
    public class SizeChunk : Chunk
    {
        public const string ID = "SIZE";

        public int sizeX;
        public int sizeY;
        public int sizeZ;

        public SizeChunk(BinaryReader reader) : base(reader)
        {
            sizeX = reader.ReadInt32();
            sizeY = reader.ReadInt32();
            sizeZ = reader.ReadInt32();
        }
    }
}