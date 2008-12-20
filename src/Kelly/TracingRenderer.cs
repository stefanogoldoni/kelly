using System.Collections.Generic;
using FrigginAwesome;
using Kelly.Math;
using Kelly.Sampling;

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

		public void RenderScene(IRenderTarget target, IIntersectable scene) {
			Ensure.That("target", target).IsNotNull();
			Ensure.That("scene", scene).IsNotNull();

			// transforms from image space into camera space
			var imageMatrix = Matrix.Scaling(1d / target.Width, 1d / target.Height, 1);

			foreach (var pixel in target.GetPixels())
			foreach (var pixelSpaceSample in _pixelSampleGenerator.GenerateSamples(_samplesPerPixel)) {

				var imageSpaceSample = new Point(pixel.X + pixelSpaceSample.X, pixel.Y + pixelSpaceSample.Y, 1);
				var cameraSpaceRay = new Ray(imageMatrix * imageSpaceSample, Vector.UnitZ);

				// TODO: transform camera space ray into world space

				var rayColor = _algorithm.DetermineRayColor(cameraSpaceRay, scene);
				target.SetPixelColor(pixel, rayColor);
			}
		}
	}
}
