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

        public void SetPixel(int x, int y, uint col)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Heigth)
                return;
            Buffer[(Heigth - y) * Width + x] = col;

        }

        public void DrawLine(int x1, int y1, int x2, int y2, uint col)
        {
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
                    SetPixel(x, (int)y, col);
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
                    SetPixel((int)x, y, col);
                    x += kx;
                }
            }
        }
    }
}