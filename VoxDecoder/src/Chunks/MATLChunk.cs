using System;
using System.IO;
using VoxDecoder.Types;

namespace VoxDecoder.Chunks
{
    public class MATLChunk : Chunk
    {
        public const string ID = "MATL";

        public int materialId;
        public DictType materialProperties;

        public MATLChunk(BinaryReader reader) : base(reader)
        {
            materialId = reader.ReadInt32();
            materialProperties = new DictType(reader);
        }
    }
}