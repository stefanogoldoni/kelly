using Castle.Windsor;

namespace Kelly.Console {
	class Program {
		static void Main(string[] args) {
			int x = -1;
			System.Console.WriteLine(unchecked((uint)(-1)));

			//var container = new WindsorContainer();

			//container.AddComponent("renderer", typeof (IRenderer), typeof (TracingRenderer));
			//container.AddComponent("tracingAlgorithm", typeof (ITracingAlgorithm), typeof (DebugTracingAlgorithm));

			//var renderer = container.GetService<IRenderer>();

			//var surface = new BitmapRenderTarget(40, 30);

			//renderer.RenderScene(surface, null, null);
		}
	}
}
