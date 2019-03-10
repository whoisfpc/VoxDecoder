using System;
using System.IO;
using VoxDecoder.Types;

namespace VoxDecoder.Chunks
{
    public class ROBJChunk : Chunk
    {
        public const string ID = "rOBJ";

        public DictType properties;

        public ROBJChunk(BinaryReader reader) : base(reader)
        {
            properties = new DictType(reader);
        }
    }
}