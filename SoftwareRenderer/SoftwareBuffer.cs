using System;

namespace SoftwareRenderer
{
    public class SoftwareBuffer
    {
        public int Width { get; }
        public int Heigth { get; }
        public uint[] Buffer { get; }

        public SoftwareBuffer(int width, int heigth)
        {
            Width = width;
            Heigth = heigth;
            Buffer = new uint[Width * Heigth];
        }


        public void SetPixel(float x, float y, uint col)
        {
            x *= Width;
            y *= Heigth;
            var xi = (int)x;
            var yi = (int)y;

            if (xi < 0 || xi >= Width || yi < 0 || yi >= Heigth)
                return;
            Buffer[(Heigth - 1 - yi) * Width - 1 + xi] = col;
        }

        public void SetPixel(int x, int y, uint col)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Heigth)
                return;
            Buffer[(Heigth - 1 - y) * Width -1 + x] = col;

        }

        public void DrawLine(float x1, float y1, float x2, float y2, Vector3 col)
        {
            var colInt = col.AsUint();

            x1 = (x1 * Width);
            x2 = (x2 * Width);
            y1 = (y1 * Heigth);
            y2 = (y2 * Heigth);

            if (Math.Abs(x2 - x1) > Math.Abs(y2 - y1))
            {
                // We loop along X

                if (x2 < x1)
                {
                    // We loop "x2 to x1"
                    Swapper.Swap(ref x1, ref x2);
                    Swapper.Swap(ref y1, ref y2);
                }
                else
                {
                    // We loop "x1 to x2"
                }

                var y = y1;
                var ky = (y2 - y1) / (x2 - x1);
                for (var x = x1; x <= x2; x++)
                {
                    SetPixel((int)x, (int)y, colInt);
                    y += ky;
                }
            }
            else
            {
                // We loop along Y

                if (y2 < y1)
                {
                    // We loop "y2 to y1"
                    Swapper.Swap(ref x1, ref x2);
                    Swapper.Swap(ref y1, ref y2);
                }
                else
                {
                    // We loop "y1 to y2"
                }

                var x = x1;
                var kx = (x2 - x1) / (y2 - y1);
                for (var y = y1; y <= y2; y++)
                {
                    SetPixel((int)x, (int)y, colInt);
                    x += kx;
                }
            }
        }


        public void DrawLine(int x1, int y1, int x2, int y2, Vector3 col)
        {
            var colInt = col.AsUint();

            if (Math.Abs(x2 - x1) > Math.Abs(y2 - y1))
            {
                // Loop along X
                if (x2 < x1)
                {
                    Swapper.Swap(ref x1, ref x2);
                    Swapper.Swap(ref y1, ref y2);
                }

                var y = (float)y1;
                var ky = (float) (y2 - y1) / (x2 - x1);
                for (var x = x1; x <= x2; x++)
                {
                    SetPixel(x, (int)y, colInt);
                    y += ky;
                }
            }
            else
            {
                // Loop along Y
                if (y2 < y1)
                {
                    Swapper.Swap(ref x1, ref x2);
                    Swapper.Swap(ref y1, ref y2);
                }

                var x = (float)x1;
                var kx = (float) (x2 - x1) / (y2 - y1);
                for (var y = y1; y <= y2; y++)
                {
                    SetPixel((int)x, y, colInt);
                    x += kx;
                }
            }
        }

        public void DrawTriangle(float x1, float y1, float x2, float y2, float x3, float y3, Vector3 materialDiffuse)
        {
            var diffuse = materialDiffuse.AsUint();

            //var t0 = new Vector3(((int)(x1 * Width)), (int)(y1 * Heigth), 0);
            //var t1 = new Vector3((int)(x2 * Width), (int)(y2 * Heigth), 0);
            //var t2 = new Vector3((int)(x3 * Width), (int)(y3 * Heigth), 0);

            //if (t0.Y == t1.Y && t0.Y == t2.Y) return; // I dont care about degenerate triangles

            //// sort the vertices, t0, t1, t2 lower−to−upper (bubblesort yay!) 
            //if (t0.Y > t1.Y) Swapper.Swap(ref t0, ref t1);
            //if (t0.Y > t2.Y) Swapper.Swap(ref t0, ref t2);
            //if (t1.Y > t2.Y) Swapper.Swap(ref t1, ref t2);
            //int total_height = (int)(t2.Y - t0.Y);
            //for (int y = (int)t0.Y; y <= t1.Y; y++)
            //{
            //    int segment_height = (int)(t1.Y - t0.Y + 1);
            //    float alpha = (float)(y - t0.Y) / total_height;
            //    float beta = (float)(y - t0.Y) / segment_height; // be careful with divisions by zero 
            //    Vector3 A = t0 + (t2 - t0) * alpha;
            //    Vector3 B = t0 + (t1 - t0) * beta;
            //    if (A.X > B.X) Swapper.Swap(ref A, ref B);
            //    for (int j = (int)A.X; j <= B.X; j++)
            //    {
            //        SetPixel(j, y, materialDiffuse.AsUint()); // attention, due to int casts t0.y+i != A.y 
            //    }
            //}
            //for (int y = (int)t1.Y; y <= t2.Y; y++)
            //{
            //    int segment_height = (int)(t2.Y - t1.Y + 1);
            //    float alpha = (float)(y - t0.Y) / total_height;
            //    float beta = (float)(y - t1.Y) / segment_height; // be careful with divisions by zero 
            //    Vector3 A = t0 + (t2 - t0) * alpha;
            //    Vector3 B = t1 + (t2 - t1) * beta;
            //    if (A.X > B.X) Swapper.Swap(ref A, ref B);
            //    for (int j = (int)A.X; j <= B.X; j++)
            //    {
            //        SetPixel(j, y, materialDiffuse.AsUint()); // attention, due to int casts t0.y+i != A.y 
            //    }
            //}
            //return;

            x1 *= Width;
            x2 *= Width;
            x3 *= Width;
            y1 *= Heigth;
            y2 *= Heigth;
            y3 *= Heigth;

            // Loss of precision right away=not so good?
            var y1p = (int)y1;
            var y2p = (int)y2;
            var y3p = (int)y3;
            //var x1p = (int)(x1in * Width);
            //var x2p = (int)(x2in * Width);
            //var x3p = (int)(x3in * Width);
                              
            
            if (y2p < y1p)
            {
                Swapper.Swap(ref x1, ref x2);
                Swapper.Swap(ref y1p, ref y2p);
            }
            if (y3p < y1p)
            {
                Swapper.Swap(ref x1, ref x3);
                Swapper.Swap(ref y1p, ref y3p);
            }
            if (y3p < y2p)
            {
                Swapper.Swap(ref x2, ref x3);
                Swapper.Swap(ref y2p, ref y3p);
            }


            //DrawLine(x1p, y1p, x2p, y2p, materialDiffuse);
            //DrawLine(x2p, y2p, x3p, y3p, materialDiffuse);
            //DrawLine(x3p, y3p, x1p, y1p, materialDiffuse);
            //return;

            //var x1p = (int)(x1 * Width);
            //var x2p = (int)(x2 * Width);
            //var x3p = (int)(x3 * Width);

            var y12d = y2p - y1p + 1;
            var y23d = y3p - y2p + 1;
            var y13d = y3p - y1p + 1;

            var k12 = (x2 - x1) / y12d;
            var k23 = (x3 - x2) / y23d;
            var k13 = (x3 - x1) / y13d;

            float leftk12;
            float leftk23;
            float rightk12;
            float rightk23;
            if (k12 < k13)
            {
                leftk12 = k12;
                leftk23 = k23;
                rightk12 = k13;
                rightk23 = k13;
            }
            else
            {
                leftk12 = k13;
                leftk23 = k13;
                rightk12 = k12;
                rightk23 = k23;
            }

            float lx = x1;
            float rx = x1;

            for (var y = y1p; y <= y2p; y++)
            {


                for (var x = (int) lx; x < rx; x++)
                {
                    SetPixel(x, y, diffuse);
                }
                rx += rightk12;
                lx += leftk12;

            }

            //rx += rightk12;
            //lx += leftk12;

            for (var y = y2p; y <= y3p; y++)
            {
                for (var x = (int) lx; x < rx; x++)
                {
                    SetPixel(x, y, diffuse);
                }
                rx += rightk23;
                lx += leftk23;

            }
        }
    }
}