using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoftwareRenderer.Tests
{
    [TestClass]
    public class UnityComparison_Tests2
    {
        private Matrix4X4 _oneScale;
        private Matrix4X4 _oneScaleUnity;

        private Matrix4X4 _zeroCameraTransform;
        private Matrix4X4 _zeroCameraTransformInverse;
        private Matrix4X4 _zeroCameraTransformLocalToWorldMatrixUnity;
        private Matrix4X4 _zeroCameraTransformLocalToWorldMatrixInverseUnity;
        private Matrix4X4 _zeroCameraTransformWorldToLocalMatrixUnity;
        private Matrix4X4 _zeroCameraTransformWorldToLocalMatrixInverseUnity;

        private Matrix4X4 _cameraTransform;
        private Matrix4X4 _cameraTransformInverse;
        private Matrix4X4 _cameraProjection;
        private Matrix4X4 _cameraTransformLocalToWorldMatrixUnity;
        private Matrix4X4 _cameraTransformLocalToWorldMatrixInverseUnity;
        private Matrix4X4 _cameraTransformWorldToLocalMatrixUnity;
        private Matrix4X4 _cameraTransformWorldToLocalMatrixInverseUnity;
        private Matrix4X4 _cameraCameraToWorldMatrixUnity;
        private Matrix4X4 _cameraCameraToWorldMatrixInverseUnity;
        private Matrix4X4 _cameraWorldToCameraMatrixUnity;
        private Matrix4X4 _cameraWorldToCameraMatrixInverseUnity;
        private Matrix4X4 _cameraProjectionMatrixUnity;
        private float _cameraFarClipPlaneUnity;
        private float _cameraNearClipPlaneUnity;
        private float _cameraPixelWidthUnity;
        private float _cameraPixelHeightUnity;
        private float _cameraAspectUnity;
        private float _cameraFieldOfViewUnity;
        private Matrix4X4 _rotCubeTransform;
        private Matrix4X4 _rotCubeTransformInverse;
        private Matrix4X4 _rotCubeTransformLocalToWorldUnity;
        private Matrix4X4 _rotCubeTransformLocalToWorldInverseUnity;
        private Matrix4X4 _rotCubeTransformWorldToLocalUnity;
        private Matrix4X4 _rotCubeTransformWorldToLocalInverseUnity;

        [TestInitialize]
        public void Init()
        {
            _oneScale = Matrix4X4.CreateScale(new Vector3(1, 1, 1));
            _oneScaleUnity = _oneScaleUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));


            // ZeroCamera
            var zerocamtranslation = Matrix4X4.CreateTranslation(new Vector3(0, 0, 0));
            var zerocamrotationX = Matrix4X4.CreateRotationX(0);
            var zerocamrotationY = Matrix4X4.CreateRotationY(0);
            var zerocamrotationZ = Matrix4X4.CreateRotationZ(0);
            _zeroCameraTransform = _oneScale * zerocamtranslation * zerocamrotationX * zerocamrotationY * zerocamrotationZ;
            _zeroCameraTransformInverse = _zeroCameraTransform.Inverse();
            _zeroCameraTransformLocalToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraTransformLocalToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraTransformWorldToLocalMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraTransformWorldToLocalMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));

            // Camera
            var camtranslation = Matrix4X4.CreateTranslation(new Vector3(2.5f, 1.5f, 0));
            var camrotationX = Matrix4X4.CreateRotationX(MathHelper.ToRadians(4));
            var camrotationY = Matrix4X4.CreateRotationY(0);
            var camrotationZ = Matrix4X4.CreateRotationZ(0);
            //_cameraTransform = _oneScale * camrotationX * camrotationY * camrotationZ * camtranslation;
            _cameraTransform = _oneScale * camtranslation * camrotationZ * camrotationX * camrotationY;
            _cameraTransformInverse = _cameraTransform.Inverse();
            _cameraProjection = Matrix4X4.CreatePerspectiveFieldOfViewV3(0, 1024, 0, 768, 60.0f, 0.3f, 1000);
            _cameraTransformLocalToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, -0.06975646f, 1.5f), new Vector4(0f, 0.06975646f, 0.9975641f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _cameraTransformLocalToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975647f, -1.496346f), new Vector4(0f, -0.06975646f, 0.9975641f, 0.1046347f), new Vector4(0f, 0f, 0f, 1f));
            _cameraTransformWorldToLocalMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975646f, -1.496346f), new Vector4(0f, -0.06975646f, 0.9975641f, 0.1046347f), new Vector4(0f, 0f, 0f, 1f));
            _cameraTransformWorldToLocalMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, -0.06975647f, 1.5f), new Vector4(0f, 0.06975646f, 0.9975641f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _cameraCameraToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, 0.06975647f, 1.5f), new Vector4(0f, 0.06975646f, -0.9975641f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _cameraCameraToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975648f, -1.496346f), new Vector4(0f, 0.06975646f, -0.9975641f, -0.1046347f), new Vector4(0f, 0f, 0f, 1f));
            _cameraWorldToCameraMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975646f, -1.496346f), new Vector4(0f, 0.06975646f, -0.9975641f, -0.1046347f), new Vector4(0f, 0f, 0f, 1f));
            _cameraWorldToCameraMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, 0.06975647f, 1.5f), new Vector4(0f, 0.06975646f, -0.9975641f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _cameraProjectionMatrixUnity = new Matrix4X4(new Vector4(1.299038f, 0f, 0f, 0f), new Vector4(0f, 1.732051f, 0f, 0f), new Vector4(0f, 0f, -1.0006f, -0.60018f), new Vector4(0f, 0f, -1f, 0f));
            _cameraFarClipPlaneUnity = 1000f;
            _cameraNearClipPlaneUnity = 0.3f;
            _cameraPixelWidthUnity = 1024f;
            _cameraPixelHeightUnity = 768f;
            _cameraAspectUnity = 1.333333f;
            _cameraFieldOfViewUnity = 60f;


            // RotCube
            var rotCubeTranslation = Matrix4X4.CreateTranslation(new Vector3(0, 0, 4));
            var rotCubeRotationX = Matrix4X4.CreateRotationX(0);
            var rotCubeRotationY = Matrix4X4.CreateRotationY(MathHelper.ToRadians(38f));
            var rotCubeRotationZ = Matrix4X4.CreateRotationZ(0);
            _rotCubeTransform = _oneScale * rotCubeTranslation * rotCubeRotationZ * rotCubeRotationY * rotCubeRotationX;
            _rotCubeTransformInverse = _rotCubeTransform.Inverse();
            _rotCubeTransformLocalToWorldUnity = new Matrix4X4(new Vector4(0.7880109f, 0f, 0.6156613f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(-0.6156613f, 0f, 0.7880109f, 4f), new Vector4(0f, 0f, 0f, 1f));
            _rotCubeTransformLocalToWorldInverseUnity = new Matrix4X4(new Vector4(0.7880109f, 0f, -0.6156613f, 2.462645f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0.6156613f, 0f, 0.7880108f, -3.152043f), new Vector4(0f, 0f, 0f, 1f));
            _rotCubeTransformWorldToLocalUnity = new Matrix4X4(new Vector4(0.7880109f, 0f, -0.6156613f, 2.462645f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0.6156613f, 0f, 0.7880109f, -3.152044f), new Vector4(0f, 0f, 0f, 1f));
            _rotCubeTransformWorldToLocalInverseUnity = new Matrix4X4(new Vector4(0.7880109f, 0f, 0.6156613f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(-0.6156613f, 0f, 0.7880108f, 4f), new Vector4(0f, 0f, 0f, 1f));

        }

        [TestMethod]
        public void UnityComparison_Tests2_OneScale()
        {
            MyAssert.AreEqual_Matrix4X4(_oneScaleUnity, _oneScale);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCameraTransform()
        {
            MyAssert.AreEqual_Matrix4X4(_zeroCameraTransformLocalToWorldMatrixUnity, _zeroCameraTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_CameraTransform()
        {
            Assert.AreEqual(_cameraTransformLocalToWorldMatrixUnity, _cameraTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_CameraTransform_Inverse()
        {
            Assert.AreEqual(_cameraTransformLocalToWorldMatrixInverseUnity, _cameraTransformInverse);
        }

        [TestMethod]
        public void UnityComparison_Tests2_CameraProjection()
        {
            Assert.AreEqual(_cameraProjectionMatrixUnity, _cameraProjection);
        }
        //[TestMethod]
        //public void UnityComparison_Tests2_CameraWorldToCamera()
        //{
        //    Assert.AreEqual(_cameraWorldToCameraMatrixUnity, _cameraTransformInverse);
        //}

        //[TestMethod]
        //public void UnityComparison_Tests2_CameraWorldToCamera_Inverse()
        //{
        //    Assert.AreEqual(_cameraWorldToCameraMatrixInverseUnity, _cameraTransformInverse);
        //}

        //[TestMethod]
        //public void UnityComparison_Tests2_CameraCameraToWorld()
        //{
        //    Assert.AreEqual(_cameraCameraToWorldMatrixUnity, _cameraTransformInverse);
        //}

        //[TestMethod]
        //public void UnityComparison_Tests2_CameraCameraToWorld_Inverse()
        //{
        //    Assert.AreEqual(_cameraCameraToWorldMatrixInverseUnity, _cameraTransformInverse);
        //}

        [TestMethod]
        public void UnityComparison_Tests2_RotCubeTransformLocalToWorld()
        {
            Assert.AreEqual(_rotCubeTransformLocalToWorldUnity, _rotCubeTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_RotCubeTransformLocalToWorld_Inverse()
        {
            Assert.AreEqual(_rotCubeTransformLocalToWorldInverseUnity, _rotCubeTransformInverse);
        }

        [TestMethod]
        public void UnityComparison_Tests2_RotCubeTransformWorldToLocal()
        {
            Assert.AreEqual(_rotCubeTransformWorldToLocalUnity, _rotCubeTransformInverse);
        }

        [TestMethod]
        public void UnityComparison_Tests2_RotCubeTransformWorldToLocal_Inverse()
        {
            Assert.AreEqual(_rotCubeTransformWorldToLocalInverseUnity, _rotCubeTransform);
        }
    }

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