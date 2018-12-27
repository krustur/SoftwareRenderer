using System;

namespace SoftwareRenderer
{
    public struct Vector4
    {
        private const double Tolerance = 1e-5;

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static readonly Vector4 Zero = new Vector4(0, 0, 0, 0);

        public static readonly Vector4 One = new Vector4(1, 1, 1, 1);

        //public static readonly Vector4 Left = new Vector4(-1, 0, 0);
        //public static readonly Vector4 Right = new Vector4(1, 0, 0);
        //public static readonly Vector4 Up = new Vector4(0, 1, 0);
        //public static readonly Vector4 Down = new Vector4(0, -1, 0);
        //public static readonly Vector4 Back = new Vector4(0, 0, -1);
        //public static readonly Vector4 Forward = new Vector4(0, 0, 1);
        public static readonly Vector4 NegativeInfinity = new Vector4(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        public static readonly Vector4 PositiveInfinity = new Vector4(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        public static float Dot(Vector4 lhs, Vector4 rhs)
        {
            var dot = lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z + lhs.W * rhs.W;
            return dot;
        }

        //public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        //{
        //    var cross = new Vector3
        //    {
        //        X = lhs.Y * rhs.Z - lhs.Z * rhs.Y,
        //        Y = lhs.Z * rhs.X - lhs.X * rhs.Z,
        //        Z = lhs.X * rhs.Y - lhs.Y * rhs.X,
        //    };
        //    return cross;
        //}

        public static Vector4 Normalize(Vector4 vector)
        {
            var magnitude = vector.Magnitude();
            return new Vector4(vector.X / magnitude, vector.Y / magnitude, vector.Z / magnitude, vector.W / magnitude);
        }

        //public static Vector3 Proj(Vector3 vector, Vector3 onNormal)
        //{
        //    var dot = Dot(vector, onNormal);
        //    var xxx = dot / onNormal.MagnitudeSquared();
        //    var proj = onNormal * xxx;
        //    return proj;
        //}

        //public static Vector3 Perp(Vector3 p, Vector3 of)
        //{
        //    var proj = Proj(p, of);
        //    var perp = p - proj;
        //    return perp;
        //}

        public float MagnitudeSquared()
        {
            var magnitudeSquared = X * X + Y * Y + Z * Z + W * W;
            return magnitudeSquared;
        }

        public float Magnitude()
        {
            var magnitude = Math.Sqrt(MagnitudeSquared());
            return (float) magnitude;
        }

        public Vector4 Normalized(Vector4 vector)
        {
            return Normalize(vector);
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        public static Vector4 operator *(Vector4 a, float f)
        {
            return new Vector4(a.X * f, a.Y * f, a.Z * f, a.W * f);
        }

        public static Vector4 operator /(Vector4 a, float f)
        {
            return new Vector4(a.X / f, a.Y / f, a.Z / f, a.W / f);
        }

        public static bool operator !=(Vector4 lhs, Vector4 rhs)
        {
            return !(lhs == rhs);
        }

        public float this[int i] 
        {
            get
            {
                switch (i)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    case 3: return W;
                    default: throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
            set
            {
                switch (i)
                {
                    case 0: X = value; return;
                    case 1: Y = value; return;
                    case 2: Z = value; return;
                    case 3: W = value; return;
                    default: throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
        }

        public static Vector4 Transform(Vector3 v, Matrix4X4 m)
        {
            var result = new Vector4(
                v.X * m[0][0] + v.Y * m[0][1] + v.Z * m[0][2] + m[0][3],
                v.X * m[1][0] + v.Y * m[1][1] + v.Z * m[1][2] + m[1][3],
                v.X * m[2][0] + v.Y * m[2][1] + v.Z * m[2][2] + m[2][3],
                v.X * m[3][0] + v.Y * m[3][1] + v.Z * m[3][2] + m[3][3]
                );
            //var result = new Vector4(
            //    v.X * m[0][0] + v.Y * m[1][0] + v.Z * m[2][0] + 1 * m[3][0],
            //    v.X * m[0][1] + v.Y * m[1][1] + v.Z * m[2][1] + 1 * m[3][1],
            //    v.X * m[0][2] + v.Y * m[1][2] + v.Z * m[2][2] + 1 * m[3][2],
            //    v.X * m[0][3] + v.Y * m[1][3] + v.Z * m[2][3] + 1 * m[3][3]
            //    );
            return result;
            //v.X * m[0][3] + v.Y * m[1][3] + v.Z * m[2][3] + 1 * m[3][3]);
        }
    
        public static bool operator ==(Vector4 lhs, Vector4 rhs)
        {
            return Math.Abs(lhs.X - rhs.X) < Tolerance && Math.Abs(lhs.Y - rhs.Y) < Tolerance &&
                   Math.Abs(lhs.Z - rhs.Z) < Tolerance && Math.Abs(lhs.W - rhs.W) < Tolerance;
        }

        public bool Equals(Vector4 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector4 && Equals((Vector4) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"[{X}, {Y}, {Z}, {W}]";
        }
    }
}