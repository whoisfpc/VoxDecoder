using System;
using VoxDecoder;

namespace VoxDecoderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var voxReader = new VoxReader();
            var voxFile = voxReader.ParseFile("test.vox");
            Console.WriteLine($"chunks count: {voxFile.chunks.Count}, skipedChunks: {voxFile.skipedChunks}");
        }
    }
}