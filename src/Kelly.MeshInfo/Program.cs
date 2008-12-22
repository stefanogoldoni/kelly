using System;
using System.IO;
using System.Linq;
using Kelly.Resources;

namespace Kelly.MeshInfo {
	class Program {
		static void Main(string[] args) {
			using(var file = File.OpenRead(args[0])) {
				var mesh = new MeshSerializer().Deserialize(file);

				Console.WriteLine("Vertex count: {0}", mesh.Vertices.Length);
				Console.WriteLine("Triangle count: {0}", mesh.MeshTriangles.Length);

				Console.WriteLine("\nFirst 10 vertices:");

				foreach (var vertex in mesh.Vertices.Take(10)) {
					Console.WriteLine(vertex);
				}

				Console.WriteLine("\nFirst 10 triangles:");

				foreach (var triangle in mesh.MeshTriangles.Take(10)) {
					Console.WriteLine(triangle);
				}
			}
		}
	}
}
