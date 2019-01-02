using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoftwareRenderer.Tests
{
    [TestClass]
    public class Vector3_Tests
    {
        private float _dot;
        private Vector3 _cross;
        private Vector3 _proj;

        [TestInitialize]
        public void Init()
        {
            var p = new Vector3(2, 2, 1);
            var q = new Vector3 { X = 1, Y = -2, Z = 0 };
            _dot = Vector3.Dot(p, q);
            _cross = Vector3.Cross(p, q);
            _proj = Vector3.Proj(q, p);

            // Coverage for .X, .Y and .Z
            //var www = new Vector3 {Y = -2}; 
            //var xxx = new Vector3 {Z = 0};
            //xxx.X = 1;

        }

        [TestMethod]
        public void Vector3_Tests_Dot()
        {
            Assert.AreEqual(-2f, _dot);
        }

        [TestMethod]
        public void Vector3_Tests_Cross()
        {
            Assert.AreEqual(2f, _cross.X);
            Assert.AreEqual(1f, _cross.Y);
            Assert.AreEqual(-6f, _cross.Z);
        }

        [TestMethod]
        public void Vector3_Tests_Proj()
        {
            Assert.AreEqual(-(4f / 9f), _proj.X);
            Assert.AreEqual(-(4f / 9f), _proj.Y);
            Assert.AreEqual(-(2f / 9f), _proj.Z);
        }
    }
}