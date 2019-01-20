using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoftwareRenderer.Tests
{
    [TestClass]
    public class FbxParser_Tests
    {
        private IList<Mesh> _result;

        [TestInitialize]
        public void Init()
        {
            var parser = new FbxParser(GetFbxFile());

            _result = parser.Parse();

        }

        private Stream GetFbxFile()
        {
            var resourceArray = ResourceHelper.ExtractResource("SoftwareRenderer.Tests.DungeonTiles_embedded_png.fbx");
            var stream = new MemoryStream(resourceArray);
            return stream;
        }

       
        [TestMethod]
        public void ObjParser_Tests_MeshCount()
        {
            Assert.AreEqual(0, _result.Count);
        }

       
    }

    public class FbxParser
    {
        private readonly byte[] _fbxFile;

        public FbxParser(byte[] fbxFile)
        {
            _fbxFile = fbxFile;
        }

        public IList<Mesh> Parse()
        {
            var result = new List<Mesh>();

            var i = _fbxFile[0];

            return result;
        }
    }
}