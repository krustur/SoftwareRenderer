using System.Collections.Generic;
using System.Linq;

namespace SoftwareRenderer
{
    public class MeshBuilder
    {
        public string Name { get; set; }
        public IList<Vector3> Vertices { get; set; } = new List<Vector3>();
        public IList<uint> Indices { get; set; } = new List<uint>();
        public uint Color { get; set; }
        public Material Material { get; set; }

        public Mesh Build()
        {
            var result = new Mesh
            {
                Name = Name,
                Vertices = Vertices.ToArray(),
                Indices = Indices.ToArray(),
                Color = Color,
                Material = Material,
            };
            
            return result;
        }
    }
}