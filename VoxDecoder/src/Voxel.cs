using System;

namespace VoxDecoder
{
    public struct Voxel : IEquatable<Voxel>
    {
        public int x, y, z;
        public int colorIndex;

        public Voxel(int x, int y, int z, int colorIndex)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.colorIndex = colorIndex;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2) ^ (colorIndex.GetHashCode() >> 1);
        }

        public override bool Equals(object other)
        {
            if (!(other is Voxel)) return false;

            return Equals((Voxel)other);
        }

        public bool Equals(Voxel other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z) && colorIndex.Equals(other.colorIndex);
        }
    }
}