using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Kelly.Geometry;
using Kelly.Math;
using System.Linq;

namespace Kelly.Resources {
	public class TrimeshLoader : IMeshLoader {
		private const int IdentifierSize = 8;
		private const string IdentifierString = "TRIMESH\0";
		private const int CurrentVersion = 1;

		public Mesh Load(string name) {
			using(var file = File.OpenRead(name)) {
				return Load(file);
			}
		}

		public Mesh Load(Stream stream) {
			using (var file = new BinaryReader(stream)) {
				var identifierBytes = file.ReadBytes(IdentifierSize);

				var identifier = Encoding.ASCII.GetString(identifierBytes);
				if (identifier != IdentifierString)
					throw new Exception("The specified file is not a valid TriMesh file (incorrect file identifier).");

				var version = file.ReadInt32();

				if (version != CurrentVersion) {
					throw new Exception(
						string.Format(
							"The specified TriMesh file uses a different version of the file format. The current version is {0}. The version specified in the file is {1}.",
							CurrentVersion, version));
				}

				var vertexCount = file.ReadInt32();
				var triangleCount = file.ReadInt32();

				return new Mesh(ReadVertices(vertexCount, file), ReadMeshTriangles(triangleCount, file));
			}
		}

		private static IEnumerable<Point> ReadVertices(int count, BinaryReader file) {
			return Enumerable.Range(0, count).Select(i => new Point(file.ReadDouble(), file.ReadDouble(), file.ReadDouble()));
		}

		private static IEnumerable<MeshTriangle> ReadMeshTriangles(int count, BinaryReader file) {
			//return Enumerable.Range(0, count).Select(i => new MeshTriangle(file.ReadInt32(), file.ReadInt32(), file.ReadInt32()));
			throw new NotImplementedException();
		}
	}
}