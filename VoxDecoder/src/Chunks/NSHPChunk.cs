using System;
using System.IO;
using VoxDecoder.Types;

namespace VoxDecoder.Chunks
{
    public class NSHPChunk : Chunk
    {
        public const string ID = "nSHP";

        public int nodeId;
        public DictType nodeAttributes;
        public int numModels;
        public Tuple<int, DictType>[] models;

        public NSHPChunk(BinaryReader reader) : base(reader)
        {
            nodeId = reader.ReadInt32();
            nodeAttributes = new DictType(reader);
            numModels = reader.ReadInt32();
            models = new Tuple<int, DictType>[numModels];
            for (int i = 0; i < numModels; i++)
            {
                var modelId = reader.ReadInt32();
                var modelAttributes = new DictType(reader);
                models[i] = Tuple.Create(modelId, modelAttributes);
            }
        }
    }
}