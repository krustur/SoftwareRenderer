using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoftwareRenderer.Tests
{
    [TestClass]
    public class UnityComparison_Tests
    {
        private Matrix4X4 _oneScale;
        private Matrix4X4 _oneScaleUnity;

        private Matrix4X4 _zeroCameraTransformLocalToWorldMatrixUnity;
        private Matrix4X4 _zeroCameraTransformLocalToWorldMatrixInverseUnity;
        private Matrix4X4 _zeroCameraTransformWorldToLocalMatrixUnity;
        private Matrix4X4 _zeroCameraTransformWorldToLocalMatrixInverseUnity;
        private Matrix4X4 _zeroCameraCameraToWorldMatrixUnity;
        private Matrix4X4 _zeroCameraCameraToWorldMatrixInverseUnity;
        private Matrix4X4 _zeroCameraWorldToCameraMatrixUnity;
        private Matrix4X4 _zeroCameraWorldToCameraMatrixInverseUnity;
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
        private Matrix4X4 _rotCubeTransformLocalToWorldUnity;
        private Matrix4X4 _rotCubeTransformLocalToWorldInverseUnity;
        private Matrix4X4 _rotCubeTransformWorldToLocalUnity;
        private Matrix4X4 _rotCubeTransformWorldToLocalInverseUnity;
        private Vector3 _rotCubeTransformLocalPositionUnity;
        private Vector3 _rotCubeTransformWorldPositionUnity;
        private Vector3 _rotCubeTransformLocalRotationUnity;
        private Vector3 _rotCubeTransformWorldRotationUnity;
        private Matrix4X4 _grandParentTransformLocalToWorldUnity;
        private Matrix4X4 _grandParentTransformLocalToWorldInverseUnity;
        private Matrix4X4 _grandParentTransformWorldToLocalUnity;
        private Matrix4X4 _grandParentTransformWorldToLocalInverseUnity;
        private Vector3 _grandParentTransformLocalPositionUnity;
        private Vector3 _grandParentTransformWorldPositionUnity;
        private Vector3 _grandParentTransformLocalRotationUnity;
        private Vector3 _grandParentTransformWorldRotationUnity;
        private Matrix4X4 _parentTransformLocalToWorldUnity;
        private Matrix4X4 _parentTransformLocalToWorldInverseUnity;
        private Matrix4X4 _parentTransformWorldToLocalUnity;
        private Matrix4X4 _parentTransformWorldToLocalInverseUnity;
        private Vector3 _parentTransformLocalPositionUnity;
        private Vector3 _parentTransformWorldPositionUnity;
        private Vector3 _parentTransformLocalRotationUnity;
        private Vector3 _parentTransformWorldRotationUnity;
        private Matrix4X4 _childTransformLocalToWorldUnity;
        private Matrix4X4 _childTransformLocalToWorldInverseUnity;
        private Matrix4X4 _childTransformWorldToLocalUnity;
        private Matrix4X4 _childTransformWorldToLocalInverseUnity;
        private Vector3 _childTransformLocalPositionUnity;
        private Vector3 _childTransformWorldPositionUnity;
        private Vector3 _childTransformLocalRotationUnity;
        private Vector3 _childTransformWorldRotationUnity;
        
        private Vector3 _grandParentViewPointInZeroCameraUnity;
        private Vector3 _grandParentScreenPointInZeroCameraUnity;

        private Transform _grandParent;
        private Transform _parent;
        private Transform _child;
        private Transform _rotCube;
        private Camera _zeroCamera;
        private Camera _camera;

        [TestInitialize]
        public void Init()
        {
            _oneScale = Matrix4X4.CreateScale(new Vector3(1, 1, 1));
            _oneScaleUnity = _oneScaleUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));


            // ZeroCamera - unity references
            _zeroCameraTransformLocalToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraTransformLocalToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraTransformWorldToLocalMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraTransformWorldToLocalMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraCameraToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraCameraToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraWorldToCameraMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraWorldToCameraMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, 0f, 0f, 1f));

            // Camera - unity references        
            _cameraTransformLocalToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, -0.06975646f, 1.5f), new Vector4(0f, 0.06975646f, 0.9975641f, -3f), new Vector4(0f, 0f, 0f, 1f));
            _cameraTransformLocalToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975647f, -1.287077f), new Vector4(0f, -0.06975646f, 0.9975641f, 3.097327f), new Vector4(0f, 0f, 0f, 1f));
            _cameraTransformWorldToLocalMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975646f, -1.287077f), new Vector4(0f, -0.06975646f, 0.9975641f, 3.097327f), new Vector4(0f, 0f, 0f, 1f));
            _cameraTransformWorldToLocalMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, -0.06975647f, 1.5f), new Vector4(0f, 0.06975646f, 0.9975641f, -3f), new Vector4(0f, 0f, 0f, 1f));
            _cameraCameraToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, 0.06975647f, 1.5f), new Vector4(0f, 0.06975646f, -0.9975641f, -3f), new Vector4(0f, 0f, 0f, 1f));
            _cameraCameraToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975648f, -1.287077f), new Vector4(0f, 0.06975646f, -0.9975641f, -3.097327f), new Vector4(0f, 0f, 0f, 1f));
            _cameraWorldToCameraMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975646f, -1.287077f), new Vector4(0f, 0.06975646f, -0.9975641f, -3.097327f), new Vector4(0f, 0f, 0f, 1f));
            _cameraWorldToCameraMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, 0.06975647f, 1.5f), new Vector4(0f, 0.06975646f, -0.9975641f, -3f), new Vector4(0f, 0f, 0f, 1f));
            _cameraProjectionMatrixUnity = new Matrix4X4(new Vector4(1.299038f, 0f, 0f, 0f), new Vector4(0f, 1.732051f, 0f, 0f), new Vector4(0f, 0f, -1.0006f, -0.60018f), new Vector4(0f, 0f, -1f, 0f));

            _cameraFarClipPlaneUnity = 1000f;
            _cameraNearClipPlaneUnity = 0.3f;
            _cameraPixelWidthUnity = 1024f;
            _cameraPixelHeightUnity = 768f;
            _cameraAspectUnity = 1.333333f;
            _cameraFieldOfViewUnity = 60f;



            // RotCube - unity references
            _rotCubeTransformLocalToWorldUnity = new Matrix4X4(new Vector4(0.7880109f, 0f, 0.6156613f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(-0.6156613f, 0f, 0.7880109f, 4f), new Vector4(0f, 0f, 0f, 1f));
            _rotCubeTransformLocalToWorldInverseUnity = new Matrix4X4(new Vector4(0.7880109f, 0f, -0.6156613f, 2.462645f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0.6156613f, 0f, 0.7880108f, -3.152043f), new Vector4(0f, 0f, 0f, 1f));
            _rotCubeTransformWorldToLocalUnity = new Matrix4X4(new Vector4(0.7880109f, 0f, -0.6156613f, 2.462645f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0.6156613f, 0f, 0.7880109f, -3.152044f), new Vector4(0f, 0f, 0f, 1f));
            _rotCubeTransformWorldToLocalInverseUnity = new Matrix4X4(new Vector4(0.7880109f, 0f, 0.6156613f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(-0.6156613f, 0f, 0.7880108f, 4f), new Vector4(0f, 0f, 0f, 1f));
            _rotCubeTransformLocalPositionUnity = new Vector3(0f, 0f, 4f);
            _rotCubeTransformWorldPositionUnity = new Vector3(0f, 0f, 4f);
            _rotCubeTransformLocalRotationUnity = new Vector3(0f, 37.99999f, 0f);
            _rotCubeTransformWorldRotationUnity = new Vector3(0f, 37.99999f, 0f);

            // GrandParent - unity references
            _grandParentTransformLocalToWorldUnity = new Matrix4X4(
                new Vector4(0.7071068f, 0f, 0.7071068f, 2f),
                new Vector4(0f, 1f, 0f, 0.25f),
                new Vector4(-0.7071068f, 0f, 0.7071068f, 5f),
                new Vector4(0f, 0f, 0f, 1f));
            _grandParentTransformLocalToWorldInverseUnity = new Matrix4X4(new Vector4(0.7071068f, 0f, -0.7071066f, 2.12132f), new Vector4(0f, 1f, 0f, -0.25f), new Vector4(0.7071067f, 0f, 0.7071068f, -4.949748f), new Vector4(0f, 0f, 0f, 1f));
            _grandParentTransformWorldToLocalUnity = new Matrix4X4(new Vector4(0.7071068f, 0f, -0.7071068f, 2.12132f), new Vector4(0f, 1f, 0f, -0.25f), new Vector4(0.7071068f, 0f, 0.7071068f, -4.949748f), new Vector4(0f, 0f, 0f, 1f));
            _grandParentTransformWorldToLocalInverseUnity = new Matrix4X4(new Vector4(0.7071068f, 0f, 0.7071066f, 2f), new Vector4(0f, 1f, 0f, 0.25f), new Vector4(-0.7071067f, 0f, 0.7071068f, 5f), new Vector4(0f, 0f, 0f, 1f));
            _grandParentTransformLocalPositionUnity = new Vector3(2f, 0.25f, 5f);
            _grandParentTransformWorldPositionUnity = new Vector3(2f, 0.25f, 5f); // this!
            _grandParentTransformLocalRotationUnity = new Vector3(0f, 45f, 0f);
            _grandParentTransformWorldRotationUnity = new Vector3(0f, 45f, 0f);

            // Parent - unity references
            _parentTransformLocalToWorldUnity = new Matrix4X4(
                new Vector4(0.7071068f, -0.5f, 0.5f, 3.414214f),
                new Vector4(0f, 0.7071068f, 0.7071068f, 0.25f),
                new Vector4(-0.7071068f, -0.5f, 0.5000001f, 3.585786f),
                new Vector4(0f, 0f, 0f, 1f));
            _parentTransformLocalToWorldInverseUnity = new Matrix4X4(new Vector4(0.7071067f, 0f, -0.7071067f, 0.1213204f), new Vector4(-0.5f, 0.7071068f, -0.5000001f, 3.323224f), new Vector4(0.5f, 0.7071067f, 0.5f, -3.676777f), new Vector4(0f, 0f, 0f, 1f));
            _parentTransformWorldToLocalUnity = new Matrix4X4(new Vector4(0.7071068f, 0f, -0.7071068f, 0.1213202f), new Vector4(-0.5f, 0.7071068f, -0.5f, 3.323223f), new Vector4(0.5f, 0.7071068f, 0.5000001f, -3.676777f), new Vector4(0f, 0f, 0f, 1f));
            _parentTransformWorldToLocalInverseUnity = new Matrix4X4(new Vector4(0.7071067f, -0.4999999f, 0.5f, 3.414214f), new Vector4(0f, 0.7071067f, 0.7071067f, 0.2500002f), new Vector4(-0.7071068f, -0.5f, 0.5000001f, 3.585787f), new Vector4(0f, 0f, 0f, 1f));
            _parentTransformLocalPositionUnity = new Vector3(2f, 0f, 0f);
            _parentTransformWorldPositionUnity = new Vector3(3.414214f, 0.25f, 3.585786f);
            _parentTransformLocalRotationUnity = new Vector3(315f, 0f, 0f);
            _parentTransformWorldRotationUnity = new Vector3(315f, 45f, 1.207418E-06f);

            // Child - unity references
            _childTransformLocalToWorldUnity = new Matrix4X4(new Vector4(0.7071068f, -0.5f, 0.5f, 4.914214f), new Vector4(0f, 0.7071068f, 0.7071068f, 2.37132f), new Vector4(-0.7071068f, -0.5f, 0.5000001f, 5.085787f), new Vector4(0f, 0f, 0f, 1f));
            _childTransformLocalToWorldInverseUnity = new Matrix4X4(new Vector4(0.7071067f, 0f, -0.7071067f, 0.1213204f), new Vector4(-0.5f, 0.7071068f, -0.5000001f, 3.323224f), new Vector4(0.5f, 0.7071067f, 0.5f, -6.676776f), new Vector4(0f, 0f, 0f, 1f));
            _childTransformWorldToLocalUnity = new Matrix4X4(new Vector4(0.7071068f, 0f, -0.7071068f, 0.1213202f), new Vector4(-0.5f, 0.7071068f, -0.5f, 3.323223f), new Vector4(0.5f, 0.7071068f, 0.5000001f, -6.676777f), new Vector4(0f, 0f, 0f, 1f));
            _childTransformWorldToLocalInverseUnity = new Matrix4X4(new Vector4(0.7071067f, -0.4999999f, 0.5f, 4.914214f), new Vector4(0f, 0.7071067f, 0.7071067f, 2.37132f), new Vector4(-0.7071068f, -0.5f, 0.5000001f, 5.085787f), new Vector4(0f, 0f, 0f, 1f));
            _childTransformLocalPositionUnity = new Vector3(0f, 0f, 3f);
            _childTransformWorldPositionUnity = new Vector3(4.914214f, 2.37132f, 5.085786f);
            _childTransformLocalRotationUnity = new Vector3(0f, 0f, 0f);
            _childTransformWorldRotationUnity = new Vector3(315f, 45f, 1.207418E-06f);

            //
            _grandParentViewPointInZeroCameraUnity = new Vector3(0.7598076f, 0.5433013f, 5f);
            _grandParentScreenPointInZeroCameraUnity = new Vector3(778.043f, 417.2554f, 5f);

            // My scene
            _zeroCamera = new Camera(60f, (float)640/480, 0.3f, 1000f);
            _zeroCamera.Transform.Position = Vector3.Zero;
            _zeroCamera.Transform.Rotation = Vector3.Zero;
            _zeroCamera.Transform.Scale = Vector3.One;

            _camera = new Camera(60f, (float)640 / 480, 0.3f, 1000f);
            _camera.Transform.Position = new Vector3(2.5f, 1.5f, -3f);
            _camera.Transform.Rotation = new Vector3(4f, 0, 0);
            _camera.Transform.Scale = Vector3.One;            

            _rotCube = new Transform
            {
                Position = new Vector3(0, 0, 4),
                Rotation = new Vector3(0, 38f, 0),
                Scale = Vector3.One
            };
            _grandParent = new Transform
            {
                Position = new Vector3(2, 0.25f, 5),
                Rotation = new Vector3(0, 45f, 0),
                Scale = Vector3.One
            };
            _parent = new Transform
            {
                Position = new Vector3(2, 0, 0),
                Rotation = new Vector3(-45, 0, 0),
                Scale = Vector3.One
            };
            _grandParent.AddChild(_parent);
            _child = new Transform
            {
                Position = new Vector3(0, 0, 3),
                Rotation = Vector3.Zero,
                Scale = Vector3.One
            };
            _parent.AddChild(_child);

        }

        [TestMethod]
        public void UnityComparison_Tests2_OneScale()
        {
            MyAssert.AreEqual_Matrix4X4(_oneScaleUnity, _oneScale);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCamera_Transform()
        {
            MyAssert.AreEqual_Matrix4X4(_zeroCameraTransformLocalToWorldMatrixUnity, _zeroCamera.Transform.LocalToWorldTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCamera_WorldToCamera()
        {
            Assert.AreEqual(_zeroCameraWorldToCameraMatrixUnity, _zeroCamera.WorldToCamera);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCamera_WorldToCamera_Inverse()
        {
            Assert.AreEqual(_zeroCameraWorldToCameraMatrixInverseUnity, _zeroCamera.WorldToCamera.Inverse());
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCamera_CameraToWorld()
        {
            Assert.AreEqual(_zeroCameraCameraToWorldMatrixUnity, _zeroCamera.CameraToWorld);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCamera_CameraToWorld_Inverse()
        {
            Assert.AreEqual(_zeroCameraCameraToWorldMatrixInverseUnity, _zeroCamera.CameraToWorld.Inverse());
        }

        [TestMethod]
        public void UnityComparison_Tests2_Camera_Transform_LocalToWorldMatrix()
        {
            Assert.AreEqual(_cameraTransformLocalToWorldMatrixUnity, _camera.Transform.LocalToWorldTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_Camera_Transform_LocalToWorldMatrix_Inverse()
        {
            Assert.AreEqual(_cameraTransformLocalToWorldMatrixInverseUnity, _camera.Transform.LocalToWorldTransform.Inverse());
        }

        [TestMethod]
        public void UnityComparison_Tests2_Camera_Projection()
        {
            Assert.AreEqual(_cameraProjectionMatrixUnity, _camera.Projection);
        }

        [TestMethod]
        public void UnityComparison_Tests2_Camera_WorldToCamera()
        {
            Assert.AreEqual(_cameraWorldToCameraMatrixUnity, _camera.WorldToCamera);
        }

        [TestMethod]
        public void UnityComparison_Tests2_Camera_WorldToCamera_Inverse()
        {
            Assert.AreEqual(_cameraWorldToCameraMatrixInverseUnity, _camera.WorldToCamera.Inverse());
        }

        [TestMethod]
        public void UnityComparison_Tests2_Camera_CameraToWorld()
        {
            Assert.AreEqual(_cameraCameraToWorldMatrixUnity, _camera.CameraToWorld);
        }

        [TestMethod]
        public void UnityComparison_Tests2_Camera_CameraToWorld_Inverse()
        {
            Assert.AreEqual(_cameraCameraToWorldMatrixInverseUnity, _camera.CameraToWorld.Inverse());
        }

        [TestMethod]
        public void UnityComparison_Tests2_RotCube_Transform_LocalToWorld()
        {
            Assert.AreEqual(_rotCubeTransformLocalToWorldUnity, _rotCube.LocalToWorldTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_RotCube_Transform_LocalToWorld_Inverse()
        {
            Assert.AreEqual(_rotCubeTransformLocalToWorldInverseUnity, _rotCube.LocalToWorldTransform.Inverse());
        }

        [TestMethod]
        public void UnityComparison_Tests2_RotCube_Transform_WorldToLocal()
        {
            Assert.AreEqual(_rotCubeTransformWorldToLocalUnity, _rotCube.WorldToLocalTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_RotCube_Transform_WorldToLocal_Inverse()
        {
            Assert.AreEqual(_rotCubeTransformWorldToLocalInverseUnity, _rotCube.WorldToLocalTransform.Inverse());
        }

        [TestMethod]
        public void UnityComparison_Tests2_GrandParent_Transform_LocalToWorld()
        {
            Assert.AreEqual(_grandParentTransformLocalToWorldUnity, _grandParent.LocalToWorldTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_Parent_Transform_LocalToWorld()
        {
            Assert.AreEqual(_parentTransformLocalToWorldUnity, _parent.LocalToWorldTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_Child_Transform_LocalToWorld()
        {
            Assert.AreEqual(_childTransformLocalToWorldUnity, _child.LocalToWorldTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCamera_GrandParent_WorldToViewportPoint_X()
        {
            Assert.AreEqual(_grandParentViewPointInZeroCameraUnity.X, _zeroCamera.WorldToViewportPoint(_grandParent.Position).X);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCamera_GrandParent_WorldToViewportPoint_Y()
        {
            Assert.AreEqual(_grandParentViewPointInZeroCameraUnity.Y, _zeroCamera.WorldToViewportPoint(_grandParent.Position).Y);
        }

        //[TestMethod]
        //[Ignore]
        //public void UnityComparison_Tests2_ZeroCamera_GrandParent_WorldToViewportPoint_Z()
        //{
        //    Assert.AreEqual(_grandParentViewPointInZeroCameraUnity.Z, _zeroCamera.WorldToViewportPoint(_grandParent.Position).Z);
        //}
    }
}