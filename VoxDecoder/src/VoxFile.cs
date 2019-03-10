using System.Collections.Generic;
using VoxDecoder.Chunks;

namespace VoxDecoder
{
    public class VoxFile
    {
        public static readonly char[] magic = {'V', 'O', 'X', ' '};

        public int version;

        public List<Chunk> chunks = new List<Chunk>();
        public List<SizeChunk> sizeChunks = new List<SizeChunk>();
        public List<XYZIChunk> xyziChunks = new List<XYZIChunk>();
        public List<NTRNChunk> nTRNChunks = new List<NTRNChunk>();
        public List<NGRPChunk> nGRPChunks = new List<NGRPChunk>();
        public List<NSHPChunk> nSHPChunks = new List<NSHPChunk>();

        public void AddChunk(MainChunk chunk)
        {
            chunks.Add(chunk);
        }

        public void AddChunk(SizeChunk chunk)
        {
            chunks.Add(chunk);
            sizeChunks.Add(chunk);
        }

        public void AddChunk(XYZIChunk chunk)
        {
            chunks.Add(chunk);
            xyziChunks.Add(chunk);
        }
        
        public void AddChunk(NTRNChunk chunk)
        {
            chunks.Add(chunk);
            nTRNChunks.Add(chunk);
        }

        public void AddChunk(NGRPChunk chunk)
        {
            chunks.Add(chunk);
            nGRPChunks.Add(chunk);
        }

        public void AddChunk(NSHPChunk chunk)
        {
            chunks.Add(chunk);
            nSHPChunks.Add(chunk);
        }
    }
}