namespace VoxDecoder
{
    public class VoxModel
    {
        public VoxSize size;

        public int SizeX => size.x;
        public int SizeY => size.y;
        public int SizeZ => size.z;

        public Voxel[] voxels;
    }
}