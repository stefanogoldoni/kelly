using Kelly.Math;

namespace Kelly.RayTracing {
	public interface ITracingAlgorithm {
		Color DetermineRayColor(Ray ray, IIntersectable scene);
	}
}