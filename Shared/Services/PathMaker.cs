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

        public string GetDirectoryPath()
        {
            return Directory.CreateDirectory(Path.Combine(RootPath, Service)).FullName;
        }

        public string MakePath (string filename)
        {
            return Path.Combine(GetDirectoryPath(), filename);
        }
        
    }
}
