using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Castle.Windsor;
using Kelly.Geometry;
using Kelly.Materials;
using Kelly.Math;
using Kelly.RayTracing;
using Kelly.Sampling;
using Point=Kelly.Math.Point;

namespace Kelly.Visualization {
	public partial class VisualizationForm : Form {
		public VisualizationForm() {
			InitializeComponent();

			_renderWorker = new BackgroundWorker();
			_renderWorker.DoWork += StartRender;
			_renderWorker.RunWorkerCompleted += RenderCompleted;

			RenderButton.Click += WhenRenderButtonClicked;
			SaveButton.Click += WhenSaveButtonClicked;

			InitializeIoC();

			//var image = new Bitmap(result.Width, result.Height);
			//using(var g = Graphics.FromImage(image)) {
			//    g.DrawRectangle(Pens.Red, 0, 0, 20, 20);
			//}

			//result.Image = image;
		}

		private Image _renderedImage;
		private readonly BackgroundWorker _renderWorker;

		private IWindsorContainer IoC { get; set; }

		private int _samplesPerPixel;

		private void InitializeIoC() {
			IoC = new WindsorContainer();
			IoC.AddComponent("tracingAlgorithm", typeof(ITracingAlgorithm), typeof(DebugTracingAlgorithm));
			//IoC.AddComponent("rng", typeof(IRandomNumberGenerator), typeof(MersenneTwisterRandomNumberGenerator));
			IoC.AddComponent("sampler", typeof(ISampleGenerator), typeof(StratifiedSampleGenerator));
			IoC.AddComponent("renderer", typeof(IRenderer), typeof(TracingRenderer));
		}

		private void RenderCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (e.Error != null) {
				throw e.Error;
			}

			result.Image = _renderedImage;
		}

		private void StartRender(object sender, DoWorkEventArgs e) {
			var renderer = IoC.Resolve<IRenderer>();

			var surface = new BitmapRenderTarget(result.Width, result.Height);

			var world = new NaiveScene();
			world.AddGeometry(
				new Renderable(
					new Sphere(
						new Point(0.5, 0.5, 10000),
						1000),
					new SolidMaterial(Color.White)));

			world.AddGeometry(
				new Renderable(
					new Sphere(
						new Point(0.5, 0.4, 100), 
						0.3),
					new SolidMaterial(Color.Black)));

			world.AddGeometry(
				new Renderable(
					new Sphere(
						new Point(0.25, 0.75, 200),
						.2),
					new SolidMaterial(Color.Black)));

			world.AddGeometry(
				new Renderable(
					new Sphere(
						new Point(0.75, 0.75, 200),
						.2),
					new SolidMaterial(Color.Black)));

			renderer.RenderScene(new RenderingContext() {
				Target = surface,
				World = world,
				ImageMatrix = Matrix.Scaling(1d / surface.Width, 1d / surface.Height, 1),
				ProjectionMatrix = Matrix.Scaling((double)surface.Width / surface.Height, 1, 1),
				SamplesPerPixel = _samplesPerPixel
			});

			_renderedImage = surface.Bitmap;
		}

		private void WhenSaveButtonClicked(object sender, System.EventArgs e) {
			if (saveDialog.ShowDialog() == DialogResult.OK) {
				_renderedImage.Save(saveDialog.FileName);
			}
		}

		private void WhenRenderButtonClicked(object sender, System.EventArgs e) {
			result.Image = null;

			int samples;
			int.TryParse(samplesPerPixel.Text, out samples);
			_samplesPerPixel = System.Math.Max(samples, 1);

			_renderWorker.RunWorkerAsync();
		}
	}
}
