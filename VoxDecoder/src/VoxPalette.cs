using System;

namespace VoxDecoder
{
    public struct VoxPalette : IEquatable<VoxPalette>
    {
        public int color;
        public byte R => (byte)((color >> 24) & 0xff);
        public byte G => (byte)((color >> 16) & 0xff);
        public byte B => (byte)((color >> 8) & 0xff);
        public byte A => (byte)((color >> 0) & 0xff);

        public VoxPalette(int color)
        {
            this.color = color;
        }

        public override int GetHashCode()
        {
            return color.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (!(other is VoxPalette)) return false;

            return Equals((VoxPalette)other);
        }

        public bool Equals(VoxPalette other)
        {
            return color.Equals(other.color);
        }
    }
}