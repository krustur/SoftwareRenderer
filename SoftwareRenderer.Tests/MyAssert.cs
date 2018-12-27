using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoftwareRenderer.Tests
{
    public class MyAssert
    {
        internal static void AreEqual_Matrix4X4(Matrix4X4 expected, Matrix4X4 actual)
        {
            Assert.AreEqual(expected[0][0], actual[0][0]);
            Assert.AreEqual(expected[0][1], actual[0][1]);
            Assert.AreEqual(expected[0][2], actual[0][2]);
            Assert.AreEqual(expected[0][3], actual[0][3]);
            Assert.AreEqual(expected[1][0], actual[1][0]);
            Assert.AreEqual(expected[1][1], actual[1][1]);
            Assert.AreEqual(expected[1][2], actual[1][2]);
            Assert.AreEqual(expected[1][3], actual[1][3]);
            Assert.AreEqual(expected[2][0], actual[2][0]);
            Assert.AreEqual(expected[2][1], actual[2][1]);
            Assert.AreEqual(expected[2][2], actual[2][2]);
            Assert.AreEqual(expected[2][3], actual[2][3]);
            Assert.AreEqual(expected[3][0], actual[3][0]);
            Assert.AreEqual(expected[3][1], actual[3][1]);
            Assert.AreEqual(expected[3][2], actual[3][2]);
            Assert.AreEqual(expected[3][3], actual[3][3]);
        }
    }
}