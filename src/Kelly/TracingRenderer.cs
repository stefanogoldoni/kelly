using FrigginAwesome;
using Kelly.Math;
using Kelly.Sampling;

namespace Kelly {
	public class TracingRenderer : IRenderer {
		public TracingRenderer(ITracingAlgorithm algorithm, ISampleGenerator pixelSampleGenerator) {
			Ensure.That("algorithm", algorithm).IsNotNull();

			_algorithm = algorithm;
			_pixelSampleGenerator = pixelSampleGenerator;
		}

		private readonly ITracingAlgorithm _algorithm;
		private readonly ISampleGenerator _pixelSampleGenerator;

		public void RenderScene(RenderingContext context) {
			Ensure.That("context", context).IsNotNull();

			// transforms from image space into camera space
			var imageMatrix = Matrix.Scaling(1d / context.Target.Width, 1d / context.Target.Height, 1);

			foreach (var pixel in context.Target.GetPixels()) {
				var colorAccumulator = Color.Black;

				foreach (var pixelSpaceSample in _pixelSampleGenerator.GenerateSamples(context.SamplesPerPixel)) {

					var imageSpaceSample = new Point(pixel.X + pixelSpaceSample.X, pixel.Y + pixelSpaceSample.Y, 1);

					var projectionSpaceRay = new Ray(imageMatrix * imageSpaceSample, Vector.UnitZ);
					var cameraSpaceRay = context.ProjectionMatrix * projectionSpaceRay;

					// TODO: transform camera space ray into world space

					colorAccumulator += _algorithm.DetermineRayColor(cameraSpaceRay, context.World);
				}

				context.Target.SetPixelColor(pixel, colorAccumulator / context.SamplesPerPixel);
			}
		}
	}
}
