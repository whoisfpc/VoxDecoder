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
                    case NGRPChunk.ID:
                        voxFile.AddChunk(new NGRPChunk(reader));
                        break;
                    case NSHPChunk.ID:
                        voxFile.AddChunk(new NSHPChunk(reader));
                        break;
                    case MATLChunk.ID:
                        voxFile.AddChunk(new MATLChunk(reader));
                        break;
                    case LAYRChunk.ID:
                        voxFile.AddChunk(new LAYRChunk(reader));
                        break;
                    case RGBAChunk.ID:
                        voxFile.AddChunk(new RGBAChunk(reader));
                        break;
                    case ROBJChunk.ID:
                        voxFile.AddChunk(new ROBJChunk(reader));
                        break;
                    default:
                        // SKIP unknow chunk
                        // TODO: throw exception
                        MainChunk chunk = new MainChunk(reader);
                        reader.ReadBytes(chunk.contentSize);
                        voxFile.skipedChunks++;
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