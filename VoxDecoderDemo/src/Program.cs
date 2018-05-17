using System;
using VoxDecoder;

namespace VoxDecoderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var voxReader = new VoxReader();
            var voxFile = voxReader.ParseFile("3x3x3_new.vox");

            Console.WriteLine("VoxFile versio: {0}", voxFile.version);
            Console.WriteLine("Model count: {0}", voxFile.ModelCount);

            for (var i = 0; i < voxFile.ModelCount; i++)
            {
                var model = voxFile.models[i];
                Console.WriteLine("Model : {0}, Size: ({1}, {2}, {3})", i, model.size.x, model.size.y, model.size.z);
            }
        }
    }
}