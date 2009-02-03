using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Castle.Windsor;
using FrigginAwesome.Extensions;
using Kelly.Geometry;
using Kelly.Materials;
using Kelly.Math;
using Kelly.RayTracing;
using Kelly.Resources;
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
		private int _renderMilliseconds;

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
			renderTime.Text = TimeSpan.FromMilliseconds(_renderMilliseconds).ToString();
		}

		private void StartRender(object sender, DoWorkEventArgs e) {
			var renderer = IoC.Resolve<IRenderer>();

			var target = new MemoryRenderTarget(result.Width, result.Height);

			var color = new Color(1, 0.84, 0);
			var mesh = new MeshLoader().Load("bunny4.mesh");

			var world = new NaiveScene();
			world.AddGeometry(
				new Renderable(
					mesh,
					new SolidMaterial(color)));

			_renderMilliseconds = (int)new Stopwatch().Time(() =>
				renderer.RenderScene(new RenderingContext {
					Target = target,
					World = world,
					ImageMatrix = Matrix.Scaling(1d / target.Width * 100, 1d / target.Height * 100, 1),
					ProjectionMatrix = Matrix.Scaling((double)target.Width / target.Height, 1, 1),
					SamplesPerPixel = _samplesPerPixel
				}));

			_renderedImage = target.ToBitmap();
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
