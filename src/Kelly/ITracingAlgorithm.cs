using Kelly.Geometry;
using Kelly.Math;

namespace Kelly {
	public interface ITracingAlgorithm {
		Color DetermineRayColor(Ray ray, IScene scene);
	}
}
