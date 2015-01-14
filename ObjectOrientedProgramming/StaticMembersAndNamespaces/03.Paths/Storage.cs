using System;
using System.IO;
using System.Runtime.Serialization;

namespace _03.Paths
{
    public static class Storage
    {
        public const string FILE_NAME = "paths.xml";

        private static DataContractSerializer serializer = new DataContractSerializer(typeof(Path3DWrapper));

        public static void SavePath(params Path3D[] paths)
        {
            var wrapper = new Path3DWrapper();
            if (File.Exists(FILE_NAME))
            {
                wrapper.Paths.AddRange(LoadPaths());
            }
            wrapper.Paths.AddRange(paths);

            using (var outputFile = File.Open(FILE_NAME, FileMode.Create))
            {
                serializer.WriteObject(outputFile, wrapper);
            }
        }

        public static Path3D[] LoadPaths()
        {
            try
            {
                using (var inputFile = File.OpenRead(FILE_NAME))
                {
                    return ((Path3DWrapper)serializer.ReadObject(inputFile)).Paths.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Path3D[0];
            }
        }
    }
}