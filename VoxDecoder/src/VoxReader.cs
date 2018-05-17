using System.IO;

namespace VoxDecoder
{
    public class VoxReader
    {
        private class ChuckHeader
        {
            public string Id;
            public int contentBytes;
            public int childContentBytes;
        }

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

            var mainHeader = ReadChunkHeader(reader);
            if (mainHeader.Id != "MAIN")
            {
                return null;
            }

            int byteRemain = mainHeader.childContentBytes;
            int currentModelIdx = -1;

            while (byteRemain > 0)
            {
                var chunkHeader = ReadChunkHeader(reader);
                byteRemain -= 12;

                switch (chunkHeader.Id)
                {
                    case "PACK":
                        var modelCount = reader.ReadInt32();
                        voxFile.models = new VoxModel[modelCount];
                        for (var i = 0; i < voxFile.ModelCount; i++)
                        {
                            voxFile.models[i] = new VoxModel();
                        }
                        break;
                    case "SIZE":
                        currentModelIdx++;
                        if (voxFile.models == null)
                        {
                            voxFile.models = new VoxModel[1];
                            voxFile.models[0] = new VoxModel();
                        }
                        var size = new VoxSize(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
                        voxFile.models[currentModelIdx].size = size;
                        break;
                    case "XYZI":
                        var voxNumber = reader.ReadInt32();
                        voxFile.models[currentModelIdx].voxels = new Voxel[voxNumber];
                        for (var i = 0; i < voxNumber; i++)
                        {
                            voxFile.models[currentModelIdx].voxels[i] = new Voxel(reader.ReadInt32());
                        }
                        break;
                    case "RGBA":
                        voxFile.palette = new VoxPalette();
                        for (var i = 0; i < 255; i++)
                        {
                            voxFile.palette.colors[i + 1] = new VoxColor(reader.ReadUInt32());
                        }
                        voxFile.palette.colors[0] = new VoxColor(reader.ReadUInt32());
                        break;
                    default:
                        reader.ReadBytes(chunkHeader.contentBytes);
                        reader.ReadBytes(chunkHeader.childContentBytes);
                        break;
                }

                byteRemain -= chunkHeader.contentBytes + chunkHeader.childContentBytes;
            }
            if (voxFile.palette == null)
            {
                voxFile.palette = VoxPalette.GetDefaultPalette();
            }
            return voxFile;
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

        private ChuckHeader ReadChunkHeader(BinaryReader reader)
        {
            ChuckHeader header = new ChuckHeader();
            header.Id = new string(reader.ReadChars(4));
            header.contentBytes = reader.ReadInt32();
            header.childContentBytes = reader.ReadInt32();
            return header;
        }
    }
}