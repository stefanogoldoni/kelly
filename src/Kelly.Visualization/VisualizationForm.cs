using System.Windows.Forms;
using Castle.Windsor;
using Kelly.Geometry;
using Kelly.Math;
using Kelly.Random;
using Kelly.Sampling;

namespace Kelly.Visualization {
	public partial class VisualizationForm : Form {
		public VisualizationForm() {
			InitializeComponent();

			var container = new WindsorContainer();

			container.AddComponent("tracingAlgorithm", typeof(ITracingAlgorithm), typeof(DebugTracingAlgorithm));
			container.AddComponent("rng", typeof(IRandomNumberGenerator), typeof(MersenneTwisterRandomNumberGenerator));
			container.AddComponent("sampler", typeof(ISampleGenerator), typeof(RandomSampleGenerator));

			container.AddComponent("renderer", typeof(IRenderer), typeof(TracingRenderer));
			var renderer = container.Resolve<IRenderer>(new { samplesPerPixel = 1 });

			var surface = new BitmapRenderTarget(result.Width, result.Height);
			var scene = new Sphere(Point.Zero, 10);
			var camera = new OrthogonalCamera(new Point(0, 0, 10), -Vector.UnitZ, Vector.UnitY, 20, 20);

			renderer.RenderScene(surface, camera, scene);

			result.Image = surface.Bitmap;
		}
	}
}
