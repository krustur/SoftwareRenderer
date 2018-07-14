using System;

namespace SoftwareRenderer
{
    public struct Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static float Dot(Vector3 p, Vector3 q)
        {
            var dot = p.X * q.X + p.Y * q.Y + p.Z * q.Z;
            return dot;
        }

        public float LengthSquared()
        {
            var lengthSquared = X * X + Y * Y + Z * Z;
            return lengthSquared;
        }

        public float Length()
        {
            var lengthSquared = X * X + Y * Y + Z * Z;
            var length = Math.Sqrt(lengthSquared);
            return (float) length;
        }

        public static Vector3 Cross(Vector3 p, Vector3 q)
        {
            var cross = new Vector3()
            {
                X = p.Y * q.Z - p.Z * q.Y,
                Y = p.Z * q.X - p.X * q.Z,
                Z = p.X * q.Y - p.Y * q.X,
            };
            return cross;
        }

        public static Vector3 Proj(Vector3 p, Vector3 onto)
        {
            var dot = Dot(p, onto);
            var xxx = dot / onto.LengthSquared();
            var proj = onto * xxx;
            return proj;
        }

        public static Vector3 operator *(Vector3 a, float f)
        {
            return new Vector3(a.X * f, a.Y * f, a.Z * f);
        }
    }
}