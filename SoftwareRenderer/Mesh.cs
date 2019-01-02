namespace SoftwareRenderer
{
    public class Mesh
    {
        public string Name { get; set; }
        public Vector3[] Vertices { get; set; }
        public uint[] Indices { get; set; }
        public uint Color { get; set; }
        public Material Material { get; set; }
    }
}