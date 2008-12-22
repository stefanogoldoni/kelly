using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using Kelly.Geometry;

namespace Kelly.Resources {
	public class MeshSerializer {
		private static IFormatter CreateFormatter() {
			return new BinaryFormatter {
				TypeFormat = FormatterTypeStyle.TypesWhenNeeded
			};			
		}

		public void Serialize(Stream stream, Mesh mesh) {
			var formatter = CreateFormatter();
			formatter.Serialize(stream, mesh);
		}

		public Mesh Deserialize(Stream stream) {
			var formatter = CreateFormatter();
			return (Mesh)formatter.Deserialize(stream);
		}
	}
}
