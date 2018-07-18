using System;
using System.Runtime.InteropServices;

namespace SoftwareRenderer
{
    public struct Matrix4X4
    {
        private Vector4 R0;
        private Vector4 R1;
        private Vector4 R2;
        private Vector4 R3;

        public static readonly Matrix4X4 Identity = new Matrix4X4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1));

        public static readonly Matrix4X4 Zero = new Matrix4X4(
            new Vector4(0, 0, 0, 0),
            new Vector4(0, 0, 0, 0),
            new Vector4(0, 0, 0, 0),
            new Vector4(0, 0, 0, 0));

        private Matrix4X4(
            float m00, float m01, float m02, float m03,
            float m10, float m11, float m12, float m13,
            float m20, float m21, float m22, float m23,
            float m30, float m31, float m32, float m33
        )
        {
            R0 = new Vector4(m00, m01, m02, m03);
            R1 = new Vector4(m10, m11, m12, m13);
            R2 = new Vector4(m20, m21, m22, m23);
            R3 = new Vector4(m30, m31, m32, m33);
        }

        public Matrix4X4(Vector4 m1, Vector4 m2, Vector4 m3, Vector4 m4)
        {
            R0 = m1;
            R1 = m2;
            R2 = m3;
            R3 = m4;
        }

        public static Matrix4X4 operator *(Matrix4X4 a, Matrix4X4 b)
        {
            return new Matrix4X4(

                new Vector4(
                    // i=0, j=0
                    a[0][0] * b[0][0] + a[0][1] * b[1][0] + a[0][2] * b[2][0] + a[0][3] * b[3][0],
                    // i=0, j=1
                    a[0][0] * b[0][1] + a[0][1] * b[1][1] + a[0][2] * b[2][1] + a[0][3] * b[3][1],
                    // i=0, j=2
                    a[0][0] * b[0][2] + a[0][1] * b[1][2] + a[0][2] * b[2][2] + a[0][3] * b[3][2],
                    // i=0, j=3
                    a[0][0] * b[0][3] + a[0][1] * b[1][3] + a[0][2] * b[2][3] + a[0][3] * b[3][3]),
                new Vector4(
                    // i=0, j=0
                    a[1][0] * b[0][0] + a[1][1] * b[1][0] + a[1][2] * b[2][0] + a[1][3] * b[3][0],
                    // i=0, j=1
                    a[1][0] * b[0][1] + a[1][1] * b[1][1] + a[1][2] * b[2][1] + a[1][3] * b[3][1],
                    // i=0, j=2
                    a[1][0] * b[0][2] + a[1][1] * b[1][2] + a[1][2] * b[2][2] + a[1][3] * b[3][2],
                    // i=0, j=3
                    a[1][0] * b[0][3] + a[1][1] * b[1][3] + a[1][2] * b[2][3] + a[1][3] * b[3][3]),
                new Vector4(
                    // i=0, j=0
                    a[2][0] * b[0][0] + a[2][1] * b[1][0] + a[2][2] * b[2][0] + a[2][3] * b[3][0],
                    // i=0, j=1
                    a[2][0] * b[0][1] + a[2][1] * b[1][1] + a[2][2] * b[2][1] + a[2][3] * b[3][1],
                    // i=0, j=2
                    a[2][0] * b[0][2] + a[2][1] * b[1][2] + a[2][2] * b[2][2] + a[2][3] * b[3][2],
                    // i=0, j=3
                    a[2][0] * b[0][3] + a[2][1] * b[1][3] + a[2][2] * b[2][3] + a[2][3] * b[3][3]),
                new Vector4(
                    // i=0, j=0
                    a[3][0] * b[0][0] + a[3][1] * b[1][0] + a[3][2] * b[2][0] + a[3][3] * b[3][0],
                    // i=0, j=1
                    a[3][0] * b[0][1] + a[3][1] * b[1][1] + a[3][2] * b[2][1] + a[3][3] * b[3][1],
                    // i=0, j=2
                    a[3][0] * b[0][2] + a[3][1] * b[1][2] + a[3][2] * b[2][2] + a[3][3] * b[3][2],
                    // i=0, j=3
                    a[3][0] * b[0][3] + a[3][1] * b[1][3] + a[3][2] * b[2][3] + a[3][3] * b[3][3])
            );
        }

        public static Matrix4X4 CreateTranslation(Vector3 translation)
        {
            return new Matrix4X4(
                new Vector4(1, 0, 0, translation.X),
                new Vector4(0, 1, 0, translation.Y),
                new Vector4(0, 0, 1, translation.Z),
                new Vector4(0, 0, 0, 1)
            );
        }

        public static Matrix4X4 CreateScale(Vector3 scale)
        {
            return new Matrix4X4(
                new Vector4(scale.X, 0, 0, 0),
                new Vector4(0, scale.Y, 0, 0),
                new Vector4(0, 0, scale.Z, 0),
                new Vector4(0, 0, 0, 1)
            );
        }

        public static Matrix4X4 CreateRotationX(float radians)
        {
            var cos = (float) Math.Cos(radians);
            var sin = (float) Math.Sin(radians);
            return new Matrix4X4(
                new Vector4(1, 0, 0, 0),
                new Vector4(0, cos, -sin, 0),
                new Vector4(0, sin, cos, 0),
                new Vector4(0, 0, 0, 1)
            );
        }

        public static Matrix4X4 CreateRotationY(float radians)
        {
            var cos = (float) Math.Cos(radians);
            var sin = (float) Math.Sin(radians);
            return new Matrix4X4(
                new Vector4(cos, 0, sin, 0),
                new Vector4(0, 1, 0, 0),
                new Vector4(-sin, 0, cos, 0),
                new Vector4(0, 0, 0, 1)
            );
        }

        public static Matrix4X4 CreateRotationZ(float radians)
        {
            var cos = (float) Math.Cos(radians);
            var sin = (float) Math.Sin(radians);
            return new Matrix4X4(
                new Vector4(cos, -sin, 0, 0),
                new Vector4(sin, cos, 0, 0),
                new Vector4(0, 0, 1, 0),
                new Vector4(0, 0, 0, 1)
            );
        }
        /*
         
        DirectX::XMMATRIX scaleMatrix = DirectX::XMMatrixScaling(_scale.x, _scale.y, _scale.z);
		DirectX::XMMATRIX rotationMatrixX = DirectX::XMMatrixRotationX(_rotation.x);
		DirectX::XMMATRIX rotationMatrixY = DirectX::XMMatrixRotationY(_rotation.y);
		DirectX::XMMATRIX rotationMatrixZ = DirectX::XMMatrixRotationZ(_rotation.z);
		DirectX::XMMATRIX translateMatrix = DirectX::XMMatrixTranslation(_position.x, _position.y, _position.z);

		_localTransform = scaleMatrix * rotationMatrixX * rotationMatrixY * rotationMatrixZ * translateMatrix;

         */

        public Vector4 this[int row]
        {
            get
            {
                switch (row)
                {
                    case 0: return R0;
                    case 1: return R1;
                    case 2: return R2;
                    case 3: return R3;
                    default: throw new ArgumentOutOfRangeException(nameof(row));
                }
            }
            set
            {
                switch (row)
                {
                    case 0:
                        R0 = value;
                        return;
                    case 1:
                        R1 = value;
                        return;
                    case 2:
                        R2 = value;
                        return;
                    case 3:
                        R3 = value;
                        return;
                    default: throw new ArgumentOutOfRangeException(nameof(row));
                }
            }
        }

        public float this[int row, int col]
        {
            get
            {
                switch (row)
                {
                    case 0: return R0[col];
                    case 1: return R1[col];
                    case 2: return R2[col];
                    case 3: return R3[col];
                    default: throw new ArgumentOutOfRangeException(nameof(row));
                }
            }
            set
            {
                switch (row)
                {
                    case 0:
                        R0[col] = value;
                        return;
                    case 1:
                        R1[col] = value;
                        return;
                    case 2:
                        R2[col] = value;
                        return;
                    case 3:
                        R3[col] = value;
                        return;
                    default: throw new ArgumentOutOfRangeException(nameof(row));
                }
            }
        }

        public static Matrix4X4 CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float near, float far)
        {
            /*
 ( x  0  a  0 )       x = 2*near/(right-left)          y = 2*near/(top-bottom)
 ( 0  y  b  0 )       a = (right+left)/(right-left)    b = (top+bottom)/(top-bottom)
 ( 0  0  c  d )       c = -(far+near)/(far-near)       d = -(2*far*near)/(far-near)
 ( 0  0  e  0 )       e = -1
            */
            var right = 10;
            var left = -10;
            var top = 10;
            var bottom = -10;

            var x = 2 * near / (right - left);
            var y = 2 * near / (top - bottom);
            var a = (right + left) / (right - left);
            var b = (top + bottom) / (top - bottom);
            var c = -(far + near) / (far - near);
            var d = -(2 * far * near) / (far - near);
            var e = -1f;

            return new Matrix4X4(
                new Vector4(x, 0, a, 0),
                new Vector4(0, y, b, 0),
                new Vector4(0, 0, c, d),
                new Vector4(0, 0, e, 0));
        }
        public static Matrix4X4 CreatePerspectiveFieldOfView2(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            var yScale = (float) (1.0f / Math.Tan(fieldOfView * 0.5f));
            var xScale = yScale / aspectRatio;

            var negFarRange = /*float.IsPositiveInfinity(farPlaneDistance) ? -1.0f : */
                farPlaneDistance / ((double) nearPlaneDistance - farPlaneDistance);

            return new Matrix4X4(
                new Vector4(xScale, 0, 0, 0),
                new Vector4(0, yScale, 0, 0),
                new Vector4(0, 0, (float) negFarRange, (float) (nearPlaneDistance * negFarRange)),
                new Vector4(0, 0, -1, 0)
            );

        }

        public Matrix4X4 Inverse()
        {
            var result = new Matrix4X4();
            //float a = matrix.M11, b = matrix.M12, c = matrix.M13, d = matrix.M14;
            //float e = matrix.M21, f = matrix.M22, g = matrix.M23, h = matrix.M24;
            //float i = matrix.M31, j = matrix.M32, k = matrix.M33, l = matrix.M34;
            //float m = matrix.M41, n = matrix.M42, o = matrix.M43, p = matrix.M44;

            //float a = this[0][0], b = this[1][0], c = this[2][0], d = this[3][0];
            //float e = this[0][1], f = this[1][1], g = this[2][1], h = this[3][1];
            //float i = this[0][2], j = this[1][2], k = this[2][2], l = this[3][2];
            //float m = this[0][3], n = this[1][3], o = this[2][3], p = this[3][3];
            double a = this[0][0], b = this[0][1], c = this[0][2], d = this[0][3];
            double e = this[1][0], f = this[1][1], g = this[1][2], h = this[1][3];
            double i = this[2][0], j = this[2][1], k = this[2][2], l = this[2][3];
            double m = this[3][0], n = this[3][1], o = this[3][2], p = this[3][3];


            var kp_lo = k * p - l * o;
            var jp_ln = j * p - l * n;
            var jo_kn = j * o - k * n;
            var ip_lm = i * p - l * m;
            var io_km = i * o - k * m;
            var in_jm = i * n - j * m;

            var a11 = +(f * kp_lo - g * jp_ln + h * jo_kn);
            var a12 = -(e * kp_lo - g * ip_lm + h * io_km);
            var a13 = +(e * jp_ln - f * ip_lm + h * in_jm);
            var a14 = -(e * jo_kn - f * io_km + g * in_jm);

            var det = a * a11 + b * a12 + c * a13 + d * a14;

            if (Math.Abs(det) < double.Epsilon)
            {
                return new Matrix4X4(float.NaN, float.NaN, float.NaN, float.NaN,
                    float.NaN, float.NaN, float.NaN, float.NaN,
                    float.NaN, float.NaN, float.NaN, float.NaN,
                    float.NaN, float.NaN, float.NaN, float.NaN);
            }

            var invDet = 1.0f / det;

            //result.M11 = a11 * invDet;
            //result.M21 = a12 * invDet;
            //result.M31 = a13 * invDet;
            //result.M41 = a14 * invDet;

            //result.M12 = -(b * kp_lo - c * jp_ln + d * jo_kn) * invDet;
            //result.M22 = +(a * kp_lo - c * ip_lm + d * io_km) * invDet;
            //result.M32 = -(a * jp_ln - b * ip_lm + d * in_jm) * invDet;
            //result.M42 = +(a * jo_kn - b * io_km + c * in_jm) * invDet;
            result[0, 0] = (float) (a11 * invDet);
            result[0, 1] = (float) (a12 * invDet);
            result[0, 2] = (float) (a13 * invDet);
            result[0, 3] = (float) (a14 * invDet);

            result[1, 0] = (float) (-(b * kp_lo - c * jp_ln + d * jo_kn) * invDet);
            result[1, 1] = (float) (+(a * kp_lo - c * ip_lm + d * io_km) * invDet);
            result[1, 2] = (float) (-(a * jp_ln - b * ip_lm + d * in_jm) * invDet);
            result[1, 3] = (float) (+(a * jo_kn - b * io_km + c * in_jm) * invDet);

            var gp_ho = g * p - h * o;
            var fp_hn = f * p - h * n;
            var fo_gn = f * o - g * n;
            var ep_hm = e * p - h * m;
            var eo_gm = e * o - g * m;
            var en_fm = e * n - f * m;

            //result.M13 = +(b * gp_ho - c * fp_hn + d * fo_gn) * invDet;
            //result.M23 = -(a * gp_ho - c * ep_hm + d * eo_gm) * invDet;
            //result.M33 = +(a * fp_hn - b * ep_hm + d * en_fm) * invDet;
            //result.M43 = -(a * fo_gn - b * eo_gm + c * en_fm) * invDet;

            result[2, 0] = (float) (+(b * gp_ho - c * fp_hn + d * fo_gn) * invDet);
            result[2, 1] = (float) (-(a * gp_ho - c * ep_hm + d * eo_gm) * invDet);
            result[2, 2] = (float) (+(a * fp_hn - b * ep_hm + d * en_fm) * invDet);
            result[2, 3] = (float) (-(a * fo_gn - b * eo_gm + c * en_fm) * invDet);

            var gl_hk = g * l - h * k;
            var fl_hj = f * l - h * j;
            var fk_gj = f * k - g * j;
            var el_hi = e * l - h * i;
            var ek_gi = e * k - g * i;
            var ej_fi = e * j - f * i;

            //result.M14 = -(b * gl_hk - c * fl_hj + d * fk_gj) * invDet;
            //result.M24 = +(a * gl_hk - c * el_hi + d * ek_gi) * invDet;
            //result.M34 = -(a * fl_hj - b * el_hi + d * ej_fi) * invDet;
            //result.M44 = +(a * fk_gj - b * ek_gi + c * ej_fi) * invDet;

            result[3, 0] = (float) (-(b * gl_hk - c * fl_hj + d * fk_gj) * invDet);
            result[3, 1] = (float) (+(a * gl_hk - c * el_hi + d * ek_gi) * invDet);
            result[3, 2] = (float) (-(a * fl_hj - b * el_hi + d * ej_fi) * invDet);
            result[3, 3] = (float) (+(a * fk_gj - b * ek_gi + c * ej_fi) * invDet);

            return result;
        }

    }
}