using System.IO;
using VoxDecoder.Chunks;

namespace VoxDecoder
{
    public class VoxReader
    {
        public VoxFile ParseFile(string filePath)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(filePath)))
            {
                return ParseStream(reader);
            }
        }

        public VoxFile ParseStream(BinaryReader reader)
        {
            if (!ValidMagicNumber(reader))
            {
                return null;
            }

            var version = reader.ReadInt32();
            if (version != 150)
            {
                return null;
            }

            var voxFile = new VoxFile();
            voxFile.version = version;
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                string ID = ReadID(reader);
                switch (ID)
                {
                    case MainChunk.ID:
                        voxFile.AddChunk(new MainChunk(reader));
                        break;
                    case SizeChunk.ID:
                        voxFile.AddChunk(new SizeChunk(reader));
                        break;
                    case XYZIChunk.ID:
                        voxFile.AddChunk(new XYZIChunk(reader));
                        break;
                    case NTRNChunk.ID:
                        voxFile.AddChunk(new NTRNChunk(reader));
                        break;
                    default:
                        MainChunk chunk = new MainChunk(reader);
                        reader.ReadBytes(chunk.contentSize);
                        //return voxFile;
                        break;
                }
            }

            return voxFile;
        }
        
        private string ReadID(BinaryReader reader)
        {
            var ID = reader.ReadChars(4);
            return new string(ID);
        }

        private bool ValidMagicNumber(BinaryReader reader)
        {
            var magic = reader.ReadChars(VoxFile.magic.Length);
            for (var i = 0; i < magic.Length; i++)
            {
                if (magic[i] != VoxFile.magic[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}