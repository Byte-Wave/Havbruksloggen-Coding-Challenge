namespace Havbruksloggen_Coding_Challenge.Shared.Services
{

    public class PathMaker
    {
        public readonly string RootPath;
        public string Service { get; set; }

        public PathMaker(string rootPath)
        {
            RootPath = rootPath;
        }

        public string MakePath (string filename)
        {
            var directoryInfo = Directory.CreateDirectory(Path.Combine(RootPath, Service));
            return Path.Combine(directoryInfo.FullName, filename);
        }
        
    }
}
