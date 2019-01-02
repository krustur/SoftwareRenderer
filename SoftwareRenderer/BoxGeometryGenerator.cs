namespace SoftwareRenderer
{
    public class BoxGeometryGenerator
    {
        public BoxGeometryGenerator(float size, Vector3 diffuse)
        {
            Mesh = new Mesh
            {
                Name = "Generated Cube",
                Vertices = new[]
                {
                    new Vector3(-size, -size, -size),
                    new Vector3(-size, +size, -size),
                    new Vector3(+size, +size, -size),
                    new Vector3(+size, -size, -size),
                    new Vector3(-size, -size, +size),
                    new Vector3(-size, +size, +size),
                    new Vector3(+size, +size, +size),
                    new Vector3(+size, -size, +size)
                },
                Indices = new uint[]
                {
                    0, 1, 2, 0, 2, 3, 4, 6, 5, 4, 7, 6, 4, 5, 1, 4, 1, 0, 3, 2, 6, 3, 6, 7, 1, 5, 6, 1, 6, 2, 4, 0, 3, 4, 3, 7
                },
                Material = new Material
                {
                    Diffuse = diffuse
                }
            };
        }

        public Mesh Mesh { get; set; }
    }
}