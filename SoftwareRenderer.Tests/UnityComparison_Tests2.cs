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
        private Matrix4X4 _zeroCameraWorldToCamera;
        private Matrix4X4 _zeroCameraWorldToCameraInverse;
        private Matrix4X4 _zeroCameraTransformLocalToWorldMatrixUnity;
        private Matrix4X4 _zeroCameraTransformLocalToWorldMatrixInverseUnity;
        private Matrix4X4 _zeroCameraTransformWorldToLocalMatrixUnity;
        private Matrix4X4 _zeroCameraTransformWorldToLocalMatrixInverseUnity;
        private Matrix4X4 _zeroCameraCameraToWorldMatrixUnity;
        private Matrix4X4 _zeroCameraCameraToWorldMatrixInverseUnity;
        private Matrix4X4 _zeroCameraWorldToCameraMatrixUnity;
        private Matrix4X4 _zeroCameraWorldToCameraMatrixInverseUnity;
        private Matrix4X4 _cameraTransform;
        private Matrix4X4 _cameraTransformInverse;
        private Matrix4X4 _cameraWorldToCamera;
        private Matrix4X4 _cameraWorldToCameraInverse;
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
        private Vector3 _rotCubeTransformLocalPositionUnity;
        private Vector3 _rotCubeTransformWorldPositionUnity;
        private Vector3 _rotCubeTransformLocalRotationUnity;
        private Vector3 _rotCubeTransformWorldRotationUnity;
        private Matrix4X4 _grandParentTransform;
        private Matrix4X4 _grandParentTransformLocalToWorldUnity;
        private Matrix4X4 _grandParentTransformLocalToWorldInverseUnity;
        private Matrix4X4 _grandParentTransformWorldToLocalUnity;
        private Matrix4X4 _grandParentTransformWorldToLocalInverseUnity;
        private Vector3 _grandParentTransformLocalPositionUnity;
        private Vector3 _grandParentTransformWorldPositionUnity;
        private Vector3 _grandParentTransformLocalRotationUnity;
        private Vector3 _grandParentTransformWorldRotationUnity;
        private Matrix4X4 _parentTransform;
        private Matrix4X4 _parentTransformLocalToWorldUnity;
        private Matrix4X4 _parentTransformLocalToWorldInverseUnity;
        private Matrix4X4 _parentTransformWorldToLocalUnity;
        private Matrix4X4 _parentTransformWorldToLocalInverseUnity;
        private Vector3 _parentTransformLocalPositionUnity;
        private Vector3 _parentTransformWorldPositionUnity;
        private Vector3 _parentTransformLocalRotationUnity;
        private Vector3 _parentTransformWorldRotationUnity;
        private Matrix4X4 _childTransform;
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
        private Vector4 _grandParentViewPointInZeroCamera;

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
            _zeroCameraWorldToCamera = _zeroCameraTransform.Inverse();
            _zeroCameraWorldToCamera[2] = new Vector4(-_zeroCameraWorldToCamera[2].X, -_zeroCameraWorldToCamera[2].Y, -_zeroCameraWorldToCamera[2].Z, -_zeroCameraWorldToCamera[2].W);
            _zeroCameraWorldToCameraInverse = _zeroCameraWorldToCamera.Inverse();

            _zeroCameraTransformLocalToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraTransformLocalToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraTransformWorldToLocalMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraTransformWorldToLocalMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, 1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraCameraToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraCameraToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraWorldToCameraMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, 0f, 0f, 1f));
            _zeroCameraWorldToCameraMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 0f), new Vector4(0f, 1f, 0f, 0f), new Vector4(0f, 0f, -1f, 0f), new Vector4(0f, 0f, 0f, 1f));

            // Camera
            var camtranslation = Matrix4X4.CreateTranslation(new Vector3(2.5f, 1.5f, -3f));
            var camrotationX = Matrix4X4.CreateRotationX(MathHelper.ToRadians(4));
            var camrotationY = Matrix4X4.CreateRotationY(0);
            var camrotationZ = Matrix4X4.CreateRotationZ(0);
            //_cameraTransform = _oneScale * camrotationX * camrotationY * camrotationZ * camtranslation;
            _cameraTransform = _oneScale * camtranslation * camrotationZ * camrotationY * camrotationX;
            _cameraTransformInverse = _cameraTransform.Inverse();

            _cameraWorldToCamera = _cameraTransform.Inverse();
            _cameraWorldToCamera[2] = new Vector4(-_cameraWorldToCamera[2].X, -_cameraWorldToCamera[2].Y, -_cameraWorldToCamera[2].Z, -_cameraWorldToCamera[2].W);
            _cameraWorldToCameraInverse = _cameraWorldToCamera.Inverse();
            //_backwardsCameraTransform = _oneScale * camtranslation * camrotationZ * camrotationY * camrotationX;

            _cameraProjection = Matrix4X4.CreatePerspectiveFieldOfViewV3(0, 2, 0, 1.5f, 60.0f, 0.3f, 1000);
            //_cameraTransformLocalToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, -0.06975646f, 1.5f), new Vector4(0f, 0.06975646f, 0.9975641f, 0f), new Vector4(0f, 0f, 0f, 1f));
            //_cameraTransformLocalToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975647f, -1.496346f), new Vector4(0f, -0.06975646f, 0.9975641f, 0.1046347f), new Vector4(0f, 0f, 0f, 1f));
            //_cameraTransformWorldToLocalMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975646f, -1.496346f), new Vector4(0f, -0.06975646f, 0.9975641f, 0.1046347f), new Vector4(0f, 0f, 0f, 1f));
            //_cameraTransformWorldToLocalMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, -0.06975647f, 1.5f), new Vector4(0f, 0.06975646f, 0.9975641f, 0f), new Vector4(0f, 0f, 0f, 1f));
            //_cameraCameraToWorldMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, 0.06975647f, 1.5f), new Vector4(0f, 0.06975646f, -0.9975641f, 0f), new Vector4(0f, 0f, 0f, 1f));
            //_cameraCameraToWorldMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975648f, -1.496346f), new Vector4(0f, 0.06975646f, -0.9975641f, -0.1046347f), new Vector4(0f, 0f, 0f, 1f));
            //_cameraWorldToCameraMatrixUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, -2.5f), new Vector4(0f, 0.9975641f, 0.06975646f, -1.496346f), new Vector4(0f, 0.06975646f, -0.9975641f, -0.1046347f), new Vector4(0f, 0f, 0f, 1f));
            //_cameraWorldToCameraMatrixInverseUnity = new Matrix4X4(new Vector4(1f, 0f, 0f, 2.5f), new Vector4(0f, 0.9975641f, 0.06975647f, 1.5f), new Vector4(0f, 0.06975646f, -0.9975641f, 0f), new Vector4(0f, 0f, 0f, 1f));
            //_cameraProjectionMatrixUnity = new Matrix4X4(new Vector4(1.299038f, 0f, 0f, 0f), new Vector4(0f, 1.732051f, 0f, 0f), new Vector4(0f, 0f, -1.0006f, -0.60018f), new Vector4(0f, 0f, -1f, 0f));
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
            _rotCubeTransformLocalPositionUnity = new Vector3(0f, 0f, 4f);
            _rotCubeTransformWorldPositionUnity = new Vector3(0f, 0f, 4f);
            _rotCubeTransformLocalRotationUnity = new Vector3(0f, 37.99999f, 0f);
            _rotCubeTransformWorldRotationUnity = new Vector3(0f, 37.99999f, 0f);


            // GrandParent
            var grandParentTranslation = Matrix4X4.CreateTranslation(new Vector3(2, 0.25f, 5));
            var grandParentRotationX = Matrix4X4.CreateRotationX(0);
            var grandParentRotationY = Matrix4X4.CreateRotationY(MathHelper.ToRadians(45f));
            var grandParentRotationZ = Matrix4X4.CreateRotationZ(0);
            _grandParentTransform = _oneScale * grandParentTranslation * grandParentRotationZ * grandParentRotationY * grandParentRotationX;
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

            // Parent
            var parentTranslation = Matrix4X4.CreateTranslation(new Vector3(2, 0, 0));
            var parentRotationX = Matrix4X4.CreateRotationX(MathHelper.ToRadians(-45f));
            var parentRotationY = Matrix4X4.CreateRotationY(0);
            var parentRotationZ = Matrix4X4.CreateRotationZ(0);
            _parentTransform = _oneScale * _grandParentTransform * parentTranslation * parentRotationZ * parentRotationY * parentRotationX;
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

            // Child
            var childTranslation = Matrix4X4.CreateTranslation(new Vector3(0, 0, 3));
            var childRotationX = Matrix4X4.CreateRotationX(0);
            var childRotationY = Matrix4X4.CreateRotationY(0);
            var childRotationZ = Matrix4X4.CreateRotationZ(0);
            _childTransform = _oneScale * _parentTransform * childTranslation * childRotationZ * childRotationY * childRotationX;
            _childTransformLocalToWorldUnity = new Matrix4X4(new Vector4(0.7071068f, -0.5f, 0.5f, 4.914214f), new Vector4(0f, 0.7071068f, 0.7071068f, 2.37132f), new Vector4(-0.7071068f, -0.5f, 0.5000001f, 5.085787f), new Vector4(0f, 0f, 0f, 1f));
            _childTransformLocalToWorldInverseUnity = new Matrix4X4(new Vector4(0.7071067f, 0f, -0.7071067f, 0.1213204f), new Vector4(-0.5f, 0.7071068f, -0.5000001f, 3.323224f), new Vector4(0.5f, 0.7071067f, 0.5f, -6.676776f), new Vector4(0f, 0f, 0f, 1f));
            _childTransformWorldToLocalUnity = new Matrix4X4(new Vector4(0.7071068f, 0f, -0.7071068f, 0.1213202f), new Vector4(-0.5f, 0.7071068f, -0.5f, 3.323223f), new Vector4(0.5f, 0.7071068f, 0.5000001f, -6.676777f), new Vector4(0f, 0f, 0f, 1f));
            _childTransformWorldToLocalInverseUnity = new Matrix4X4(new Vector4(0.7071067f, -0.4999999f, 0.5f, 4.914214f), new Vector4(0f, 0.7071067f, 0.7071067f, 2.37132f), new Vector4(-0.7071068f, -0.5f, 0.5000001f, 5.085787f), new Vector4(0f, 0f, 0f, 1f));
            _childTransformLocalPositionUnity = new Vector3(0f, 0f, 3f);
            _childTransformWorldPositionUnity = new Vector3(4.914214f, 2.37132f, 5.085786f);
            _childTransformLocalRotationUnity = new Vector3(0f, 0f, 0f);
            _childTransformWorldRotationUnity = new Vector3(315f, 45f, 1.207418E-06f);


            //
            var xxx = _cameraProjection * _zeroCameraWorldToCamera;
            //var xxx = _cameraProjection * _zeroCameraWorldToCamera;
            //var xxx = _cameraProjection;
            //var xxx = _zeroCameraWorldToCamera;
            _grandParentViewPointInZeroCamera = Vector3.Transform(_grandParentTransformWorldPositionUnity, xxx);
            _grandParentViewPointInZeroCamera.X /= _grandParentViewPointInZeroCamera.W;
            _grandParentViewPointInZeroCamera.Y /= _grandParentViewPointInZeroCamera.W;
            _grandParentViewPointInZeroCamera.Z /= _grandParentViewPointInZeroCamera.W;
            _grandParentViewPointInZeroCamera.X += 1f;
            _grandParentViewPointInZeroCamera.Y += 1f;
            _grandParentViewPointInZeroCamera.Z += 1f;
            _grandParentViewPointInZeroCamera.X *= 0.5f;
            _grandParentViewPointInZeroCamera.Y *= 0.5f;
            _grandParentViewPointInZeroCamera.Z *= 0.5f;

            _grandParentViewPointInZeroCameraUnity = new Vector3(0.7598076f, 0.5433013f, 5f);
            _grandParentScreenPointInZeroCameraUnity = new Vector3(778.043f, 417.2554f, 5f);

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
        public void UnityComparison_Tests2_ZeroCameraWorldToCamera()
        {
            Assert.AreEqual(_zeroCameraWorldToCameraMatrixUnity, _zeroCameraWorldToCamera);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCameraWorldToCamera_Inverse()
        {
            Assert.AreEqual(_zeroCameraWorldToCameraMatrixInverseUnity, _zeroCameraWorldToCameraInverse);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCameraCameraToWorld()
        {
            Assert.AreEqual(_zeroCameraCameraToWorldMatrixUnity, _zeroCameraWorldToCameraInverse);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ZeroCameraCameraToWorld_Inverse()
        {
            Assert.AreEqual(_zeroCameraCameraToWorldMatrixInverseUnity, _zeroCameraWorldToCamera);
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

        [TestMethod]
        public void UnityComparison_Tests2_CameraWorldToCamera()
        {
            Assert.AreEqual(_cameraWorldToCameraMatrixUnity, _cameraWorldToCamera);
        }

        [TestMethod]
        public void UnityComparison_Tests2_CameraWorldToCamera_Inverse()
        {
            Assert.AreEqual(_cameraWorldToCameraMatrixInverseUnity, _cameraWorldToCameraInverse);
        }

        [TestMethod]
        public void UnityComparison_Tests2_CameraCameraToWorld()
        {
            Assert.AreEqual(_cameraCameraToWorldMatrixUnity, _cameraWorldToCameraInverse);
        }

        [TestMethod]
        public void UnityComparison_Tests2_CameraCameraToWorld_Inverse()
        {
            Assert.AreEqual(_cameraCameraToWorldMatrixInverseUnity, _cameraWorldToCamera);
        }

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

        [TestMethod]
        public void UnityComparison_Tests2_GrandParentTransformLocalToWorld()
        {
            Assert.AreEqual(_grandParentTransformLocalToWorldUnity, _grandParentTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ParentTransformLocalToWorld()
        {
            Assert.AreEqual(_parentTransformLocalToWorldUnity, _parentTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ChildTransformLocalToWorld()
        {
            Assert.AreEqual(_childTransformLocalToWorldUnity, _childTransform);
        }

        [TestMethod]
        public void UnityComparison_Tests2_ChildViewPointInZeroCamera()
        {
            Assert.AreEqual(_grandParentViewPointInZeroCameraUnity.X, _grandParentViewPointInZeroCamera.X);
            Assert.AreEqual(_grandParentViewPointInZeroCameraUnity.Y, _grandParentViewPointInZeroCamera.Y);
            //Assert.AreEqual(_grandParentViewPointInZeroCameraUnity.Z, _grandParentViewPointInZeroCamera.Z);
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