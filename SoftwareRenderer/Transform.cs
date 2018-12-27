using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SoftwareRenderer
{
    public class Transform
    {
        public ReadOnlyCollection<Transform> Children;

        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                _matrixDirty = true;
            }
        }

        public Vector3 Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                _matrixDirty = true;
            }
        }

        public Vector3 Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                _matrixDirty = true;
            }
        }

        public Matrix4X4 LocalToWorldTransform
        {
            get
            {
                if (_matrixDirty)
                {
                    UpdateMatrices();
                }

                return _localToWorldTransform;
            }
        }

        public Matrix4X4 WorldToLocalTransform
        {
            get
            {
                if (_matrixDirty)
                {
                    UpdateMatrices();
                }

                return _worldToLocalTransform;
            }
        }

        private readonly IList<Transform> _children = new List<Transform>();
        public Transform Parent = null;
        private Vector3 _position = Vector3.Zero;
        private Vector3 _rotation = Vector3.Zero;
        private Vector3 _scale;
        private bool _matrixDirty = false;
        private Matrix4X4 _localToWorldTransform = Matrix4X4.Identity;
        private Matrix4X4 _worldToLocalTransform = Matrix4X4.Identity;

        public Transform()
        {
            Children = new ReadOnlyCollection<Transform>(_children);
        }

        private void UpdateMatrices()
        {
            if (Parent == null)
            {
                _localToWorldTransform =
                    Matrix4X4.CreateScale(_scale) *
                    Matrix4X4.CreateTranslation(_position) *
                    Matrix4X4.CreateRotationZ(MathHelper.ToRadians(_rotation.Z)) *
                    Matrix4X4.CreateRotationY(MathHelper.ToRadians(_rotation.Y)) *
                    Matrix4X4.CreateRotationX(MathHelper.ToRadians(_rotation.X))
                    ;
                _worldToLocalTransform = _localToWorldTransform.Inverse();
            }
            else
            {
                _localToWorldTransform =
                    Parent.LocalToWorldTransform *
                    Matrix4X4.CreateScale(_scale) *
                    Matrix4X4.CreateTranslation(_position) *
                    Matrix4X4.CreateRotationZ(MathHelper.ToRadians(_rotation.Z)) *
                    Matrix4X4.CreateRotationY(MathHelper.ToRadians(_rotation.Y)) *
                    Matrix4X4.CreateRotationX(MathHelper.ToRadians(_rotation.X))
                    ;
                _worldToLocalTransform = _localToWorldTransform.Inverse();
            }
        }

        public void AddChild(Transform child)
        {
            if (child.Parent != null)
            {
                child.Parent.RemoveChild(child);
            }

            _children.Add(child);
            child.Parent = this;
        }

        private void RemoveChild(Transform child)
        {
            _children.Remove(child);
        }
    }
}