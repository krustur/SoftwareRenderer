using System.Collections.Generic;
using System.IO;

namespace SoftwareRenderer
{
    public class ObjLoader
    {
        public IList<Mesh> Load(string objFile, string mtlFile)
        {
            var objFileContent = File.ReadAllText(objFile);
            var mtlFileContent = File.ReadAllText(mtlFile);
            var result = new ObjParser(objFileContent, mtlFileContent).Parse();

            return result;
        }
    }
}