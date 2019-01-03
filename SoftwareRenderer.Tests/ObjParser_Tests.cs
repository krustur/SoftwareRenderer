using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable StringLiteralTypo

namespace SoftwareRenderer.Tests
{
    [TestClass]
    public class ObjParser_Tests
    {
        private IList<Mesh> _result;

        [TestInitialize]
        public void Init()
        {
            var parser = new ObjParser(GetObjFile(), GetMtlFile());

            _result = parser.Parse();

        }

        private string GetObjFile()
        {
            return @"# Blender v2.79 (sub 0) OBJ File: 'test.blend'
# www.blender.org
mtllib test.mtl
o Cube
v 1.000000 -1.000000 -1.000000
v 1.000000 -1.300000 1.000000
v -1.000000 -1.000000 1.000000
v -1.000000 -1.000000 -1.000000
v 1.000000 1.000000 -0.999999
v 0.999999 1.000000 1.000001
v -1.000000 1.000000 1.000000
v -1.000000 1.000000 -1.100000
vn 0.0000 -1.0000 0.0000
vn 0.0000 1.0000 0.0000
vn 1.0000 -0.0000 0.0000
vn 0.0000 -0.0000 1.0000
vn -1.0000 -0.0000 -0.0000
vn 0.0000 0.0000 -1.0000
usemtl Material
s off
f 2//1 4//1 1//1
f 8//2 6//2 5//2
f 5//3 2//3 1//3
f 6//4 3//4 2//4
f 3//5 8//5 4//5
f 1//6 8//6 5//6
f 2//1 3//1 4//1
f 8//2 7//2 6//2
f 5//3 6//3 2//3
f 6//4 7//4 3//4
f 3//5 7//5 8//5
f 1//6 4//6 8//6
";
        }

        private string GetMtlFile()
        {
            return @"# Blender MTL File: 'test.blend'
# Material Count: 1

newmtl Material
Ns 96.078431
Ka 1.000000 1.000000 1.000000
Kd 0.640000 0.650000 0.660000
Ks 0.500000 0.500000 0.500000
Ke 0.000000 0.000000 0.000000
Ni 1.000000
d 1.000000
illum 2
";
        }

        [TestMethod]
        public void ObjParser_Tests_MeshCount()
        {
            Assert.AreEqual(1, _result.Count);
        }

        [TestMethod]
        public void ObjParser_Tests_Mesh1_Name()
        {
            Assert.AreEqual("Cube", _result[0].Name);
        }

        [TestMethod]
        public void ObjParser_Tests_Vertex_Count()
        {
            Assert.AreEqual(8, _result[0].Vertices.Length);
        }


        [TestMethod]
        public void ObjParser_Tests_FirstVertex_X()
        {
            Assert.AreEqual(1.0000f, _result[0].Vertices[0].X);
        }

        [TestMethod]
        public void ObjParser_Tests_SecondVertex_Y()
        {
            Assert.AreEqual(-1.3000f, _result[0].Vertices[1].Y);
        }

        [TestMethod]
        public void ObjParser_Tests_EigthVertex_Z()
        {
            Assert.AreEqual(-1.1000f, _result[0].Vertices[7].Z);
        }

        [TestMethod]
        public void ObjParser_Tests_Indices_Count()
        {
            Assert.AreEqual(36, _result[0].Indices.Length);
        }

        [TestMethod]
        public void ObjParser_Tests_Face1_Index1()
        {
            Assert.AreEqual(1L, _result[0].Indices[0]);
        }

        [TestMethod]
        public void ObjParser_Tests_Face2_Index2()
        {
            Assert.AreEqual(5L, _result[0].Indices[4]);
        }

        [TestMethod]
        public void ObjParser_Tests_Face12_Index3()
        {
            Assert.AreEqual(7L, _result[0].Indices[35]);
        }

        [TestMethod]
        public void ObjParser_Tests_Material_Name()
        {
            Assert.AreEqual("Material", _result[0].Material.Name);
        }

        [TestMethod]
        public void ObjParser_Tests_Material_Diffuse_R()
        {
            Assert.AreEqual(0.64f, _result[0].Material.Diffuse.X);
        }

        [TestMethod]
        public void ObjParser_Tests_Material_Diffuse_G()
        {
            Assert.AreEqual(0.65f, _result[0].Material.Diffuse.Y);
        }

        [TestMethod]
        public void ObjParser_Tests_Material_Diffuse_B()
        {
            Assert.AreEqual(0.66f, _result[0].Material.Diffuse.Z);
        }

    }
}