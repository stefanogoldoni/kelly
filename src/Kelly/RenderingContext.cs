using Kelly.Math;

namespace Kelly {
	public class RenderingContext {
		public RenderingContext() {
			ProjectionMatrix = Matrix.Identity;
			ViewMatrix = Matrix.Identity;

			SamplesPerPixel = 1;
		}

		public IRenderTarget Target { get; set; }
		public IIntersectable World { get; set; }

		public Matrix ProjectionMatrix { get; set; }
		public Matrix ViewMatrix { get; set; }

		public int SamplesPerPixel { get; set; }
	}
}