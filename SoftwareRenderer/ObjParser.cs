using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
// ReSharper disable StringLiteralTypo

namespace SoftwareRenderer
{
    public class ObjParser
    {
        private readonly string _objFile;
        private readonly string _mtlFile;

        public ObjParser(string objFile, string mtlFile)
        {
            _objFile = objFile;
            _mtlFile = mtlFile;

        }

        public IList<Mesh> Parse()
        {
            var materials = ParseMaterials(_mtlFile);


            var result = new List<Mesh>();

            var objFileRows = Regex.Split(_objFile, "\r\n|\r|\n");
            MeshBuilder meshBuilder = null;
            foreach (var objFileRow in objFileRows)
            {
                var columns = objFileRow.Split(' ');
                if (columns.Length == 0)
                {
                    continue;
                }

                var firstColumn = columns.First();
                if (firstColumn == "#")
                {
                    continue;
                }

                if (firstColumn == "o")
                {
                    if (meshBuilder != null)
                    {
                        result.Add(meshBuilder.Build());
                    }
                    meshBuilder = new MeshBuilder();
                    if (columns.Length >= 2)
                    {
                        meshBuilder.Name = columns[1];
                    }
                    //result.Add(currentSceneObject);
                }
                if (firstColumn == "v")
                {
                    if (meshBuilder == null)
                    {
                        throw new Exception("'v' before 'o' error");
                    }
                    if (columns.Length != 4)
                    {
                        throw new Exception("Must be 4 columns for Vertex row");
                    }

                    var x  = ParseHelper.ParseFloat(columns[1]);
                    var y  = ParseHelper.ParseFloat(columns[2]);
                    var z  = ParseHelper.ParseFloat(columns[3]);

                    meshBuilder.Vertices.Add(new Vector3(x, y, z));
                }
                if (firstColumn == "f")
                {
                    if (meshBuilder == null)
                    {
                        throw new Exception("'f' before 'o' error");
                    }
                    if (columns.Length != 4)
                    {
                        throw new Exception("Must be 4 columns for Face row");
                    }

                    for (int iFace = 0; iFace < 3; iFace++)
                    {
                        var faceColumns = columns[iFace+1].Split('/');
                        var i = uint.Parse(faceColumns[0]);
                        meshBuilder.Indices.Add(i);

                    }
                }
                if (firstColumn == "usemtl")
                {
                    if (meshBuilder == null)
                    {
                        throw new Exception("'usemtl' before 'o' error");
                    }
                    if (columns.Length != 2)
                    {
                        throw new Exception("'usemtl' missing name");
                    }

                    meshBuilder.Material = materials.Single(x => x.Name == columns[1]);
                }
            }

            if (meshBuilder != null)
            {
                result.Add(meshBuilder.Build());
            }

            return result;
        }

        private static IList<Material> ParseMaterials(string mtlFile)
        {
            var mtlFileRows = Regex.Split(mtlFile, "\r\n|\r|\n");

            var result = new List<Material>();
            Material material = null;
            foreach (var mtlFileRow in mtlFileRows)
            {
                var columns = mtlFileRow.Split(' ');
                if (columns.Length == 0)
                {
                    continue;
                }

                var firstColumn = columns.First();
                if (firstColumn == "#")
                {
                    continue;
                }

                if (firstColumn == "newmtl")
                {
                    if (material != null)
                    {
                        result.Add(material);
                    }

                    if (columns.Length != 2)
                    {
                        throw new Exception("newmtl missing name");
                    }

                    material = new Material
                    {
                        Name = columns[1]
                    };
                }
                if (firstColumn == "Kd")
                {
                    if (material == null)
                    {
                        throw new Exception("'Kd' before 'newmtl' error");
                    }
                    if (columns.Length != 4)
                    {
                        throw new Exception("'Kd' must have 3 floats");
                    }

                    var r = ParseHelper.ParseFloat(columns[1]);
                    var g = ParseHelper.ParseFloat(columns[2]);
                    var b = ParseHelper.ParseFloat(columns[3]);

                    material.Diffuse = new Vector3(r, g, b);
                }
            }

            if (material != null)
            {
                result.Add(material);
            }

            return result;
        }
    }

    public class Material
    {
        public string Name { get; set; }
        public Vector3 Diffuse { get; set; }
    }
}