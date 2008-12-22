using Kelly.Geometry;

namespace Kelly.Resources {
	public interface IMeshLoader {
		Mesh Load(string name);
	}
}