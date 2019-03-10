using System.IO;

namespace VoxDecoder.Chunks
{
    public class RGBAChunk : Chunk
    {
        public const string ID = "RGBA";

        public VoxColor[] colors = new VoxColor[256];

        public RGBAChunk(BinaryReader reader) : base(reader)
        {
            for (int i = 0; i < 255; i++)
            {
                colors[i + 1] = new VoxColor(reader.ReadUInt32());
            }
            colors[0] = new VoxColor(reader.ReadUInt32());
        }
    }
}