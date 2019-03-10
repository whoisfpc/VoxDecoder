using System.IO;
using VoxDecoder.Types;

namespace VoxDecoder.Chunks
{
    public class NTRNChunk : Chunk
    {
        public const string ID = "nTRN";

        public int nodeId;
        public DictType nodeAttributes;
        public int childNodeId;
        public int  reservedId;
        public int layerId;
        public int numFrames;
        public DictType[] frames;

        public NTRNChunk(BinaryReader reader) : base(reader)
        {
            nodeId = reader.ReadInt32();
            nodeAttributes = new DictType(reader);
            childNodeId = reader.ReadInt32();
            reservedId = reader.ReadInt32();
            layerId = reader.ReadInt32();
            numFrames = reader.ReadInt32();
            frames = new DictType[numFrames];
            for (int i = 0; i < numFrames; i++)
            {
                frames[i] = new DictType(reader);
            }
        }
    }
}