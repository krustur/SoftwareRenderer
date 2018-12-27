using System;

namespace SoftwareRenderer.Tests
{
    public class Camera
    {
        public Transform Transform { get; } = new Transform();
        public Matrix4X4 Projection { get; }
        public Matrix4X4 CameraToWorld
        {
            get
            {
                //var cameraToWorld = new Matrix4X4(
                //    new Vector4(
                //        Transform.LocalToWorldTransform[0].X,
                //        Transform.LocalToWorldTransform[0].Y,
                //        -Transform.LocalToWorldTransform[0].Z,
                //        Transform.LocalToWorldTransform[0].W),
                //    new Vector4(
                //        Transform.LocalToWorldTransform[1].X,
                //        Transform.LocalToWorldTransform[1].Y,
                //        -Transform.LocalToWorldTransform[1].Z,
                //        Transform.LocalToWorldTransform[1].W),
                //    new Vector4(
                //        Transform.LocalToWorldTransform[2].X,
                //        Transform.LocalToWorldTransform[2].Y,
                //        -Transform.LocalToWorldTransform[2].Z,
                //        Transform.LocalToWorldTransform[2].W),
                //    new Vector4(
                //        Transform.LocalToWorldTransform[3].X,
                //        Transform.LocalToWorldTransform[3].Y,
                //        -Transform.LocalToWorldTransform[3].Z,
                //        Transform.LocalToWorldTransform[3].W));

                var cameraToWorld = Transform.LocalToWorldTransform * new Matrix4X4(
                    new Vector4(1, 0, 0, 0),
                    new Vector4(0, 1, 0, 0),
                    new Vector4(0, 0, -1, 0),
                    new Vector4(0, 0, 0, 1)
                    );
                return cameraToWorld;
            }
        }

        public Matrix4X4 WorldToCamera
        {
            get
            {
                var worldToCamera = new Matrix4X4(
                                        new Vector4(1, 0, 0, 0),
                                        new Vector4(0, 1, 0, 0),
                                        new Vector4(0, 0, -1, 0),
                                        new Vector4(0, 0, 0, 1)
                                    ) * Transform.WorldToLocalTransform;
                return worldToCamera;
            }
        }


        public Camera(float fieldOfViewDegrees, float aspectRatio, float near, float far)
        {
            Projection = Matrix4X4.CreatePerspective(fieldOfViewDegrees, aspectRatio, near, far);
        }

        public Vector4 WorldToViewportPoint(Vector3 v)
        {
            var result = Projection * WorldToCamera * v;
            result.X /= result.W;
            result.Y /= result.W;
            result.Z /= result.W;
            result.X += 1f;
            result.Y += 1f;
            result.Z += 1f;
            result.X *= 0.5f;
            result.Y *= 0.5f;
            result.Z *= 0.5f;
            
            return result;
        }
    }
}