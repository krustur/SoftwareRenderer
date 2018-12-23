using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoftwareRenderer.Tests
{
    [TestClass]
    public class UnityComparison_Tests
    {
        private Matrix4X4 _rotX03;
        private Matrix4X4 _rotX03Ref;
        private Matrix4X4 _rotY03;
        private Matrix4X4 _rotY03Ref;
        private Matrix4X4 _rotZ03;
        private Matrix4X4 _rotZ03Ref;
        private Matrix4X4 _scal345;
        private Matrix4X4 _scal345Ref;
        private Matrix4X4 _translate345;
        private Matrix4X4 _translate345Ref;
        private Matrix4X4 _transform;
        private Matrix4X4 _transformRef;
        private Matrix4X4 _perspFov;
        private Matrix4X4 _perspFovRef;
        private Matrix4X4 _inverseIdentity;
        private Matrix4X4 _inverseIdentityRef;

        //Matrix4X4

        [TestInitialize]
        public void Init()
        {
            _rotX03 = Matrix4X4.CreateRotationX(0.3f);
            //_rotX03Ref = Matrix4X4.Transpose(Matrix4X4.CreateRotationX(0.3f));
            _rotY03 = Matrix4X4.CreateRotationY(0.3f);
            //_rotY03Ref = Matrix4X4.Transpose(Matrix4X4.CreateRotationY(0.3f));
            _rotZ03 = Matrix4X4.CreateRotationZ(0.3f);
            //_rotZ03Ref = Matrix4X4.Transpose(Matrix4X4.CreateRotationZ(0.3f));
            _scal345 = Matrix4X4.CreateScale(new Vector3(3, 4, 5));
            //_scal345Ref = Matrix4X4.Transpose(Matrix4X4.CreateScale(3, 4, 5));
            _translate345 = Matrix4X4.CreateTranslation(new Vector3(3, 4, 5));
            _translate345Ref = new Matrix4X4(
                new Vector4(1.0f, 0.0f, 0.0f, 3.0f), 
                new Vector4(0.0f, 1.0f, 0.0f, 4.0f),
                new Vector4(0.0f, 0.0f, 1.0f, 5.0f), 
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f));

          


            _transform = _scal345 * _rotX03 * _rotY03 * _rotZ03 * _translate345;
            _transformRef = _scal345Ref * _rotX03Ref * _rotY03Ref * _rotZ03Ref * _translate345Ref;

            var fov = 1.0472f;
            var aspectRatio = (float) 640 / 480;
            _perspFov = Matrix4X4.CreatePerspectiveFieldOfView(1.0472f, aspectRatio, 0.3f, 1000f);
            _perspFovRef = new Matrix4X4(
                new Vector4(82.1f,  0.0f,   0.0f,   0.0f),
                new Vector4(0.0f,   109.4f, 0.0f,   0.0f),
                new Vector4(0.0f,   0.0f,   -1.0f,  -0.6f),
                new Vector4(0.0f,   0.0f,   -1.0f,  0.0f));
            _perspFovRef = new Matrix4X4(
                new Vector4(1.3f, 0.0f, 0.0f, 0.0f),
                new Vector4(0.0f, 1.7f, 0.0f, 0.0f),
                new Vector4(0.0f, 0.0f, -1.0f, -0.6f),
                new Vector4(0.0f, 0.0f, -1.0f, 0.0f));
            _inverseIdentity = _transform.Inverse();
            //Matrix4X4.Invert(_transformRef, out _inverseIdentityRef);
            //_inverseIdentityRef = Matrix4X4.Transpose(_inverseIdentityRef);
            //DirectX::XMMATRIX P = DirectX::XMMatrixPerspectiveFovLH(1.0472f, _renderer->GetAspectRatio(), 0.3f, 1000.0f);
            //XMStoreFloat4x4(&_projectionMatrix, P);
            //System.Numerics.Matrix4X4.
            //var pos = new UnityEngine.Vector3(0, 0, 0);
            //var q = Quaternion.identity;
            //_trs = UnityEngine.Matrix4X4.TRS(pos, q, UnityEngine.Vector3.forward);
        }

        //[TestMethod]
        //public void UnityComparison_Tests_RotationX03()
        //{
        //    Assert.AreEqual(_rotX03Ref.M11, _rotX03[0][0]);
        //    Assert.AreEqual(_rotX03Ref.M12, _rotX03[0][1]);
        //    Assert.AreEqual(_rotX03Ref.M13, _rotX03[0][2]);
        //    Assert.AreEqual(_rotX03Ref.M14, _rotX03[0][3]);
        //    Assert.AreEqual(_rotX03Ref.M21, _rotX03[1][0]);
        //    Assert.AreEqual(_rotX03Ref.M22, _rotX03[1][1]);
        //    Assert.AreEqual(_rotX03Ref.M23, _rotX03[1][2]);
        //    Assert.AreEqual(_rotX03Ref.M24, _rotX03[1][3]);
        //    Assert.AreEqual(_rotX03Ref.M31, _rotX03[2][0]);
        //    Assert.AreEqual(_rotX03Ref.M32, _rotX03[2][1]);
        //    Assert.AreEqual(_rotX03Ref.M33, _rotX03[2][2]);
        //    Assert.AreEqual(_rotX03Ref.M34, _rotX03[2][3]);
        //    Assert.AreEqual(_rotX03Ref.M41, _rotX03[3][0]);
        //    Assert.AreEqual(_rotX03Ref.M42, _rotX03[3][1]);
        //    Assert.AreEqual(_rotX03Ref.M43, _rotX03[3][2]);
        //    Assert.AreEqual(_rotX03Ref.M44, _rotX03[3][3]);
        //}

        //[TestMethod]
        //public void UnityComparison_Tests_RotationY03()
        //{
        //    Assert.AreEqual(_rotY03Ref.M11, _rotY03[0][0]);
        //    Assert.AreEqual(_rotY03Ref.M12, _rotY03[0][1]);
        //    Assert.AreEqual(_rotY03Ref.M13, _rotY03[0][2]);
        //    Assert.AreEqual(_rotY03Ref.M14, _rotY03[0][3]);
        //    Assert.AreEqual(_rotY03Ref.M21, _rotY03[1][0]);
        //    Assert.AreEqual(_rotY03Ref.M22, _rotY03[1][1]);
        //    Assert.AreEqual(_rotY03Ref.M23, _rotY03[1][2]);
        //    Assert.AreEqual(_rotY03Ref.M24, _rotY03[1][3]);
        //    Assert.AreEqual(_rotY03Ref.M31, _rotY03[2][0]);
        //    Assert.AreEqual(_rotY03Ref.M32, _rotY03[2][1]);
        //    Assert.AreEqual(_rotY03Ref.M33, _rotY03[2][2]);
        //    Assert.AreEqual(_rotY03Ref.M34, _rotY03[2][3]);
        //    Assert.AreEqual(_rotY03Ref.M41, _rotY03[3][0]);
        //    Assert.AreEqual(_rotY03Ref.M42, _rotY03[3][1]);
        //    Assert.AreEqual(_rotY03Ref.M43, _rotY03[3][2]);
        //    Assert.AreEqual(_rotY03Ref.M44, _rotY03[3][3]);
        //}

        //[TestMethod]
        //public void UnityComparison_Tests_RotationZ3()
        //{
        //    Assert.AreEqual(_rotZ03Ref.M11, _rotZ03[0][0]);
        //    Assert.AreEqual(_rotZ03Ref.M12, _rotZ03[0][1]);
        //    Assert.AreEqual(_rotZ03Ref.M13, _rotZ03[0][2]);
        //    Assert.AreEqual(_rotZ03Ref.M14, _rotZ03[0][3]);
        //    Assert.AreEqual(_rotZ03Ref.M21, _rotZ03[1][0]);
        //    Assert.AreEqual(_rotZ03Ref.M22, _rotZ03[1][1]);
        //    Assert.AreEqual(_rotZ03Ref.M23, _rotZ03[1][2]);
        //    Assert.AreEqual(_rotZ03Ref.M24, _rotZ03[1][3]);
        //    Assert.AreEqual(_rotZ03Ref.M31, _rotZ03[2][0]);
        //    Assert.AreEqual(_rotZ03Ref.M32, _rotZ03[2][1]);
        //    Assert.AreEqual(_rotZ03Ref.M33, _rotZ03[2][2]);
        //    Assert.AreEqual(_rotZ03Ref.M34, _rotZ03[2][3]);
        //    Assert.AreEqual(_rotZ03Ref.M41, _rotZ03[3][0]);
        //    Assert.AreEqual(_rotZ03Ref.M42, _rotZ03[3][1]);
        //    Assert.AreEqual(_rotZ03Ref.M43, _rotZ03[3][2]);
        //    Assert.AreEqual(_rotZ03Ref.M44, _rotZ03[3][3]);
        //}

        //[TestMethod]
        //public void UnityComparison_Tests_Scale345()
        //{
        //    Assert.AreEqual(_scal345Ref.M11, _scal345[0][0]);
        //    Assert.AreEqual(_scal345Ref.M12, _scal345[0][1]);
        //    Assert.AreEqual(_scal345Ref.M13, _scal345[0][2]);
        //    Assert.AreEqual(_scal345Ref.M14, _scal345[0][3]);
        //    Assert.AreEqual(_scal345Ref.M21, _scal345[1][0]);
        //    Assert.AreEqual(_scal345Ref.M22, _scal345[1][1]);
        //    Assert.AreEqual(_scal345Ref.M23, _scal345[1][2]);
        //    Assert.AreEqual(_scal345Ref.M24, _scal345[1][3]);
        //    Assert.AreEqual(_scal345Ref.M31, _scal345[2][0]);
        //    Assert.AreEqual(_scal345Ref.M32, _scal345[2][1]);
        //    Assert.AreEqual(_scal345Ref.M33, _scal345[2][2]);
        //    Assert.AreEqual(_scal345Ref.M34, _scal345[2][3]);
        //    Assert.AreEqual(_scal345Ref.M41, _scal345[3][0]);
        //    Assert.AreEqual(_scal345Ref.M42, _scal345[3][1]);
        //    Assert.AreEqual(_scal345Ref.M43, _scal345[3][2]);
        //    Assert.AreEqual(_scal345Ref.M44, _scal345[3][3]);
        //}

        [TestMethod]
        public void UnityComparison_Tests_Translate345()
        {
            Assert.AreEqual(_translate345Ref[0][0], _translate345[0][0]);
            Assert.AreEqual(_translate345Ref[0][1], _translate345[0][1]);
            Assert.AreEqual(_translate345Ref[0][2], _translate345[0][2]);
            Assert.AreEqual(_translate345Ref[0][3], _translate345[0][3]);
            Assert.AreEqual(_translate345Ref[1][0], _translate345[1][0]);
            Assert.AreEqual(_translate345Ref[1][1], _translate345[1][1]);
            Assert.AreEqual(_translate345Ref[1][2], _translate345[1][2]);
            Assert.AreEqual(_translate345Ref[1][3], _translate345[1][3]);
            Assert.AreEqual(_translate345Ref[2][0], _translate345[2][0]);
            Assert.AreEqual(_translate345Ref[2][1], _translate345[2][1]);
            Assert.AreEqual(_translate345Ref[2][2], _translate345[2][2]);
            Assert.AreEqual(_translate345Ref[2][3], _translate345[2][3]);
            Assert.AreEqual(_translate345Ref[3][0], _translate345[3][0]);
            Assert.AreEqual(_translate345Ref[3][1], _translate345[3][1]);
            Assert.AreEqual(_translate345Ref[3][2], _translate345[3][2]);
            Assert.AreEqual(_translate345Ref[3][3], _translate345[3][3]);
        }

        //[TestMethod]
        //public void UnityComparison_Tests_Transform345()
        //{
        //    Assert.AreEqual(_transformRef.M11, _transform[0][0]);
        //    Assert.AreEqual(_transformRef.M12, _transform[0][1]);
        //    Assert.AreEqual(_transformRef.M13, _transform[0][2]);
        //    Assert.AreEqual(_transformRef.M14, _transform[0][3]);
        //    Assert.AreEqual(_transformRef.M21, _transform[1][0]);
        //    Assert.AreEqual(_transformRef.M22, _transform[1][1]);
        //    Assert.AreEqual(_transformRef.M23, _transform[1][2]);
        //    Assert.AreEqual(_transformRef.M24, _transform[1][3]);
        //    Assert.AreEqual(_transformRef.M31, _transform[2][0]);
        //    Assert.AreEqual(_transformRef.M32, _transform[2][1]);
        //    Assert.AreEqual(_transformRef.M33, _transform[2][2]);
        //    Assert.AreEqual(_transformRef.M34, _transform[2][3]);
        //    Assert.AreEqual(_transformRef.M41, _transform[3][0]);
        //    Assert.AreEqual(_transformRef.M42, _transform[3][1]);
        //    Assert.AreEqual(_transformRef.M43, _transform[3][2]);
        //    Assert.AreEqual(_transformRef.M44, _transform[3][3]);
        //}

        [TestMethod]
        public void UnityComparison_Tests_PerspFov()
        {
            //Assert.AreEqual(_perspFovRef[0][0], _perspFov[0][0]);
            Assert.AreEqual(_perspFovRef[0][1], _perspFov[0][1]);
            Assert.AreEqual(_perspFovRef[0][2], _perspFov[0][2]);
            Assert.AreEqual(_perspFovRef[0][3], _perspFov[0][3]);
            Assert.AreEqual(_perspFovRef[1][0], _perspFov[1][0]);
            //Assert.AreEqual(_perspFovRef[1][1], _perspFov[1][1]);
            Assert.AreEqual(_perspFovRef[1][2], _perspFov[1][2]);
            Assert.AreEqual(_perspFovRef[1][3], _perspFov[1][3]);
            Assert.AreEqual(_perspFovRef[2][0], _perspFov[2][0]);
            Assert.AreEqual(_perspFovRef[2][1], _perspFov[2][1]);
            //Assert.AreEqual(_perspFovRef[2][2], _perspFov[2][2]);
            //Assert.AreEqual(_perspFovRef[2][3], _perspFov[2][3]);
            Assert.AreEqual(_perspFovRef[3][0], _perspFov[3][0]);
            Assert.AreEqual(_perspFovRef[3][1], _perspFov[3][1]);
            Assert.AreEqual(_perspFovRef[3][2], _perspFov[3][2]);
            Assert.AreEqual(_perspFovRef[3][3], _perspFov[3][3]);
        }

        //[TestMethod]
        //public void UnityComparison_Tests_Invert()
        //{
        //    Assert.AreEqual(_inverseIdentityRef.M11, _inverseIdentity[0][0]);
        //    Assert.AreEqual(_inverseIdentityRef.M12, _inverseIdentity[0][1]);
        //    Assert.AreEqual(_inverseIdentityRef.M13, _inverseIdentity[0][2]);
        //    Assert.AreEqual(_inverseIdentityRef.M14, _inverseIdentity[0][3]);
        //    Assert.AreEqual(_inverseIdentityRef.M21, _inverseIdentity[1][0]);
        //    Assert.AreEqual(_inverseIdentityRef.M22, _inverseIdentity[1][1]);
        //    //Assert.AreEqual(_inverseIdentityRef.M23, _inverseIdentity[1][2]); //close 
        //    Assert.AreEqual(_inverseIdentityRef.M24, _inverseIdentity[1][3]);
        //    Assert.AreEqual(_inverseIdentityRef.M31, _inverseIdentity[2][0]);
        //    //Assert.AreEqual(_inverseIdentityRef.M32, _inverseIdentity[2][1]); //close 
        //    //Assert.AreEqual(_inverseIdentityRef.M33, _inverseIdentity[2][2]); //close 
        //    Assert.AreEqual(_inverseIdentityRef.M34, _inverseIdentity[2][3]);
        //    Assert.AreEqual(_inverseIdentityRef.M41, _inverseIdentity[3][0]);
        //    Assert.AreEqual(_inverseIdentityRef.M42, _inverseIdentity[3][1]);
        //    Assert.AreEqual(_inverseIdentityRef.M43, _inverseIdentity[3][2]);
        //    Assert.AreEqual(_inverseIdentityRef.M44, _inverseIdentity[3][3]);
        //}

    }
}