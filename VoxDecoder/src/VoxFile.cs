namespace VoxDecoder
{
    public class VoxFile
    {
        public static readonly char[] magic = {'V', 'O', 'X', ' '};

        public int version;

        public int ModelCount => models == null ? 0 : models.Length;

        public VoxModel[] models;

        public VoxPalette palette;
    }
}