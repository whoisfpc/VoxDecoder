using System.IO;

namespace VoxDecoder.Chunks
{
    public class MainChunk : Chunk
    {
        public const string ID = "MAIN";

        public MainChunk(BinaryReader reader) : base(reader)
        {
            
        }
    }
}