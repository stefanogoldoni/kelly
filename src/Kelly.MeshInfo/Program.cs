using System;
using System.IO;
using Kelly.Resources;

namespace Kelly.MeshInfo {
	class Program {
		static void Main(string[] args) {
			using(var file = File.OpenRead(args[0])) {
				var mesh = new MeshSerializer().Deserialize(file);

				Console.WriteLine("Vertex count: {0}", mesh.Points.Length);
				Console.WriteLine("Triangle count: {0}", mesh.MeshTriangles.Length);
			}
		}
	}
}
