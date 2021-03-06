﻿using System;

namespace SoftwareRenderer
{
    public struct Vector3
    {
        private const double Tolerance = 1e-5;

        private float[] _v;

        public float X { get => _v?[0] ?? 0;
            set
            {
                if (_v == null)
                {
                    _v = new [] {value, 0, 0};
                    return;
                }
                _v[0] = value;
            }
        }
        public float Y { get => _v?[1] ?? 0;
            set
            {
                if (_v == null)
                {
                    _v = new [] {0, value, 0};
                    return;
                }
                _v[1] = value;
            }
        }
        public float Z { get => _v?[2] ?? 0;
            set
            {
                if (_v == null)
                {
                    _v = new [] {0, 0, value};
                    return;
                }
                _v[2] = value;
            }
        }

        public Vector3(float x, float y, float z)
        {
            _v = new[] { x, y, z };
        }

        public static readonly Vector3 Zero = new Vector3(0, 0, 0);
        public static readonly Vector3 One = new Vector3(1, 1, 1);
        public static readonly Vector3 Left = new Vector3(-1, 0, 0);
        public static readonly Vector3 Right = new Vector3(1, 0, 0);
        public static readonly Vector3 Up = new Vector3(0, 1, 0);
        public static readonly Vector3 Down = new Vector3(0, -1, 0);
        public static readonly Vector3 Back = new Vector3(0, 0, -1);
        public static readonly Vector3 Forward = new Vector3(0, 0, 1);
        public static readonly Vector3 NegativeInfinity = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        public static readonly Vector3 PositiveInfinity = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        public static float Dot(Vector3 lhs, Vector3 rhs)
        {
            var dot = lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
            return dot;
        }

        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            var cross = new Vector3
            {
                X = lhs.Y * rhs.Z - lhs.Z * rhs.Y,
                Y = lhs.Z * rhs.X - lhs.X * rhs.Z,
                Z = lhs.X * rhs.Y - lhs.Y * rhs.X,
            };
            return cross;
        }

        public static Vector3 Normalize(Vector3 vector)
        {
            var magnitude = vector.Magnitude();
            return new Vector3(vector.X / magnitude, vector.Y / magnitude, vector.Z / magnitude);
        }

        public static Vector3 Proj(Vector3 vector, Vector3 onNormal)
        {
            var dot = Dot(vector, onNormal);
            var xxx = dot / onNormal.MagnitudeSquared();
            var proj = onNormal * xxx;
            return proj;
        }

        public static Vector3 Perp(Vector3 p, Vector3 of)
        {
            var proj = Proj(p, of);
            var perp = p - proj;
            return perp;
        }

        public float MagnitudeSquared()
        {
            var magnitudeSquared = X * X + Y * Y + Z * Z;
            return magnitudeSquared;
        }

        public float Magnitude()
        {
            var magnitude = Math.Sqrt(MagnitudeSquared());
            return (float) magnitude;
        }

        public Vector3 Normalized(Vector3 vector)
        {
            return Normalize(vector);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3 operator *(Vector3 a, float f)
        {
            return new Vector3(a.X * f, a.Y * f, a.Z * f);
        }

        public static Vector3 operator /(Vector3 a, float f)
        {
            return new Vector3(a.X / f, a.Y / f, a.Z / f);
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return Math.Abs(lhs.X - rhs.X) < Tolerance && Math.Abs(lhs.Y - rhs.Y) < Tolerance &&
                   Math.Abs(lhs.Z - rhs.Z) < Tolerance;
        }

        public bool Equals(Vector3 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector3 && Equals((Vector3) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"[{X}, {Y}, {Z}]";
        }


        //public static Vector3 Transform(Vector3 position, Matrix4x4 matrix)
        //{
        //    return new Vector3(
        //        position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41,
        //        position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42,
        //        position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43);
        //}
        public uint AsUint()
        {
            var b = (uint)(X * 0xff) << 16;
            var c = (uint)(Y * 0xff) << 8;
            var d = (uint)(Z * 0xff);

            var result = b | c | d;
            return result;
        }
    }
}