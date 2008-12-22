using System.IO;
using Kelly.Geometry;

namespace Kelly.Resources {
	public class MeshLoader : IMeshLoader {
		public Mesh Load(string name) {
			using(var stream = File.OpenRead(name)) {
				return new MeshSerializer().Deserialize(stream);
			}
		}
	}
}
