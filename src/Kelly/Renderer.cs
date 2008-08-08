using Kelly.Geometry;
using FrigginAwesome;

namespace Kelly {
	public class Renderer {
		public Renderer(IRenderingAlgorithm algorithm) {
			Ensure.That("algorithm", algorithm).IsNotNull();

			_algorithm = algorithm;
		}

		private IRenderingAlgorithm _algorithm;

		public void RenderScene(IRenderingSurface surface, ICamera camera, IScene scene) {
			Ensure.That("surface", surface).IsNotNull();
			Ensure.That("camera", camera).IsNotNull();
			Ensure.That("scene", scene).IsNotNull();

			foreach (var pixel in surface.Pixels)
			foreach (var ray in camera.GetRaysThroughPixel(pixel)) {
				var rayColor = _algorithm.DetermineRayColor(ray, scene);
				surface.SetPixelColor(pixel, rayColor);
			}
		}
	}
}
