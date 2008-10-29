using Kelly.Math;

namespace Kelly {
	public class DebugTracingAlgorithm : ITracingAlgorithm {
		public Color DetermineRayColor(Ray ray, IScene scene) {
			var intersection = scene.IntersectWith(ray);

			if (intersection == null) {
				return Color.Black;
			}

			return intersection.Color;
		}
	}
}
