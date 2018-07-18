namespace SoftwareRenderer
{
    public class BoxGeometryGenerator
    {
        private Vector3[] _vertices;
        private uint[] _indices;
        public BoxGeometryGenerator(float size)
        {
            _vertices = new[]
            {
                new Vector3(-size, -size, -size),
                new Vector3(-size, +size, -size),
                new Vector3(+size, +size, -size),
                new Vector3(+size, -size, -size),
                new Vector3(-size, -size, +size),
                new Vector3(-size, +size, +size),
                new Vector3(+size, +size, +size),
                new Vector3(+size, -size, +size)
            };
            _indices = new uint[]
            {

                0, 1, 2,
                0, 2, 3,
                4, 6, 5,
                4, 7, 6,
                4, 5, 1,
                4, 1, 0,
                3, 2, 6,
                3, 6, 7,
                1, 5, 6,
                1, 6, 2,
                4, 0, 3,
                4, 3, 7
            };
        }

        public Vector3[] Vertices => _vertices;
        public uint[] Indices => _indices;
    }
}