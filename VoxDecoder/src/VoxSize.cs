using System;

namespace VoxDecoder
{
    public struct VoxSize : IEquatable<VoxSize>
    {
        public int x, y, z;

        public VoxSize(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
        }

        public override bool Equals(object other)
        {
            if (!(other is VoxSize)) return false;

            return Equals((VoxSize)other);
        }

        public bool Equals(VoxSize other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z);
        }
    }
}