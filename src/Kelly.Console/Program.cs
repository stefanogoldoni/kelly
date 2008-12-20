using Castle.Windsor;
using Kelly.Geometry;
using Kelly.Math;
using Kelly.Random;
using Kelly.Sampling;

namespace Kelly.Console {
	class Program {
		static void Main(string[] args) {
			var container = new WindsorContainer();

			container.AddComponent("tracingAlgorithm", typeof(ITracingAlgorithm), typeof(DebugTracingAlgorithm));
			container.AddComponent("rng", typeof (IRandomNumberGenerator), typeof (MersenneTwisterRandomNumberGenerator));
			container.AddComponent("sampler", typeof (ISampleGenerator), typeof (RandomSampleGenerator));

			container.AddComponent("renderer", typeof (IRenderer), typeof (TracingRenderer));
			var renderer = container.Resolve<IRenderer>(new { samplesPerPixel = 1 });

			var surface = new BitmapRenderTarget(100, 100);
			var scene = new Sphere(new Point(.5, .5, 2), .5);

			renderer.RenderScene(surface, scene);

			surface.Bitmap.Save("output.bmp");
		}
	}
}
