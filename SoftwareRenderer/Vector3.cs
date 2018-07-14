using System;

namespace SoftwareRenderer
{
    public struct Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public static float Dot(Vector3 p, Vector3 q)
        {
            var dot = p.X * q.X + p.Y * q.Y + p.Z * q.Z;
            return dot;
        }

        public static double LengthSquared(Vector3 v)
        {
            var lengthSquared = v.X * v.X + v.Y * v.Y + v.Z * v.Z;
            return lengthSquared;
        }

        public static double Length(Vector3 v)
        {
            var lengthSquared = v.X * v.X + v.Y * v.Y + v.Z * v.Z;
            var length = Math.Sqrt(lengthSquared);
            return length;
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

    }
}