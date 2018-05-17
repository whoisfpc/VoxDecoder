using System;

namespace VoxDecoder
{
    public struct Voxel : IEquatable<Voxel>
    {
        public int vox;
        public byte X => (byte)((vox >> 24) & 0xff);
        public byte Y => (byte)((vox >> 16) & 0xff);
        public byte Z => (byte)((vox >> 8) & 0xff);
        public byte I => (byte)((vox >> 0) & 0xff);

        public Voxel(int vox)
        {
            this.vox = vox;
        }

        public override int GetHashCode()
        {
            return vox.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (!(other is Voxel)) return false;

            return Equals((Voxel)other);
        }

        public bool Equals(Voxel other)
        {
            return vox.Equals(other.vox);
        }
    }
}