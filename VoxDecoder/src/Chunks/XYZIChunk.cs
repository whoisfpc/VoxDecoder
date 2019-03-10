using System.IO;

namespace VoxDecoder.Chunks
{
    public class XYZIChunk : Chunk
    {
        public const string ID = "XYZI";

        public int numVoxels;
        public Voxel[] voxels;

        public XYZIChunk(BinaryReader reader) : base(reader)
        {
            numVoxels = reader.ReadInt32();
            voxels = new Voxel[numVoxels];
            for (int i = 0; i < numVoxels; i++)
            {
                voxels[i] = new Voxel(reader.ReadInt32());
            }
        }
    }
}