using Castle.Windsor;

namespace Kelly.Console {
	class Program {
		static void Main(string[] args) {
			var container = new WindsorContainer();

			container.AddComponent("renderer", typeof (IRenderer), typeof (TracingRenderer));
			container.AddComponent("tracingAlgorithm", typeof (ITracingAlgorithm), typeof (DebugTracingAlgorithm));

			var renderer = container.GetService<IRenderer>();

			var surface = new BitmapRenderingSurface(40, 30);

			renderer.RenderScene(surface, null, null);
		}
	}
}
