using System;

namespace VoxDecoder
{
    public struct VoxColor : IEquatable<VoxColor>
    {
        public uint color;
        public byte R => (byte)((color >> 24) & 0xff);
        public byte G => (byte)((color >> 16) & 0xff);
        public byte B => (byte)((color >> 8) & 0xff);
        public byte A => (byte)((color >> 0) & 0xff);

        public VoxColor(uint color)
        {
            this.color = color;
        }

        public override int GetHashCode()
        {
            return color.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (!(other is VoxColor)) return false;

            return Equals((VoxColor)other);
        }

        public bool Equals(VoxColor other)
        {
            return color.Equals(other.color);
        }
    }
}