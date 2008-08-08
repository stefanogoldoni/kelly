using Kelly.Geometry;
using Kelly.Math;

namespace Kelly {
	public interface IRenderingAlgorithm {
		Color DetermineRayColor(Ray ray, IScene scene);
	}
}
