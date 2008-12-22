using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Kelly.Geometry;
using System.Runtime.Serialization.Formatters;

namespace Kelly.Resources {
	public class MeshLoader : IMeshLoader {
		public Mesh Load(string name) {
			using(var stream = File.OpenRead(name)) {
				return LoadFromStream(stream);
			}
		}

		public Mesh LoadFromStream(Stream stream) {
			var formatter = new BinaryFormatter {
				TypeFormat = FormatterTypeStyle.TypesWhenNeeded
			};

			return (Mesh)formatter.Deserialize(stream);
		}
	}
}
