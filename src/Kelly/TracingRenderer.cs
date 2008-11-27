using System.Collections.Generic;
using FrigginAwesome;
using Kelly.Math;

namespace Kelly {
	public class TracingRenderer : IRenderer {
		public TracingRenderer(ITracingAlgorithm algorithm, ISampleGenerator pixelSampleGenerator, int samplesPerPixel) {
			Ensure.That("algorithm", algorithm).IsNotNull();

			_algorithm = algorithm;
			_pixelSampleGenerator = pixelSampleGenerator;
			_samplesPerPixel = samplesPerPixel;
		}

		private readonly ITracingAlgorithm _algorithm;
		private readonly ISampleGenerator _pixelSampleGenerator;
		private readonly int _samplesPerPixel;

		public void RenderScene(IRenderTarget target, ICamera camera, IIntersectable scene) {
			Ensure.That("target", target).IsNotNull();
			Ensure.That("camera", camera).IsNotNull();
			Ensure.That("scene", scene).IsNotNull();

			foreach (var pixel in target.GetPixels())
			foreach (var sample in GenerateImagePlaneSamplesForPixel(pixel, target)) {
				var ray = camera.CreateRayThroughImagePlane(sample);
				var rayColor = _algorithm.DetermineRayColor(ray, scene);
				target.SetPixelColor(pixel, rayColor);
			}
		}

		private IEnumerable<Point2> GenerateImagePlaneSamplesForPixel(Pixel pixel, IRenderTarget target) {
			var pixelWidth = 1f / target.Width;
			var pixelHeight = 1f / target.Height;

			var pixelLeft = pixel.X * pixelWidth;
			var pixelTop = pixel.Y * pixelHeight;

			foreach(var sample in _pixelSampleGenerator.GenerateSamples(_samplesPerPixel)) {
				yield return new Point2(pixelLeft + sample.X, pixelTop + sample.Y);
			}
		}
	}
}
