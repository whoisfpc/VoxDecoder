using System;
using System.IO;
using VoxDecoder.Types;

namespace VoxDecoder.Chunks
{
    public class LAYRChunk : Chunk
    {
        public const string ID = "LAYR";

        public int layerId;
        public DictType layerAttribute;
        public int reservedId;

        public LAYRChunk(BinaryReader reader) : base(reader)
        {
            layerId = reader.ReadInt32();
            layerAttribute = new DictType(reader);
            reservedId = reader.ReadInt32();
        }
    }
}