using System.Drawing;
using System.Windows.Forms;
using Castle.Windsor;
using Kelly.Geometry;
using Kelly.Random;
using Kelly.Sampling;
using Point=Kelly.Math.Point;

namespace Kelly.Visualization {
	public partial class VisualizationForm : Form {
		public VisualizationForm() {
			InitializeComponent();

			RenderButton.Click += WhenRenderButtonClicked;
			SaveButton.Click += WhenSaveButtonClicked;

			InitializeIoC();
		}

		void WhenSaveButtonClicked(object sender, System.EventArgs e) {
			if (saveDialog.ShowDialog() == DialogResult.OK) {
				RenderedImage.Save(saveDialog.FileName);
			}
		}

		void WhenRenderButtonClicked(object sender, System.EventArgs e) {
			Render();
		}

		private IWindsorContainer IoC { get; set; }

		private void InitializeIoC() {
			IoC = new WindsorContainer();
			IoC.AddComponent("tracingAlgorithm", typeof(ITracingAlgorithm), typeof(DebugTracingAlgorithm));
			//IoC.AddComponent("rng", typeof(IRandomNumberGenerator), typeof(MersenneTwisterRandomNumberGenerator));
			IoC.AddComponent("sampler", typeof(ISampleGenerator), typeof(StratifiedSampleGenerator));
			IoC.AddComponent("renderer", typeof(IRenderer), typeof(TracingRenderer));
		}

		private void Render() {
			var renderer = IoC.Resolve<IRenderer>(new { samplesPerPixel = 1 });

			var surface = new BitmapRenderTarget(result.Width, result.Height);
			var scene = new Sphere(new Point(.5, .5, 2), .25);

			renderer.RenderScene(surface, scene);

			RenderedImage = surface.Bitmap;			
		}

		private Image _renderedImage;

		public Image RenderedImage {
			get { return _renderedImage; }
			set {
				_renderedImage = value;
				result.Image = _renderedImage;
			}
		}
	}
}
