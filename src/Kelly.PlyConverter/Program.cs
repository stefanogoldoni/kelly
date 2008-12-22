using System;
using System.IO;
using System.Linq;
using Kelly.Geometry;
using Kelly.Math;
using Kelly.Resources;

namespace Kelly.PlyConverter {
	class Program {
		static void Main(string[] args) {
			var inputFilename = args[0];
			var outputFilename = args.Length < 2 ? "output.mesh" : args[1];

			PlyFile ply;
			using(var inputFile = File.OpenText(inputFilename)) {
				ply = new PlyParser().Parse(inputFile);
			}

			var vertex = GetRequiredElementType(ply, "vertex");
			var face = GetRequiredElementType(ply, "face");

			VerifySimplePropertiesExist(vertex, "x", "y", "z");
			VerifyListPropertiesExist(face, "vertex_indices");

			var vertices =
				ply.Elements[vertex]
					.Select(el => new Point(
						(float)el.GetValue("x"),
						(float)el.GetValue("y"),
						(float)el.GetValue("z")));

			var triangles = from el in ply.Elements[face]
			                let indices = (object[]) el.GetValue("vertex_indices")
			                select new MeshTriangle((int) indices[0], (int) indices[1], (int) indices[2]);

			var mesh = new Mesh(vertices, triangles);

			using(var outputFile = File.Create(outputFilename)) {
				new MeshSerializer().Serialize(outputFile, mesh);
			}
		}

		static PlyElementType GetRequiredElementType(PlyFile ply, string elementTypeName) {
			if (!ply.ElementTypes.ContainsKey(elementTypeName)) {
				throw new Exception(
					string.Format("The input PLY file does not contain a \"{0}\" element type.", elementTypeName));
			}

			return ply.ElementTypes[elementTypeName];
		}

		static void VerifySimplePropertiesExist(PlyElementType elementType, params string[] propertyNames) {
			foreach (var name in propertyNames) {
				if (!elementType.Properties.ContainsKey(name)) {
					throw new Exception(
						string.Format("The element type \"{0}\" does not contain a \"{1}\" property.", elementType.Name, name));
				}

				if (elementType.Properties[name].IsList) {
					throw new Exception(
						string.Format("Property \"{1}\" of element type \"{0}\" was expected to be a simple property, not a list.", elementType.Name, name));
				}
			}
		}

		static void VerifyListPropertiesExist(PlyElementType elementType, params string[] propertyNames) {
			foreach (var name in propertyNames) {
				if (!elementType.Properties.ContainsKey(name)) {
					throw new Exception(
						string.Format("The element type \"{0}\" does not contain a \"{1}\" property.", elementType.Name, name));
				}

				if (!elementType.Properties[name].IsList) {
					throw new Exception(
						string.Format("Property \"{1}\" of element type \"{0}\" was expected to be a list property.", elementType.Name, name));
				}
			}
		}
	}
}
