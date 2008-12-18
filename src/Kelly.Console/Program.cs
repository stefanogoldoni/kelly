using System.Collections;
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

			var surface = new BitmapRenderTarget(40, 30);
			var scene = new Sphere(Point.Zero, 1);
			var camera = new OrthogonalCamera(new Point(0, 0, 10), -Vector.UnitZ, Vector.UnitY, 4, 4);

			renderer.RenderScene(surface, camera, scene);

			surface.Bitmap.Save("output.bmp");
		}
	}
}
