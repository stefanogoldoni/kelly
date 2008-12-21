using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Castle.Windsor;
using Kelly.Geometry;
using Kelly.Materials;
using Kelly.Math;
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
			var s1 = new Sphere(new Point(.5, .5, 2), .25);
			var s2 = new Sphere(new Point(1, 1, 2), .5);

			world.AddGeometry(new RenderableGeometry(s1, new SolidMaterial(Color.Red)));
			world.AddGeometry(new RenderableGeometry(s2, new SolidMaterial(Color.Green)));

			renderer.RenderScene(new RenderingContext() {
				Target = surface,
				World = world,
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
