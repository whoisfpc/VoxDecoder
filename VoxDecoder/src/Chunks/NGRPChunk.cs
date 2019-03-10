using System.IO;
using VoxDecoder.Types;

namespace VoxDecoder.Chunks
{
    public class NGRPChunk : Chunk
    {
        public const string ID = "nGRP";

        public int nodeId;
        public DictType nodeAttributes;
        public int numChildNodes;
        public int[] childNodeIds;

        public NGRPChunk(BinaryReader reader) : base(reader)
        {
            nodeId = reader.ReadInt32();
            nodeAttributes = new DictType(reader);
            numChildNodes = reader.ReadInt32();
            childNodeIds = new int[numChildNodes];
            for (int i = 0; i < numChildNodes; i++)
            {
                childNodeIds[i] = reader.ReadInt32();
            }
        }
    }
}