using Kelly.Math;

namespace Kelly.RayTracing {
	public class DebugTracingAlgorithm : ITracingAlgorithm {
		public Color DetermineRayColor(Ray ray, IIntersectable scene) {
			var intersection = scene.FindClosestIntersectionWith(ray);

			return intersection == null ? Color.Black : intersection.Color;
		}
	}
}